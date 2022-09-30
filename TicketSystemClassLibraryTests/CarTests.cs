using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketSystemClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicketSystemClassLibrary.Tests
{

    [TestClass()]
    public class CarTests
    {
        private Car car;
        private Car broBizzCar;
        [TestInitialize]
        public void BeforeEachTest()
        {
            car = new Car();
            DateTime date = new DateTime(2022, 12, 25);
            broBizzCar = new Car("1234567", date, true);
        }

        
        [TestMethod()]
        [DataRow("12345678")]
        [DataRow("99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999")]
        [DataRow("        ")]//8 spaces
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CarWithLongLicensePlateFailTest(string licensePlate)
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            Car longLicensePlate = new Car(licensePlate, date, false);
            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void CarWithNullLicensePlateFailTest()
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            Car nullLicensePlate = new Car(null, date, false);
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
       // [DataRow("12345678")] //This one was just to test that a car wouldn't be created if it had a long license plate
        public void CarWith7OrFewerCharLicensePlateTest(string licensePlate) //Testing that a car is created and can be added to the list
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            Car correctLicensePlate = new Car(licensePlate, date, false);
            List<Car> cars = new List<Car>();
            //Act
            cars.Add(correctLicensePlate);

            //Assert
            Assert.AreEqual(cars.Count, 1);
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

        //reason we have 2 different Fail Price tests is to easier identify if the price is incorrect above or below the asking price
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
        public void BroBizzPriceTest()
        {
            //Arrange

            //Act
            double expectedPrice = broBizzCar.Price();
            //Assert
            Assert.AreEqual(expectedPrice, 228);
        }

        [TestMethod()]
        public void FailBroBizzPriceIsBelow228Test()
        {
            //Arrange

            //Act
            double expectedPrice = broBizzCar.Price();
            //Assert
            Assert.IsFalse(expectedPrice < 228);
        }

        //reason we have 2 different Fail Price tests is to easier identify if the price is incorrect above or below the asking price
        [TestMethod()]
        public void FailBroBizzPriceIsabove228Test()
        {
            //Arrange

            //Act
            double expectedPrice = broBizzCar.Price();
            //Assert
            Assert.IsFalse(expectedPrice > 228);
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
        public void VehicleTypeIncorrectValueTest()
        {
            //Arrange

            //Act
            string expectedVehicleType = car.VehicleType();
            //Assert
            Assert.AreNotEqual(expectedVehicleType, "MC");
        }




        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CarDateIsinvalidTest()
        {
            //Arrange
            DateTime date = new DateTime(0, 0, 0);
            Car car = new Car("1234567", date, false);
            //Act

            //Assert
            Assert.Fail();
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CarDateIsEmptyTest()
        {
            //Arrange
            DateTime date = new DateTime();
            Car car = new Car("1234567", date, false);
            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CarDateIsMinimunTest()
        {
            //Arrange

            Car car = new Car("1234567", DateTime.MinValue, false);
            //Act

            //Assert
            Assert.Fail();
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CarDateIsMaxTest()
        {
            //Arrange

            Car car = new Car("1234567", DateTime.MaxValue, false);
            //Act

            //Assert
            Assert.Fail();
        }
    }
}