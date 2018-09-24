using Microsoft.EntityFrameworkCore;

namespace SmallestNumberTrifon.Model
{
    public class SimpleNumberContext : DbContext
    {
        public SimpleNumberContext(DbContextOptions<SimpleNumberContext> options)
            : base(options)
        {
        }

        public DbSet<Settings.Settings> Settingses { get; set; }
        public DbSet<Calculate.Calculate> Calculates { get; set; }
       
    }
}
