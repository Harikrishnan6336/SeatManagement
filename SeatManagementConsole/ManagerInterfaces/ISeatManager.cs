using SeatManagementAPI.DTOs;
using SeatManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.ManagerInterfaces
{
    public interface ISeatManager : IEntityManager<Seat>
    {
        List<Seat> GetUnoccupiedSeatsByFacility(int facilityId);
        List<Seat> GetUnoccupiedSeats();
        void SeatAllocate(SeatAllocateDTO obj);

        void SeatDeallocate(SeatAllocateDTO obj);
    }
}
