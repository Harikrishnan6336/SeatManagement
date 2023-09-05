using SeatManagementAPI.DTOs;
using SeatManagementConsole.APICalls;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Managers
{
    public class CabinManager : EntityManager<Cabin>, ICabinManager
    {
        private readonly string _endPoint;

        public CabinManager(string endPoint) : base(endPoint)
        {
            _endPoint = endPoint;
        }
        public void CabinAllocate(CabinAllocateDTO obj)
        {
            var newEndpoint = _endPoint + "/allocate";
            IApiCall<CabinAllocateDTO> apiCall = new ApiCall<CabinAllocateDTO>(newEndpoint);
            apiCall.PatchData(obj);
        }

        public void CabinDeallocate(CabinAllocateDTO obj)
        {
            throw new NotImplementedException();
        }

        public List<Cabin> GetUnoccupiedCabins()
        {
            var newEndpoint = _endPoint + "/unoccupiedcabins";
            IApiCall<Cabin> apiCall = new ApiCall<Cabin>(newEndpoint);
            var list = apiCall.GetData();
            return list;
        }
    }
}
