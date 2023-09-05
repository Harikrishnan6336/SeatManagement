using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeatManagementAPI.DTOs;
using SeatManagementConsole.APICalls;
using SeatManagementConsole.ManagerInterfaces;

namespace SeatManagementConsole.Managers
{
    public class ReportManager : IReportManager
    {
        private readonly IApiCall<ReportDTO> apiObj;
        public ReportManager(string ep)
        {
            apiObj = new ApiCall<ReportDTO>(ep);
        }
        public List<ReportDTO> GenerateReport()
        {
            return apiObj.GetData();
        }
    }
}
