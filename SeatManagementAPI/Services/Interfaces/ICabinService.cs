using SeatManagementDomain.Entities;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface ICabinService
    {
        IEnumerable<Cabin> GetCabins();
        void AddCabin(CabinDTO cabinDTO);
    }
}
