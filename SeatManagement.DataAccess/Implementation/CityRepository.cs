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
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(SeatManagementDbContext context) : base(context)
        {
        }
    }
}
