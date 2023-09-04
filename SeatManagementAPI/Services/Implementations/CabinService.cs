using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Services.Implementations
{
    public class CabinService: ICabinService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CabinService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Cabin> GetCabins()
        {
            return _unitOfWork.Cabin.GetAll();
        }
        public void AddCabin(CabinDTO cabinDTO)
        {
            var cabin = new Cabin()
            {
                Name = cabinDTO.Name,
                FacilityId = cabinDTO.FacilityId,
                EmployeeId = cabinDTO.EmployeeId
            };
            _unitOfWork.Cabin.Add(cabin);
            _unitOfWork.Commit();
        }

        public IEnumerable<Cabin> GetUnoccupiedCabins()
        {
            var cabinList = _unitOfWork.Cabin.GetAll();
            var unoccupiedCabinsList = new List<Cabin>();

            foreach (Cabin cabin in cabinList)
            {
                if (cabin.EmployeeId == null)
                {
                    unoccupiedCabinsList.Add(cabin);
                }
            }
            return unoccupiedCabinsList;
        }

        public void AllocateCabin(int CabinId, int EmployeeId)
        {
            var seat = _unitOfWork.Cabin.GetById(CabinId);
            seat.EmployeeId = EmployeeId;
            _unitOfWork.Commit();
        }
    }
}
