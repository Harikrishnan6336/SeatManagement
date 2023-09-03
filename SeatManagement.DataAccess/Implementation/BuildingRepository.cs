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
    internal class BuildingRepository : GenericRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(SeatManagementDbContext context) : base(context)
        {
        }
    }
}
