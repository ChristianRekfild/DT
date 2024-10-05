using DT.Model.Data;
using DT.Model.Data.Location;
using Microsoft.EntityFrameworkCore;

namespace DT.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // без этой строки у нас поля типа datetime будут создаваться с timezone, что рушит нафиг всю работу
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
