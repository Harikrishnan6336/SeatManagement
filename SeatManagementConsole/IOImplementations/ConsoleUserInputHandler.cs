using SeatManagementConsole.IOInterfaces;

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

        public string GetUserInputString(string message)
        {
            string userInput;
            do
            {
                Console.Write($"{message} ");
                userInput = Console.ReadLine()!;
            } while (string.IsNullOrEmpty(userInput));
            return userInput;
        }

        public void WaitForUserInput()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
