using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeatManagementConsole.ManagerInterfaces;

namespace SeatManagementConsole.Managers
{
    public class ReportManager<T> : IReportManager<T> where T : class
    {
        private readonly IApiCall<T> apiObj;
        public ReportManager(string ep)
        {
            apiObj = new ApiCall<T>(ep);
        }
        public List<T> GenerateReport()
        {
            return apiObj.GetData();
        }
    }
}
