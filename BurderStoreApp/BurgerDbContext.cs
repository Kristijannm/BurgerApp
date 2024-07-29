using BurgerApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BurgerStoreApp
{
    public class BurgerDbContext : DbContext
    {

        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public BurgerDbContext(DbContextOptions<BurgerDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Burger)
                .WithMany(b => b.Orders)
                .HasForeignKey(o => o.BurgerId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
