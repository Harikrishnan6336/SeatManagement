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
    public class SeatManager : EntityManager<Seat>, ISeatManager
    {
        private readonly string _endPoint;

        public SeatManager(string endPoint) : base(endPoint)
        {
            _endPoint = endPoint;
        }

        public List<Seat> GetUnoccupiedSeatsByFacility(int facilityId)
        {
            var newEndpoint = _endPoint + "/unoccupiedseats/" + facilityId;
            IApiCall<Seat> apiCall = new ApiCall<Seat>(newEndpoint);
            var list = apiCall.GetData();
            return list;
        }

        public List<Seat> GetUnoccupiedSeats()
        {
            var newEndpoint = _endPoint + "/unoccupiedseats";
            IApiCall<Seat> apiCall = new ApiCall<Seat>(newEndpoint);
            var list = apiCall.GetData();
            return list;
        }

        public void SeatAllocate(SeatAllocateDTO obj)
        {
            var newEndpoint = _endPoint + "/allocate";
            IApiCall<SeatAllocateDTO> apiCall = new ApiCall<SeatAllocateDTO>(newEndpoint);
            apiCall.PatchData(obj);
        }

        public void SeatDeallocate(SeatAllocateDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
