using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement.Menus
{
    public class MainMenu : IMenu
    {
        public void Show()
        {

            Console.WriteLine("----------------------SEAT ALLOCATION MANAGER-------------------------");
            Console.WriteLine("MENU");
            Console.WriteLine("[1].Onboard Facility\n[2].Onboard Seats\n[3].Onboard Meeting Rooms\n[4].Onboard Cabins\n[5].Add Employees\n[6].Seat Allocation\n[7].Seat Deallocation\n[8].Report Generation");
            Console.Write("Choose your option: ");

            char mainMenuOption = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.Clear();
            switch (mainMenuOption)
            {
                case '1':
                  //  OnboardFacilityHandler handler = new OnboardFacilityHandler(cityManager, buildingManager, facilityManager);
                  //  handler.Handle();
                    break;
            }
        }
    }

}






