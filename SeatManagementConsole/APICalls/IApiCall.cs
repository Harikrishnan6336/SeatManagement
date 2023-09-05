using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.APICalls
{
    public interface IApiCall<T>
    {
        List<T> GetData();

        int PostData(T data);

        void PutData(T data);

        void PatchData(T data);

    }
}
