//using SeatManagementDomain.Entities;
//using SeatManagementDomain.Repository;
//using SeatManagementAPI.Services.Interfaces;

//namespace SeatManagementAPI.Services.Implementations
//{
//    public class ReportService : IReportService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public ReportService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        public List<Overview> GetAllocatedList()
//        {
//            var item = _unitOfWork.Overview.GetAll();
//            Console.WriteLine(item);
//            if (item.Any() == false)
//            {
//                throw new Exception("Cannot generate report");
//            }
//            else return (List<Overview>)item;
//        }
//        public List<UnallocatedViewModel> GetUnallocatedList()
//        {
//            var item = _unitOfWork.UnallocatedViewModel.GetAll();
//            Console.WriteLine("Hello");
//            Console.WriteLine(item);
//            if (item.Any() == false)
//            {
//                throw new Exception("Cannot generate report");
//            }
//            else return (List<UnallocatedViewModel>)item;
//        }
//    }
//}