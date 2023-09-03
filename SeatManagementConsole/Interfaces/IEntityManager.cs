using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement.Interfaces
{
    public interface IEntityManager<T> where T : class
    {
        public List<T> Get();
        public int Add(T obj);
    }
}
