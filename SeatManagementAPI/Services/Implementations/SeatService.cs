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

        public int AddSeat(SeatDTO seatDTO)
        {
            var seat = new Seat()
            {
                Name = seatDTO.Name,
                FacilityId = seatDTO.FacilityId,
                EmployeeId = seatDTO.EmployeeId

            };
            _unitOfWork.Seat.Add(seat);
            _unitOfWork.Commit();
            return seat.Id;
        }

        public IEnumerable<Seat> GetSeats()
        {
            return _unitOfWork.Seat.GetAll();
        }

        public IEnumerable<Seat> GetUnoccupiedSeatsByFacility(int facilityId)
        {
            var seatList = _unitOfWork.Seat.GetAll();
            var unoccupiedSeatByFacilityList = new List<Seat>();

            foreach (Seat seat in seatList)
            {
                if (seat.EmployeeId == null && seat.FacilityId == facilityId)
                {
                    unoccupiedSeatByFacilityList.Add(seat);
                }
            }
            return unoccupiedSeatByFacilityList;
        }

        public IEnumerable<Seat> GetUnoccupiedSeats()
        {
            var seatList = _unitOfWork.Seat.GetAll();
            var unoccupiedSeatByFacilityList = new List<Seat>();

            foreach (Seat seat in seatList)
            {
                if (seat.EmployeeId == null)
                {
                    unoccupiedSeatByFacilityList.Add(seat);
                }
            }
            return unoccupiedSeatByFacilityList;
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
