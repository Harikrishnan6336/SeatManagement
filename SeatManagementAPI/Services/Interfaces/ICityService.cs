using SeatManagementDomain.Entities;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface ICityService
    {
        IEnumerable<City> GetCities();
        int AddCity(CityDTO cityDTO);
    }
}
