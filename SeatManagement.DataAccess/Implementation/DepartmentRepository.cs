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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(SeatManagementDbContext context) : base(context)
        {
        }
    }
}
