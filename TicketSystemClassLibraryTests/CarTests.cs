using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketSystemClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemClassLibrary.Tests
{

    [TestClass()]
    public class CarTests
    {
        private Car car;
        [TestInitialize]
        public void BeforeEachTest()
        {
            car = new Car();
        }

        [TestMethod()]
        public void PriceTest()
        {
            //Arrange
            // Tom grundet TestInitialize

            //Act
            double expectedPrice = car.Price();
            //Assert
            Assert.AreEqual(expectedPrice, 240);
        }

        [TestMethod()]
        public void FailPriceIsBelow239Test()
        {
            //Arrange

            //Act
            double expectedPrice = car.Price();
            //Assert
            Assert.IsFalse(expectedPrice < 239);
        }

        [TestMethod()]
        public void FailPriceIsabove241Test()
        {
            //Arrange

            //Act
            double expectedPrice = car.Price();
            //Assert
            Assert.IsFalse(expectedPrice > 241);
        }

        [TestMethod()]
        public void VehicleTypeTest()
        {
            //Arrange

            //Act
            string expectedVehicleType = car.VehicleType();
            //Assert
            Assert.AreEqual(expectedVehicleType, "Car");
        }
        [TestMethod()]
        public void VehicleTypeIncorrectTest()
        {
            //Arrange

            //Act
            string expectedVehicleType = car.VehicleType();
            //Assert
            Assert.AreNotEqual(expectedVehicleType, "MC");
        }
    }
}