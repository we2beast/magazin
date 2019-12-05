using System.Data.Entity;
using BusinessLayer.Domain;

namespace DataLayer
{
    public class EFDBContex : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        static EFDBContex()
        {
            Database.SetInitializer<EFDBContex>(new EFDBInitializer());
        }
        public EFDBContex() : base("EFDBContexString")
        {
        }
    }
}
