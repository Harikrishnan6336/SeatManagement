using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement.Interfaces
{
    public interface IAllocationManager<T> where T : class
    {
        void Add();

        void Allocate(T obj);

        void Deallocate(T obj);
    }
}
