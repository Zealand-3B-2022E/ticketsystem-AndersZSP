using TicketSystemClassLibrary;

namespace Oresundbron
{
    /// <summary>
    /// The OresundCar class inherits from the Car class from the TicketSystemClassLibrary.
    /// OresundCar class allows you to construct an object with the following properties:
    /// string LicensePlate
    /// DateTime Date
    /// bool BroBizz
    /// 
    /// OresundCar objects have the following methods:
    /// double Price() returns a double with the price of the ticket depending on if the buyer has a BroBizz or not.
    /// string Vehicletype() returns a string containing "Oresund car".
    /// </summary>
    public class OresundCar : Car
    {
        /// <summary>
        /// string LicensePlate refers to the OresundCar object's License plate, that can't be longer than 7 characters 
        /// </summary>
        public override string LicensePlate { get; }
        /// <summary>
        /// DateTime Date refers to the date that the tickets is to be used
        /// </summary>
        public override DateTime Date { get; }
        /// <summary>
        /// bool BroBizz refers to whether the OresundCar has a BroBizz or not, shaving 249 off the ticket price
        /// </summary>
        public override bool BroBizz { get; }

        public OresundCar()
        {

        }

        /// <summary>
        /// Creates an object of the OresundCar Class, that can use the methods Price() and VehicleType()
        /// </summary>
        /// <param name="licensePlate">string parameter that can't be above 7 characters</param>
        /// <param name="date">DateTime parameter that can't be min, max or empty</param>
        /// <param name="broBizz">Bool parameter whether the vehicle has a BroBizz or not</param>
        /// <exception cref="ArgumentOutOfRangeException">Exception is thrown if the licenseplate is 8 characters or more. 
        /// Or if the date is empty, min-value or max-value</exception>
        public OresundCar(string licensePlate, DateTime date, bool broBizz)
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
        /// The Price() method takes the original price and gives discounts depending on if the buyer has BroBizz
        /// </summary>
        /// <returns>double 410 unless the purchase is with BroBizz, then it returns double 161</returns>
        public override double Price()
        {
            if (BroBizz)
            {
                return 161;
            }
            return 410;
        }

        /// <summary>
        /// The VehicleType method returns a string of the type of vehicle the ticket is for
        /// </summary>
        /// <returns>string "Oresund car"</returns>
        public override string VehicleType()
        {
            return "Oresund car";
        }
    }
}