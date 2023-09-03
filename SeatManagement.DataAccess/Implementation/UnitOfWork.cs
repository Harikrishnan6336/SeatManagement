using SeatManagementDataAccess.Implementation;
using SeatManagementDataAccess.Context;
using SeatManagementDomain.Repository;

namespace SeatManagementDataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SeatManagementDbContext _reportService;
        public IAssetRepository Asset { get; private set; }
        public IBuildingRepository Building { get; private set; }
        public ICityRepository City { get; private set; }
        public ICabinRepository Cabin { get; private set; }
        public IDepartmentRepository Department { get; private set; }
        public IEmployeeRepository Employee { get; private set; }
        public IFacilityRepository Facility { get; private set; }
        public IMeetingRoomRepository MeetingRoom { get; private set; }
        public IMeetingRoomAssetRepository MeetingRoomAsset { get; private set; }
        public ISeatRepository Seat { get; private set; }

        public UnitOfWork(SeatManagementDbContext context)  
        { 
            _reportService = context;
            Asset = new AssetRepository(context);
            Building = new BuildingRepository(context);
            City = new CityRepository(context);
            Cabin = new CabinRepository(context);
            Department = new DepartmentRepository(context);
            Employee = new EmployeeRepository(context);
            Facility = new FacilityRepository(context);
            MeetingRoom = new MeetingRoomRepository(context);
            MeetingRoomAsset = new MeetingRoomAssetRepository(context);
            Seat = new SeatRepository(context);
        }

        public int Commit()
        {
            return _reportService.SaveChanges();
        }

        public void Dispose()
        {
            _reportService.Dispose();
        }
    }
}
