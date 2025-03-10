using System.Data.Entity;

namespace VehicleLease.Models
{
    public class VehicleLeaseDbContext : DbContext
    {
        public VehicleLeaseDbContext() : base("DatabaseConnection")
        { }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<CompanyBranch> CompanyBranches { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
