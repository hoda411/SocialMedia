using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class Mydbcontext:DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog =testdatabase; Integrated Security = True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(e => e.email).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
