using SeatManagementAPI.DTOs;

namespace SeatManagementConsole.ManagerInterfaces
{
    public interface IReportManager
    {
        List<ReportDTO> GenerateReport();
    }
}
