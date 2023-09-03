using SeatManagementDataAccess.Context;
using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementDataAccess.Implementation
{
    public class MeetingRoomAssetRepository : GenericRepository<MeetingRoomAsset>, IMeetingRoomAssetRepository
    {
        public MeetingRoomAssetRepository(SeatManagementDbContext context) : base(context)
        {
        }
    }
}
