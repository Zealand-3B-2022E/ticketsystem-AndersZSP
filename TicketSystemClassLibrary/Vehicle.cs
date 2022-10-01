using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public abstract string LicensePlate { get; set;  }
        public abstract DateTime Date { get; set; }
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
        /// <returns>string "Vehicle"</returns>
        public abstract string VehicleType();
    }
}
