using SeatManagement.Handlers;
using SeatManagement.Interfaces;
using SeatManagement.Managers;
using SeatManagement.Menus;
using SeatManagementDomain.Entities;

public class Program
{
    public static void Main()
    {

        IEntityManager<City> cityManager = new EntityManager<City>("api/cities");
        IEntityManager<Building> buildingManager = new EntityManager<Building>("api/buildings");
        IEntityManager<Facility> facilityManager = new EntityManager<Facility>("api/facilities");

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
                OnboardFacilityHandler handler = new OnboardFacilityHandler(cityManager, buildingManager, facilityManager);
                handler.Handle();
                break;
            case '2':

                break;

        }
    }
}