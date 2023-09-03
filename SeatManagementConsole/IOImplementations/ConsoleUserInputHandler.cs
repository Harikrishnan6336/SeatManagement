using SeatManagementConsole.IOInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.IOImplementations
{
    public class ConsoleUserInputHandler : IUserInputHandler
    {
        public int GetUserInputInt(string message)
        {
            int userInput;
            do
            {
                Console.Write($"{message} ");
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        public void WaitForUserInput()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
