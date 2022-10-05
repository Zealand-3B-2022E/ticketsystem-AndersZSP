namespace TicketSystemClassLibrary
{
    /// <summary>
    /// Vehicle is an abstract class so we can use it in the future for different types of vehicles, but we can't make objects out of it
    /// 
    /// Objects that inherit from the Vehicle class have the following properties:
    /// string LicensePlace
    /// DateTime Date
    /// bool BroBizz
    /// 
    /// Vehicle objects have two methods: 
    /// Price() which returns a double of the price of a ticket for that vehicletype. Remember to include brobizz discount if relevant
    /// VehicleType() which returns a string of the type of vehicle the ticket is for.
    /// </summary>
    public abstract class Vehicle
    {
        /*I went with having the properties be abstract, so every vehicle that inherits from the vehicle class is forced to have these properties
        * As they are relevant for ticket sales
        */
        /// <summary>
        /// string LicensePlate refers to the Vehicle object's License plate, that can't be longer than 7 characters 
        /// </summary>
        public abstract string LicensePlate { get; set; }
        /// <summary>
        /// DateTime Date refers to the date that the tickets is to be used
        /// </summary>
        public abstract DateTime Date { get; set; }
        /// <summary>
        /// bool BroBizz refers to whether the vehicle has a BroBizz or not, shaving 5% off the ticket price
        /// </summary>
        public abstract bool BroBizz { get; set; }

        /// <summary>
        /// The Price method returns a double of the price of a ticket for that vehicletype.
        /// The method is meant to be overwritten by its subclasses
        /// </summary>
        public abstract double Price();

        /// <summary>
        /// The VehicleType method returns a string of the type of vehicle the ticket is for.
        /// The method is meant to be overwritten by its subclasses
        /// </summary>
        public abstract string VehicleType();
    }
}
