using Microsoft.AspNetCore.Mvc;
using StoreBaeltBroen.Managers;
using StoreBaeltTicketLibrary;
using TicketSystemClassLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreBaeltBroen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        //GetByLicensePlate
        //GetAll
        //BuyTicket
        private ITicketsManager mgr = new TicketsManager();

        // GET: api/<TicketsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            List<Vehicle> list = mgr.GetAll();
            return (list.Count == 0) ? NoContent() : Ok(list); //If list is empty return 204, else return list
        }

        // GET api/<TicketsController>/5
        [HttpGet]
        [Route("search/{licensePlate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByLicensePlate(string licensePlate)
        {
            try
            {
                List<Vehicle> TicketsForVehicle = mgr.GetByLicensePlate(licensePlate);
                return Ok(TicketsForVehicle);
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }

        // POST api/<TicketsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Post([FromBody] StoreBaeltCar SBCar)
        {
            try 
            {
                StoreBaeltCar newVehicle = mgr.BuyTicketCar(SBCar);
                string uri = "api/StoreBaeltCar/" + SBCar.LicensePlate;
                return Created(uri, newVehicle);
            }
            catch(ArgumentException ae)
            {
                return Conflict(ae.Message);
            }

        }

        //[HttpPost]
        //[Route("buyticketmc")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status409Conflict)]
        //public IActionResult BuyTicketMC([FromBody] MC mc)
        //{
        //    try
        //    {
        //        MC newVehicle = mgr.BuyTicketMC(mc);
        //        string uri = "api/mctickets/" + newVehicle.LicensePlate;
        //        return Created(uri, newVehicle);
        //    }
        //    catch (ArgumentException ae)
        //    {
        //        return Conflict(ae);
        //    }

        //}

        //// PUT api/<TicketsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TicketsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
