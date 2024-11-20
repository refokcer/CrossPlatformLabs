using Lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<CustomerStatus> CustomerStatuses { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<PartInOrder> PartsInOrders { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<PartSupplier> PartSuppliers { get; set; }
    public DbSet<Part> Parts { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<PartMaker> PartMakers { get; set; }
    public DbSet<CarManufacturer> CarManufacturers { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<PartsForCar> PartsForCars { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PartsForCar>()
            .HasKey(pfc => new { pfc.PartId, pfc.CarId });

        modelBuilder.Entity<PartSupplier>()
            .HasKey(ps => new { ps.PartId, ps.SupplierNr });

        base.OnModelCreating(modelBuilder);
    }
}
