using StoreBaeltTicketLib;
using TicketSystemClassLibrary;

namespace StoreBaeltBroen.Managers
{
    public interface ITicketsManager
    {
        List<Vehicle> GetByLicensePlate(string LicensePlate);
        List<Vehicle> GetAll();
        StoreBaeltCar BuyTicketCar(StoreBaeltCar SBCar);
        MC BuyTicketMC(MC mc);
    }
}
