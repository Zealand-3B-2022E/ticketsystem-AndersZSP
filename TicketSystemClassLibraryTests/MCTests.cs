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
    public class MCTests
    {
        private MC mc;
        [TestInitialize]
        public void BeforeEachTest()
        {
            mc = new MC();
        }

        [TestMethod()]
        public void PriceTest()
        {
            //Arrange
            // Tom grundet TestInitialize

            //Act
            double expectedPrice = mc.Price();
            //Assert
            Assert.AreEqual(expectedPrice, 125);
        }

        [TestMethod()]
        public void FailPriceIsBelow125Test()
        {
            //Arrange

            //Act
            double expectedPrice = mc.Price();
            //Assert
            Assert.IsFalse(expectedPrice < 125);
        }
        //reason we have 2 different Fail Price tests is to easier identify if the price is incorrect above or below the asking price
        [TestMethod()]
        public void FailPriceIsabove125Test()
        {
            //Arrange

            //Act
            double expectedPrice = mc.Price();
            //Assert
            Assert.IsFalse(expectedPrice > 125);
        }

        [TestMethod()]
        public void VehicleTypeTest()
        {
            //Arrange

            //Act
            string expectedVehicleType = mc.VehicleType();
            //Assert
            Assert.AreEqual(expectedVehicleType, "MC");
        }
        [TestMethod()]
        public void VehicleTypeIncorrectValueTest()
        {
            //Arrange

            //Act
            string expectedVehicleType = mc.VehicleType();
            //Assert
            Assert.AreNotEqual(expectedVehicleType, "Car");
        }
    }
}