

namespace SeatManagementDomain.Repository
{
    public interface IUnitOfWork 
    {
        IAssetRepository Asset { get;  }
        IBuildingRepository Building { get; }
        ICabinRepository Cabin { get; }

        ICityRepository City { get; }

        IDepartmentRepository Department { get; }

        IEmployeeRepository Employee { get; }

        IFacilityRepository Facility { get; }

        IMeetingRoomRepository  MeetingRoom { get; }

        IMeetingRoomAssetRepository MeetingRoomAsset { get; }

        ISeatRepository Seat { get; }

        int Commit();
    }

}
