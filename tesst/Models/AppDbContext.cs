using Microsoft.EntityFrameworkCore;

namespace tesst.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public DbSet<SanPham> sanPhams { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ES0LE9K;Initial Catalog=baitest;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
