namespace TicketSystemClassLibrary
{
    /// <summary>
    /// the MC class inherits from the Vehicle abstract class
    /// 
    /// Objects of the MC class has the following properties:
    /// string LicensePlace
    /// DateTime Date
    /// Bool BroBizz
    /// 
    /// MC objects have two methods: 
    /// Price() which returns a double of the price of a ticket for that vehicletype and gives 5% discount if you have BroBizz.
    /// VehicleType() which returns a string of the type of vehicle the ticket is for.
    /// </summary>
    public class MC : Vehicle
    {
        /// <summary>
        /// string LicensePlate refers to the MC object's License plate, that can't be longer than 7 characters 
        /// </summary>
        public override string LicensePlate { get; set; }
        /// <summary>
        /// DateTime Date refers to the date that the tickets is to be used
        /// </summary>
        public override DateTime Date { get; set; }
        /// <summary>
        /// bool BroBizz refers to whether the Car has a BroBizz or not, shaving 5% off the ticket price
        /// </summary>
        public override bool BroBizz { get; set; }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public MC()
        {

        }
        /// <summary>
        /// Creates an object of the MC Class, that can use the methods Price() and VehicleType()
        /// </summary>
        /// <param name="licensePlate">string parameter that can't be above 7 characters</param>
        /// <param name="date">DateTime parameter that can't be min, max or empty</param>
        /// <param name="broBizz">Bool parameter whether the vehicle has a BroBizz or not</param>
        /// <exception cref="ArgumentOutOfRangeException">Exception is thrown if the licenseplate is 8 characters or more. 
        /// Or if the date is empty, min-value or max-value</exception>
        public MC(string licensePlate, DateTime date, bool broBizz)
        {

            if (licensePlate.Length > 7)
            {
                throw new ArgumentOutOfRangeException("License plate must be 7 or fewer characters");
            }
            if (date == DateTime.MinValue || date == DateTime.MaxValue)
            {
                throw new ArgumentOutOfRangeException("Please fill in a date");
            }
            LicensePlate = licensePlate;
            Date = date;
            BroBizz = broBizz;
        }

        /// <summary>
        /// The Price method returns a double of the price of a ticket for that vehicletype.
        /// </summary>
        /// <returns>double 125 unless BroBizz is true, where it returns 118.75</returns>
        public override double Price()
        {
            double price = 125;
            if (BroBizz)
            {
                return price * 0.95;
            }
            return price;
        }

        /// <summary>
        /// The VehicleType method returns a string of the type of vehicle the ticket is for.
        /// </summary>
        /// <returns>string "MC"</returns>
        public override string VehicleType()
        {
            return "MC";
        }
    }
}
