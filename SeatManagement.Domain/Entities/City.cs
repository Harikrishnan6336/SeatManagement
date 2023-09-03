using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeatManagementDomain.Entities
{
    [Index(nameof(City.Abbreviation), IsUnique = true)]
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
    }
}
