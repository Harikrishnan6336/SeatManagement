using Microsoft.EntityFrameworkCore;
using SeatManagementDomain.Entities;

namespace SeatManagementDataAccess.Context
{
    public class SeatManagementDbContext : DbContext
    {
        public SeatManagementDbContext(DbContextOptions<SeatManagementDbContext> options) : base(options) { }


        public DbSet<Asset>? Assets { get; set; }
        public DbSet<Building>? Buildings { get; set; }
        public DbSet<Cabin>? Cabins { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Facility>? Facilities { get; set; }
        public DbSet<MeetingRoom>? MeetingRooms { get; set; }
        public DbSet<MeetingRoomAsset>? MeetingRoomAssets { get; set; }
        public DbSet<Seat>? Seats { get; set; }
    }


}
