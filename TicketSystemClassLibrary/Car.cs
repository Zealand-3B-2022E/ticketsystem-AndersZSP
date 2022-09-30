namespace TicketSystemClassLibrary
{
    /// <summary>
    /// Objects of the Car class has the following properties:
    /// string LicensePlace
    /// DateTime Date
    /// bool BroBizz
    /// 
    /// Car objects have two methods: 
    /// Price() which returns a double of the price of a ticket for that vehicletype, with discount if you have BroBizz.
    /// VehicleType() which returns a string of the type of vehicle the ticket is for.
    /// </summary>
    public class Car:Vehicle
    {
        public override string LicensePlate { get;}
        public override DateTime Date { get;}

        public override bool BroBizz { get; }

        public Car()
        {

        }
        public Car(string licensePlate, DateTime date, bool broBizz)
        {
            if (licensePlate.Length > 7)
            {
                throw new ArgumentOutOfRangeException("License plate must be 7 or fewer characters");
            }
            LicensePlate = licensePlate;
            Date = date;
            BroBizz = broBizz;
        }

        /// <summary>
        /// The Price method returns a double of the price of a ticket for that vehicletype.
        /// </summary>
        /// <returns>double 240 unless BroBizz is true, where it returns 228</returns>
        public override double Price()
        {
            double price = 240;
            if (BroBizz)
            {
                return price * 0.95;
            }
            return price;
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