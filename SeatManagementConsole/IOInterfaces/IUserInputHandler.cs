using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.IOInterfaces
{
    public interface IUserInputHandler
    {
        int GetUserInputInt(string message);
        void WaitForUserInput();

    }
}
