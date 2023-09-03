using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement
{
    public interface IApiCall<T>
    {
        List<T> GetData();

        int PostData(T data);

        void PutData(T data);
    }
}
