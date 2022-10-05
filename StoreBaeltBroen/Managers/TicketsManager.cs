using StoreBaeltTicketLib;
using TicketSystemClassLibrary;

namespace StoreBaeltBroen.Managers
{
    public class TicketsManager: ITicketsManager
    {
        //Weekend
        static DateTime saturday = new DateTime(2022, 10, 1);

        //Week day
        static DateTime tuesday = new DateTime(2022, 10, 4);
        private static List<Vehicle> TicketList = new List<Vehicle>()
        {

            new StoreBaeltCar("1234567",saturday,true),
            new StoreBaeltCar("1234567",tuesday,true),
            new StoreBaeltCar("abcdefg",saturday,false),
            new StoreBaeltCar("abcdefg",tuesday,false),
            new StoreBaeltCar("A1B2C3D",tuesday,true),
            new StoreBaeltCar("45DE67F",tuesday,false),

            new MC("VR00MVR",saturday,true),
            new MC("B1GCycl",tuesday,false),
            //No need to test MC for weekend, since it doesn't get discount, so we only create 2 MC tickets
        };

        public TicketsManager()
        {

        }

        public List<Vehicle> GetByLicensePlate(string LicensePlate)
        {
            if (LicensePlate == null)
            {
                throw new ArgumentNullException();
            }
            if (!TicketList.Exists(vehicle => vehicle.LicensePlate == LicensePlate))
            {
                throw new KeyNotFoundException();
            }
            return TicketList.FindAll(vehicle => vehicle.LicensePlate == LicensePlate);
        }

        public List<Vehicle> GetAll()
        {
            return new List<Vehicle>(TicketList);
        }

        public StoreBaeltCar BuyTicketCar(StoreBaeltCar SBCar)
        {
            if (SBCar == null)
            {
                throw new ArgumentNullException();
            }
            if (SBCar.LicensePlate.Length > 7)
            {
                throw new ArgumentOutOfRangeException("License plate must be 7 or fewer characters");
            }
            if (SBCar.Date == DateTime.MinValue || SBCar.Date == DateTime.MaxValue)
            {
                throw new ArgumentOutOfRangeException("Please fill in a date");
            }
            TicketList.Add(SBCar);
            return SBCar;
        }

        public MC BuyTicketMC(MC mc)
        {
            if (mc == null)
            {
                throw new ArgumentNullException();
            }
            if (mc.LicensePlate.Length > 7)
            {
                throw new ArgumentOutOfRangeException("License plate must be 7 or fewer characters");
            }
            if (mc.Date == DateTime.MinValue || mc.Date == DateTime.MaxValue)
            {
                throw new ArgumentOutOfRangeException("Please fill in a date");
            }
            TicketList.Add(mc);
            return mc;
        }
    }
}
