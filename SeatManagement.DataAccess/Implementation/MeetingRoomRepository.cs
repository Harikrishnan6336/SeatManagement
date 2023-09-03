using SeatManagementDataAccess.Context;
using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement.DataAccess.Implementation
{
    public class MeetingRoomRepository : GenericRepository<MeetingRoom>, IMeetingRoomRepository
    {
        public MeetingRoomRepository(SeatManagementDbContext context) : base(context)
        {
        }
    }
}
