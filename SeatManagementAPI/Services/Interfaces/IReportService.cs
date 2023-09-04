using SeatManagementAPI.DTOs;
using SeatManagementDomain.Entities;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface IReportService
    {
        List<ReportDTO> Get();

        //List<UnallocatedViewModel> GetUnallocatedList();
    }
}
