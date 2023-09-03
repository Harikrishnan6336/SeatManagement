using System.ComponentModel.DataAnnotations;

namespace SeatManagementDomain.Entities
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
