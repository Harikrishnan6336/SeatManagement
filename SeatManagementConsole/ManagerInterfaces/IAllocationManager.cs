using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.ManagerInterfaces
{
    public interface IAllocationManager<T> where T : class
    {
        void Add();

        void Allocate(T obj);

        void Deallocate(T obj);
    }
}
