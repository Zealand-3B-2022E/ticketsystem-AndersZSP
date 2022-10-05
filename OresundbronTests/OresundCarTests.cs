using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oresundbron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemClassLibrary;

namespace Oresundbron.Tests
{
    [TestClass()]
    public class OresundCarTests
    {
        private OresundCar OresundCar;
        private OresundCar broBizzOresundCar;
        [TestInitialize]
        public void BeforeEachTest()
        {
            OresundCar = new OresundCar();
            DateTime date = new DateTime(2022, 12, 25);
            broBizzOresundCar = new OresundCar("1234567", date, true);
        }


        [TestMethod()]
        [DataRow("12345678")]
        [DataRow("99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999")]
        [DataRow("        ")]//8 spaces
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OresundCarWithLongLicensePlateFailTest(string licensePlate)
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            OresundCar longLicensePlate = new OresundCar(licensePlate, date, false);
            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void OresundCarWithNullLicensePlateFailTest()
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            OresundCar nullLicensePlate = new OresundCar(null, date, false);
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
        [DataRow("       ")]//7 spaces
        [DataRow("")]
        // [DataRow("12345678")] //This one was just to test that a OresundCar wouldn't be created if it had a long license plate
        public void OresundCarWith7OrFewerCharLicensePlateTest(string licensePlate) //Testing that a OresundCar is created and can be added to the list
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            OresundCar correctLicensePlate = new OresundCar(licensePlate, date, false);
            List<OresundCar> OresundCars = new List<OresundCar>();
            //Act
            OresundCars.Add(correctLicensePlate);

            //Assert
            Assert.AreEqual(OresundCars.Count, 1);
        }





        [TestMethod()]
        public void PriceTest()
        {
            //Arrange
            // Tom grundet TestInitialize

            //Act
            double expectedPrice = OresundCar.Price();
            //Assert
            Assert.AreEqual(expectedPrice, 410);
        }

        [TestMethod()]
        public void FailPriceIsBelow161Test()
        {
            //Arrange

            //Act
            double expectedPrice = OresundCar.Price();
            //Assert
            Assert.IsFalse(expectedPrice < 161);
        }

        //reason we have 2 different Fail Price tests is to easier identify if the price is incorrect above or below the asking price
        [TestMethod()]
        public void FailPriceIsAbove410Test()
        {
            //Arrange

            //Act
            double expectedPrice = OresundCar.Price();
            //Assert
            Assert.IsFalse(expectedPrice > 410);
        }





        [TestMethod()]
        public void BroBizzPriceTest()
        {
            //Arrange

            //Act
            double expectedPrice = broBizzOresundCar.Price();
            //Assert
            Assert.AreEqual(expectedPrice, 161);
        }

        [TestMethod()]
        public void FailBroBizzPriceIsBelow228Test()
        {
            //Arrange

            //Act
            double expectedPrice = broBizzOresundCar.Price();
            //Assert
            Assert.IsFalse(expectedPrice < 161);
        }

        //reason we have 2 different Fail Price tests is to easier identify if the price is incorrect above or below the asking price
        [TestMethod()]
        public void FailBroBizzPriceIsabove228Test()
        {
            //Arrange

            //Act
            double expectedPrice = broBizzOresundCar.Price();
            //Assert
            Assert.IsFalse(expectedPrice > 228);
        }





        [TestMethod()]
        public void VehicleTypeTest()
        {
            //Arrange

            //Act
            string expectedVehicleType = OresundCar.VehicleType();
            //Assert
            Assert.AreEqual(expectedVehicleType, "Oresund car");
        }
        [TestMethod()]
        public void VehicleTypeIncorrectValueTest()
        {
            //Arrange

            //Act
            string expectedVehicleType = OresundCar.VehicleType();
            //Assert
            Assert.AreNotEqual(expectedVehicleType, "Oresund MC");
        }




        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OresundCarDateIsinvalidTest()
        {
            //Arrange
            DateTime date = new DateTime(0, 0, 0);
            OresundCar OresundCar = new OresundCar("1234567", date, false);
            //Act

            //Assert
            Assert.Fail();
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OresundCarDateIsEmptyTest()
        {
            //Arrange
            DateTime date = new DateTime();
            OresundCar OresundCar = new OresundCar("1234567", date, false);
            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OresundCarDateIsMinimunTest()
        {
            //Arrange

            OresundCar OresundCar = new OresundCar("1234567", DateTime.MinValue, false);
            //Act

            //Assert
            Assert.Fail();
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OresundCarDateIsMaxTest()
        {
            //Arrange

            OresundCar OresundCar = new OresundCar("1234567", DateTime.MaxValue, false);
            //Act

            //Assert
            Assert.Fail();
        }

        /// <summary>
        /// Testing that OresundCar can be used as a Car object
        /// </summary>
        [TestMethod]
        public void OresundCarPolymorphismWorksTest()
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            OresundCar correctLicensePlate = new OresundCar("1234567", date, false);
            List<Car> cars = new List<Car>();
            //Act
            cars.Add(correctLicensePlate);
            //Assert
            Assert.AreEqual(cars.Count, 1);

        }
    }
}