using SeatManagementConsole.APICalls;
using SeatManagementConsole.ManagerInterfaces;

namespace SeatManagementConsole.Managers
{
    public class EntityManager<T> : IEntityManager<T> where T : class
    {
        private readonly IApiCall<T> _apiCall;
        public EntityManager(string endPoint) 
        { 
            _apiCall = new ApiCall<T>(endPoint);
        }
        public List<T> Get()
        {
            var list = _apiCall.GetData();
            return list;
        }
        public int Add(T obj)
        {
            int ret =  _apiCall.PostData(obj);
            return ret;
        }
    }
}

