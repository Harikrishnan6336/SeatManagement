using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SeatManagementDomain.Entities
{
    [Index(nameof(Building.Abbreviation), IsUnique = true)]
    public class Building
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
    }
}
