using SeatManagementDomain.Entities;

namespace SeatManagementConsole.IOImplementations
{
    public static class DisplayList
    {
        public static void DisplayEntityList<T>(List<T> entities) where T : IEntity 
        {
            foreach (var ent in entities)
            {
                Console.WriteLine($"{ent.Id}. {ent.Name}");
            }
        }
    }
}

