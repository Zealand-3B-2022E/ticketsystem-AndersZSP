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
    public class Car
    {
        public string LicensePlate { get;}
        public DateTime Date { get;}

        public Car()
        {

        }
        public Car(string licensePlate, DateTime date)
        {
            LicensePlate = licensePlate;
            Date = date;
        }

        /// <summary>
        /// The Price method returns a double of the price of a ticket for that vehicletype.
        /// </summary>
        /// <returns>double 240</returns>
        public double Price()
        {
            return 240;
        }

        /// <summary>
        /// The VehicleType method returns a string of the type of vehicle the ticket is for
        /// </summary>
        /// <returns>string "Car"</returns>
        public string VehicleType()
        {
            return "Car";
        }


    }
}