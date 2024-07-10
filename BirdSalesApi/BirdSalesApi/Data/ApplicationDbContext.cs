using Microsoft.EntityFrameworkCore;

namespace BirdSalesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {
            
        }

        public DbSet<Saller> Sallers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
