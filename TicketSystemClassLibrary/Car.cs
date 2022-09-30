namespace TicketSystemClassLibrary
{
    /// <summary>
    /// Objects of the Car class has the following properties:
    /// string LicensePlace
    /// DateTime Date
    /// 
    /// Car objects have two methods: 
    /// Price() which returns a double of the price of a ticket for that vehicletype.
    /// VehicleType() which returns a string of the type of vehicle the ticket is for.
    /// </summary>
    public class Car:Vehicle
    {
        public override string LicensePlate { get;}
        public override DateTime Date { get;}

        public Car()
        {

        }
        public Car(string licensePlate, DateTime date)
        {
            if (licensePlate.Length > 7)
            {
                throw new ArgumentOutOfRangeException("License plate must be 7 or fewer characters");
            }
            LicensePlate = licensePlate;
            Date = date;
        }

        /// <summary>
        /// The Price method returns a double of the price of a ticket for that vehicletype.
        /// </summary>
        /// <returns>double 240</returns>
        public override double Price()
        {
            return 240;
        }

        /// <summary>
        /// The VehicleType method returns a string of the type of vehicle the ticket is for
        /// </summary>
        /// <returns>string "Car"</returns>
        public override string VehicleType()
        {
            return "Car";
        }


    }
}