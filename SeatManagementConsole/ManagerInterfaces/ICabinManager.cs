using SeatManagementAPI.DTOs;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.ManagerInterfaces
{
    public interface ICabinManager: IEntityManager<Cabin>
    {
        List<Cabin> GetUnoccupiedCabins();
        void CabinAllocate(CabinAllocateDTO obj);

        void CabinDeallocate(CabinAllocateDTO obj);
    }
}
