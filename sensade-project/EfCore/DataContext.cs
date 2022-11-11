using Microsoft.EntityFrameworkCore;

namespace sensade_project.EfCore
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ParkingArea> ParkingAreas { get; set; }

        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
    }
}
