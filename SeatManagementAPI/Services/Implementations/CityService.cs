using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int AddCity(CityDTO cityDTO)
        {
            var city = new City()
            {
                Name = cityDTO.Name,
                Abbreviation = cityDTO.Abbreviation
            };
            _unitOfWork.City.Add(city);
            _unitOfWork.Commit();
           return city.Id;
        }

        public IEnumerable<City> GetCities()
        {
            return _unitOfWork.City.GetAll();
        }
    }
}
