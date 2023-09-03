using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Services.Implementations
{
    public class SeatService : ISeatService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeatService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddSeat(SeatDTO seatDTO)
        {
            var seat = new Seat()
            {
                Name = seatDTO.Name,
                FacilityId = seatDTO.FacilityId,
                EmployeeId = seatDTO.EmployeeId

            };
            _unitOfWork.Seat.Add(seat);
            _unitOfWork.Commit();
        }

        public IEnumerable<Seat> GetSeats()
        {
            return _unitOfWork.Seat.GetAll();
        }

        public void AllocateSeat(int SeatId, int EmployeeId)
        {
            var seat = _unitOfWork.Seat.GetById(SeatId);
            seat.EmployeeId = EmployeeId;
            _unitOfWork.Commit();
        }

        public void DeallocateSeat(int SeatId, int EmployeeId)
        {
            var seat = _unitOfWork.Seat.GetById(SeatId);
            if(seat != null) 
            { 
                seat.EmployeeId = null;
            }
            _unitOfWork.Commit();
        }
    }
}
