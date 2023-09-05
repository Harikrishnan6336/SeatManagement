using SeatManagementAPI.DTOs;
using SeatManagementConsole.APICalls;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Managers
{
    public class FacilityManager : EntityManager<Facility>, IFacilityManager
    {
        private readonly string _endPoint;

        public FacilityManager(string endPoint) : base(endPoint)
        {
            _endPoint = endPoint;
        }

        public List<FacilityViewDTO> GetNomenclature()
        {
            var newEndpoint = _endPoint + "/nomenclature";
            IApiCall<FacilityViewDTO> apiCall = new ApiCall<FacilityViewDTO>(newEndpoint);
            var list = apiCall.GetData();
            return list;
        }
    }
}
