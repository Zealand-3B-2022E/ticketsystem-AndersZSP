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
    public class OresundMCTests
    {

        private OresundMC OMC;
        private OresundMC broBizzOMC;
        [TestInitialize]
        public void BeforeEachTest()
        {
            OMC = new OresundMC();
            DateTime date = new DateTime(2022, 12, 25);
            broBizzOMC = new OresundMC("1234567", date, true);
        }





        [TestMethod()]
        [DataRow("12345678")]
        [DataRow("99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OresundMCWithLongLicensePlateFailTest(string licensePlate)
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            OresundMC longLicensePlate = new OresundMC(licensePlate, date, false);
            //Act

            //Assert
            Assert.Fail();
        }


        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void OresundMCWithNullLicensePlateFailTest()
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            OresundMC nullLicensePlate = new OresundMC(null, date, false);
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
        public void OresundMCWith7OrFewerCharLicensePlateTest(string licensePlate) //Testing that a MC is created and can be added to the list
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            OresundMC correctLicensePlate = new OresundMC(licensePlate, date, false);
            List<OresundMC> OMCs = new List<OresundMC>();
            OMCs.Add(correctLicensePlate);
            //Act

            //Assert
            Assert.AreEqual(OMCs.Count, 1);
        }





        [TestMethod()]
        public void OresundMCPriceTest()
        {
            //Arrange
            // Tom grundet TestInitialize

            //Act
            double expectedPrice = OMC.Price();
            //Assert
            Assert.AreEqual(expectedPrice, 210);
        }

        [TestMethod()]
        public void FailPriceIsBelow210Test()
        {
            //Arrange

            //Act
            double expectedPrice = OMC.Price();
            //Assert
            Assert.IsFalse(expectedPrice < 210);
        }
        //reason we have 2 different Fail Price tests is to easier identify if the price is incorrect above or below the asking price
        [TestMethod()]
        public void FailPriceIsabove210Test()
        {
            //Arrange

            //Act
            double expectedPrice = OMC.Price();
            //Assert
            Assert.IsFalse(expectedPrice > 210);
        }




        [TestMethod()]
        public void BroBizzPriceTest()
        {
            //Arrange

            //Act
            double expectedPrice = broBizzOMC.Price();
            //Assert
            Assert.AreEqual(expectedPrice, 73); 
        }

        [TestMethod()]
        public void FailBroBizzPriceIsBelow73Test()
        {
            //Arrange

            //Act
            double expectedPrice = broBizzOMC.Price();
            //Assert
            Assert.IsFalse(expectedPrice < 73);
        }


        [TestMethod()]
        public void FailBroBizzPriceIsabove73Test()
        {
            //Arrange

            //Act
            double expectedPrice = broBizzOMC.Price();
            //Assert
            Assert.IsFalse(expectedPrice > 73);
        }



        [TestMethod()]
        public void VehicleTypeTest()
        {
            //Arrange

            //Act
            string expectedVehicleType = OMC.VehicleType();
            //Assert
            Assert.AreEqual(expectedVehicleType, "Oresund MC");
        }
        [TestMethod()]
        public void VehicleTypeIncorrectValueTest()
        {
            //Arrange

            //Act
            string expectedVehicleType = OMC.VehicleType();
            //Assert
            Assert.AreNotEqual(expectedVehicleType, "Oresund Car");
        }





        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OresundMCDateIsinvalidTest()
        {
            //Arrange
            DateTime date = new DateTime(0, 0, 0);
            OresundMC omc = new OresundMC("1234567", date, false);
            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OresundMCDateIsEmptyTest()
        {
            //Arrange
            DateTime date = new DateTime();
            OresundMC omc = new OresundMC("1234567", date, false);
            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OresundMCDateIsMinimunTest()
        {
            //Arrange

            OresundMC OMC = new OresundMC("1234567", DateTime.MinValue, false);
            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OresundMCDateIsMaxTest()
        {
            //Arrange

            OresundMC OMC = new OresundMC("1234567", DateTime.MaxValue, false);
            //Act

            //Assert
            Assert.Fail();
        }

        /// <summary>
        /// Testing that an OresundMC can be used as a MC
        /// </summary>
        [TestMethod]
        public void OresundMCPolymorphismWorksTest()
        {
            //Arrange
            DateTime date = new DateTime(2022, 12, 25);
            OresundMC correctLicensePlate = new OresundMC("1234567", date, false);
            List<MC> MCs = new List<MC>();
            //Act
            MCs.Add(correctLicensePlate);
            //Assert
            Assert.AreEqual(MCs.Count, 1);

        }
    }
}