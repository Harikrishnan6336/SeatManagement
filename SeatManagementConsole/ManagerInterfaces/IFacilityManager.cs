using SeatManagementAPI.DTOs;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementConsole.Managers;
using SeatManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.ManagerInterfaces
{
    public interface IFacilityManager : IEntityManager<Facility>
    {
        List<FacilityViewDTO> GetNomenclature();
    }
}
