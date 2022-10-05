using Microsoft.AspNetCore.Mvc;
using StoreBaeltBroen.Managers;
using StoreBaeltTicketLib;
using TicketSystemClassLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreBaeltBroen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private ITicketsManager mgr = new TicketsManager();

        // GET: api/<TicketsController>
        /// <summary>
        /// Returns a list of all the tickets in the system, if there are any (204 no content error code). Indifferent to what kind of ticket
        /// </summary>
        /// <returns>List with all tickets</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]     //Tested works
        [ProducesResponseType(StatusCodes.Status204NoContent)]    //Tested works
        public IActionResult GetAll()
        {
            List<Vehicle> list = mgr.GetAll();
            return (list.Count == 0) ? NoContent() : Ok(list); //If list is empty return 204, else return list
        }

        // GET api/<TicketsController>/5
        /// <summary>
        /// Retrieves every ticket that has the same licenseplate as the one typed in. Sends back a 404 if there is no ticket connected
        /// </summary>
        /// <param name="licensePlate">the licenseplate of the vehicle that you wish to find all tickets for</param>
        /// <returns>A list of all tickets connected to the licenseplate</returns>
        [HttpGet]
        [Route("search/{licensePlate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]    //tested works
        [ProducesResponseType(StatusCodes.Status404NotFound)]    //Tested works
        public IActionResult GetByLicensePlate(string licensePlate)
        {
            try
            {
                List<Vehicle> TicketsForVehicle = mgr.GetByLicensePlate(licensePlate);
                return Ok(TicketsForVehicle);
            }
            catch
            {
                return NotFound("No tickets exists for this licenseplate");
            }
        }

        // POST api/<TicketsController>
        /// <summary>
        /// Function lets you buy a ticket for your car. It automatically makes it of the class "StoreBaeltCar" (SBCar) 
        /// </summary>
        /// <param name="SBCar">You fill out the licenseplate, Date and BroBizz properties of the SBCar object</param>
        /// <returns>a single ticket is put into the system based on the information from SBCar</returns>
        [HttpPost]
        [Route("buyticketcar")]
        [ProducesResponseType(StatusCodes.Status201Created)]    //Tested works. Creates ticket
        [ProducesResponseType(StatusCodes.Status400BadRequest)]    //tested Works. Sends error if invalid data is entered
        [ProducesResponseType(StatusCodes.Status409Conflict)]    //Tested works. Sends error if license plate or date invalid
        public IActionResult BuyTicketCar([FromBody] StoreBaeltCar SBCar)
        {
            try 
            {
                StoreBaeltCar newVehicle = mgr.BuyTicketCar(SBCar);
                string uri = "api/[controller]/" + SBCar.LicensePlate;
                return Created(uri, newVehicle);
            }
            catch(ArgumentOutOfRangeException ae)
            {
                return Conflict(ae.Message);
            }

        }

        /// <summary>
        /// Function lets you buy a ticket for a MC
        /// </summary>
        /// <param name="mc">You fill out the licenseplate, Date and BroBizz properties of the MC object</param>
        /// <returns>a single ticket is put into the system based on the information from MC</returns>
        [HttpPost]
        [Route("buyticketmc")]
        [ProducesResponseType(StatusCodes.Status201Created)]    //Tested works. Creates ticket
        [ProducesResponseType(StatusCodes.Status400BadRequest)]    //tested Works. Sends error if invalid data is entered
        [ProducesResponseType(StatusCodes.Status409Conflict)]    //Tested works. Sends error if license plate or date is invalid
        public IActionResult BuyTicketMC([FromBody] MC mc)
        {
            try
            {
                MC newVehicle = mgr.BuyTicketMC(mc);
                string uri = "api/[controller]/" + mc.LicensePlate;
                return Created(uri, newVehicle);
            }
            catch (ArgumentException ae)
            {
                return Conflict(ae.Message);
            }

        }

    }
}
