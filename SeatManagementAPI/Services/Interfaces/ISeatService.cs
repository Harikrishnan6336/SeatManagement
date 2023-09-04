using SeatManagementDomain.Entities;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface ISeatService
    {
        IEnumerable<Seat> GetSeats();
        IEnumerable<Seat> GetUnoccupiedSeatsByFacility(int facilityId);
        IEnumerable<Seat> GetUnoccupiedSeats();

        int AddSeat(SeatDTO seatDTO);
        void AllocateSeat(int SeatId, int EmployeeId);
        void DeallocateSeat(int SeatId, int EmployeeId);
    }
}
