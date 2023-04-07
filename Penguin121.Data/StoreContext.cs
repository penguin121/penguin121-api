using Microsoft.EntityFrameworkCore;
using Penguin121.Domain.Catalog;

namespace Penguin121.Data {
    public class StoreContext : DbContext {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }

        public DbSet<Item> Items {get; set; }
        public DbSet<Order> Orders{get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);
           DbInitializer.Initialize(builder);
        }
    }
}
