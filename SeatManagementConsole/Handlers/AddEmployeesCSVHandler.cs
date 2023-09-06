using SeatManagementConsole.IOInterfaces;
using SeatManagementConsole.ManagerInterfaces;
using SeatManagementDomain.Entities;

namespace SeatManagementConsole.Handlers
{
    public class AddEmployeesCSVHandler : IHandler
    {
        private readonly IEntityManager<Employee> _employeeManager;
        private readonly IUserInputHandler _userInputHandler;
        public AddEmployeesCSVHandler(IEntityManager<Employee> employeeManager,
                                      IUserInputHandler userInputHandler)
        {
            _employeeManager = employeeManager;
            _userInputHandler = userInputHandler;
        }

        public int Handle()
        {
            string fileName = _userInputHandler.GetUserInputString("Enter the Name of the Employee list CSV file(in the CWD)");

            string path = $"{Environment.CurrentDirectory}\\{fileName}";
            Console.WriteLine(path);
            try
            {
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        Employee empObj = new Employee
                        {
                            Name = values[0],
                            DepartmentId = int.Parse(values[1])
                        };
                        _employeeManager.Add(empObj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            _userInputHandler.WaitForUserInput();
            return 0;
        }
    }
}
