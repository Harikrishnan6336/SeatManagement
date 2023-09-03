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
    public class CabinRepository : GenericRepository<Cabin>, ICabinRepository
    {
        public CabinRepository(SeatManagementDbContext context) : base(context)
        {
        }
    }
}
