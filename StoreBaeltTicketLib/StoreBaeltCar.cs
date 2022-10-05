using System.Globalization;
using TicketSystemClassLibrary;

namespace StoreBaeltTicketLib
{

        /// <summary>
        /// The StoreBaeltCar class inherits from the Car class from the TicketSystemClassLibrary.
        /// StoreBaeltCar class allows you to construct an object with the following properties:
        /// string LicensePlate
        /// DateTime Date
        /// bool BroBizz
        /// 
        /// StoreBaeltCar objects have the following methods:
        /// double Price() returns a double with the price of the ticket, depending on if it is weekend or not, and if the buyer has a BroBizz or not
        /// string Vehicletype() returns a string containing "Car". Same as the base class Car
        /// </summary>
        public class StoreBaeltCar : Car
        {

        /// <summary>
        /// string LicensePlate refers to the StoreBaeltCar object's License plate, that can't be longer than 7 characters 
        /// </summary>
        public override string LicensePlate { get; set; }
        /// <summary>
        /// DateTime Date refers to the date that the tickets is to be used
        /// </summary>
        public override DateTime Date { get; set; }
        /// <summary>
        /// bool BroBizz refers to whether the StoreBaeltCar has a BroBizz or not, shaving 5% off the ticket price
        /// </summary>
        public override bool BroBizz { get; set; }
        /// <summary>
        /// Empty contructor
        /// </summary>
        public StoreBaeltCar()
            {

            }

        /// <summary>
        /// Creates an object of the StoreBaeltCarClass, that can use the methods Price() and VehicleType()
        /// </summary>
        /// <param name="licensePlate">string parameter that can't be above 7 characters</param>
        /// <param name="date">DateTime parameter that can't be min, max or empty</param>
        /// <param name="broBizz">Bool parameter whether the vehicle has a BroBizz or not</param>
        /// <exception cref="ArgumentOutOfRangeException">Exception is thrown if the licenseplate is 8 characters or more. 
        /// Or if the date is empty, min-value or max-value</exception>
        public StoreBaeltCar(string licensePlate, DateTime date, bool broBizz)
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
            /// The Price() method takes the original price and gives discounts depending on if the ticket is for a weekend
            /// and/or if the buyer has BroBizz
            /// </summary>
            /// <returns>double 240, minus the 20% discount if it's weekend and the 5% discount if the buyer has BroBizz</returns>
            public override double Price()
            {
                // Code inspired by https://code-maze.com/csharp-datetime-weekend-weekday/
                double price = 240;
                var date = Date;
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    double priceWithoutBroBizz = price * 0.80;
                    if (BroBizz)
                    {
                        double priceWithBroBizz = priceWithoutBroBizz * 0.95;
                        return priceWithBroBizz;
                    }
                    else
                    {
                        return priceWithoutBroBizz;
                    }
                }
                else
                {
                    if (BroBizz)
                    {
                        double priceWithBroBizz = price * 0.95;
                        return priceWithBroBizz;
                    }
                    return price;
            }
        }
    }
}