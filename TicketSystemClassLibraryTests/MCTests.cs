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
        [DataRow("12345678")]
        [DataRow("99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MCWithLongLicensePlateFailTest(string licensePlate)
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            MC longLicensePlate = new MC(licensePlate, date);
            //Act

            //Assert
            Assert.Fail();
        }


        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void MCWithNullLicensePlateFailTest()
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            MC nullLicensePlate = new MC(null, date);
            //Act

            //Assert
            Assert.IsNull(nullLicensePlate);
        }


        [TestMethod()]
        [DataRow("1234567")]
        [DataRow("123456")]
        [DataRow("abcdefg")]
        [DataRow("abcdef")]
        [DataRow("A")]
        // [DataRow("12345678")] //This one was just to test that a MC wouldn't be created if it had a long license plate
        public void MCWith7OrFewerCharLicensePlateTest(string licensePlate) //Testing that a MC is created and can be added to the list
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            MC correctLicensePlate = new MC(licensePlate, date);
            List<MC> MCs = new List<MC>();
            MCs.Add(correctLicensePlate);
            //Act

            //Assert
            Assert.AreEqual(MCs.Count, 1);
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