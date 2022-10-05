using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBaeltTicketLib;
using StoreBaeltTicketLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemClassLibrary;

namespace StoreBaeltTicketLibrary.Tests
{
    [TestClass()]
    public class StoreBaeltCarTests
    {


        /// <summary>
        /// Test SBCar price on weekedays with BroBizz
        /// </summary>
        /// <param name="DayOfWeek">Monday-friday</param>
        [TestMethod()]
        [DataRow(3)] //Monday-friday of october
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        public void PriceWeekdayWithBroBizzTest(int DayOfWeek)
        {
            //Arrange
            DateTime date = new DateTime(2022, 10, DayOfWeek);
            StoreBaeltCar car = new StoreBaeltCar("1234567", date, true);
            //Act
            double expectedPrice = car.Price();

            //Assert
            Assert.AreEqual(expectedPrice, 228);
        }

        //Test SBCar price on weekdays without BroBizz
        [TestMethod()]
        [DataRow(3)] //Monday-friday of october
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        public void PriceWeekdayWithoutBroBizzTest(int DayOfWeek)
        {
            //Arrange
            DateTime date = new DateTime(2022, 10, DayOfWeek);
            StoreBaeltCar car = new StoreBaeltCar("1234567", date, false);
            //Act
            double expectedPrice = car.Price();

            //Assert
            Assert.AreEqual(expectedPrice, 240);
        }

        //Test SBCar price on weekends with BroBizz
        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)] //1 and 2 of october 2022 are saturday and sunday
        public void PriceWeekendWithBroBizzTest(int DayOfWeek)
        {
            //Arrange
            DateTime date = new DateTime(2022, 10, DayOfWeek);
            StoreBaeltCar car = new StoreBaeltCar("1234567", date, true);
            //Act
            double expectedPrice = car.Price();

            //Assert
            Assert.AreEqual(expectedPrice, 182.4, 0.001);
        }

        //Test SBCar price on weekends without BroBizz
        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void PriceWeekendWithoutBroBizzTest(int DayOfWeek)
        {
            //Arrange
            DateTime date = new DateTime(2022, 10, DayOfWeek);
            StoreBaeltCar car = new StoreBaeltCar("1234567", date, false);
            //Act
            double expectedPrice = car.Price();

            //Assert
            Assert.AreEqual(expectedPrice, 192, 0.001);
        }





        //Test that SBCar date can't be invalid
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StoreBaeltCarDateIsinvalidTest()
        {
            //Arrange
            DateTime date = new DateTime(0, 0, 0);
            StoreBaeltCar car = new StoreBaeltCar("1234567", date, false);
            //Act

            //Assert
            Assert.Fail();
        }

        //Test that SBCar date can't be empty
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StoreBaeltCarDateIsEmptyTest()
        {
            //Arrange
            DateTime date = new DateTime();
            StoreBaeltCar car = new StoreBaeltCar("1234567", date, false);
            //Act

            //Assert
            Assert.Fail();
        }

        //Test that SBCar date can't be min
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StoreBaeltCarDateIsMinimunTest()
        {
            //Arrange

            StoreBaeltCar car = new StoreBaeltCar("1234567", DateTime.MinValue, false);
            //Act

            //Assert
            Assert.Fail();
        }

        //Test that SBCar date can't be max
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StoreBaeltCarDateIsMaxTest()
        {
            //Arrange

            StoreBaeltCar car = new StoreBaeltCar("1234567", DateTime.MaxValue, false);
            //Act

            //Assert
            Assert.Fail();
        }




        //Test that VehicleType works on SBCar
        [TestMethod]
        public void VehicleTypeTest()
        {
            //Arrange
            StoreBaeltCar car = new StoreBaeltCar();
            //Act
            string carType = car.VehicleType();
            //Assert
            Assert.AreEqual(carType, "Car");
        }



        //Test that StoreBaeltCar can't create objects with license plates longer than 8 char
        [TestMethod()]
        [DataRow("12345678")]
        [DataRow("99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999")]
        [DataRow("        ")]//8 spaces
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StoreBaeltCarWithLongLicensePlateFailTest(string licensePlate)
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            StoreBaeltCar longLicensePlate = new StoreBaeltCar(licensePlate, date, false);
            //Act

            //Assert
            Assert.Fail();
        }

        //Test that StoreBaeltCar can't be created with a null license plate
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void StoreBaeltCarWithNullLicensePlateFailTest()
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            StoreBaeltCar nullLicensePlate = new StoreBaeltCar(null, date, false);
            //Act

            //Assert
            Assert.IsNull(nullLicensePlate);
        }



        //Test that StoreBaeltCar can create objects with 7 or fewer characters
        [TestMethod()]
        [DataRow("1234567")]
        [DataRow("123456")]
        [DataRow("abcdefg")]
        [DataRow("abcdef")]
        [DataRow("A")]
        [DataRow("       ")]//7 spaces
        [DataRow("")]
        public void StoreBaeltCarWith7OrFewerCharLicensePlateTest(string licensePlate) //Testing that a SBcar is created and can be added to the list
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            StoreBaeltCar correctLicensePlate = new StoreBaeltCar(licensePlate, date, false);
            List<StoreBaeltCar> cars = new List<StoreBaeltCar>();
            //Act
            cars.Add(correctLicensePlate);
            //Assert
            Assert.AreEqual(cars.Count, 1);
        }

        //Test that StoreBaeltCar works as a Car object
        [TestMethod]
        public void StoreBaeltCarPolymorphismWorksTest()
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            StoreBaeltCar correctLicensePlate = new StoreBaeltCar("1234567", date, false);
            List<Car> cars = new List<Car>();
            //Act
            cars.Add(correctLicensePlate);
            //Assert
            Assert.AreEqual(cars.Count, 1);

        }




        //Test that StoreBaelt can create MC objects
        [TestMethod]
        public void StoreBaeltMC()
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            MC mc = new MC("1234567", date, false);
            //Act
            List<MC> MCs = new List<MC>();
            //Act
            MCs.Add(mc);
            //Assert
            Assert.AreEqual(MCs.Count, 1);
        }
    }
}