using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.EfDataAccess
{
    public class CameraShopDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<CameraImage> CameraImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SensorType> SensorTypes { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockPlace> StockPlaces { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }

        public CameraShopDbContext()
        {

        }
        public CameraShopDbContext(DbContextOptions opt) : base(opt)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=VANJA-PC\MSSQLSERVER01;Initial Catalog=ASP_Projekat;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<Brand>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<Camera>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<CameraImage>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<Cart>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<CartItem>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<Discount>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<Order>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<Role>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<SensorType>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<Stock>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<StockPlace>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<UseCase>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<UseCaseLog>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<User>().HasQueryFilter(x => x.IsActive);
            modelBuilder.Entity<UserUseCase>().HasQueryFilter(x => x.IsActive);

            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Deleted:
                            e.DeletedAt = DateTime.UtcNow;
                            e.IsActive = false;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

       
    }
}

