﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemClassLibrary
{
    /// <summary>
    /// Objects of the MC class has the following properties:
    /// string LicensePlace
    /// DateTime Date
    /// 
    /// MC objects have two methods: 
    /// Price() which returns a double of the price of a ticket for that vehicletype.
    /// VehicleType() which returns a string of the type of vehicle the ticket is for.
    /// </summary>
    public class MC:Vehicle
    {
        public override string LicensePlate { get; }
        public override DateTime Date { get; }

        public MC()
        {

        }
        public MC(string licensePlate, DateTime date)
        {
            
            if(licensePlate.Length > 7)
            {
                throw new ArgumentOutOfRangeException("License plate must be 7 or fewer characters");
            }
            LicensePlate = licensePlate;
            Date = date;
        }

        /// <summary>
        /// The Price method returns a double of the price of a ticket for that vehicletype.
        /// </summary>
        /// <returns>double 125</returns>
        public override double Price()
        {
            return 125;
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