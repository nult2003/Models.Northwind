using Models.Northwind.Entities;
using Models.Northwind.Migrations;
using System.Data.Entity;

namespace Models.Northwind
{
    /// <summary>
    /// The Northwind context.
    /// </summary>
    public partial class NorthwindContext : DbContext
    {
        /// <summary>
        /// Initializes static members of the <see cref="NorthwindContext"/> class.
        /// </summary>
        static NorthwindContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NorthwindContext"/> class.
        /// initializer and migration don't work together (https://stackoverflow.com/questions/19430502/dropcreatedatabaseifmodelchanges-ef6-results-in-system-invalidoperationexception)
        /// </summary>
        public NorthwindContext() : base("Northwind")
        {
            //Disable initializer
            //Database.SetInitializer<NorthwindContext>(null);

            // Automate migrations https://www.entityframeworktutorial.net/code-first/automated-migration-in-code-first.aspx
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NorthwindContext, Migrations.Configuration>());

            // === work for setup new machine on production environment
            //Database.SetInitializer<NorthwindContext>(new CreateDatabaseIfNotExistsInitializer());

            // Support for Testing/Development Environment (don't have any connection to the database)
            //Database.SetInitializer<NorthwindContext>(new DropCreateDatabaseIfModelChangesInitializer());            
            //Database.SetInitializer<NorthwindContext>(new DropCreateDatabaseAlwaysInitializer());            
        }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the customer demographics.
        /// </summary>
        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the demographics.
        /// </summary>
        public DbSet<Demographic> Demographics { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the employee territories.
        /// </summary>
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        public DbSet<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the regions.
        /// </summary>
        public DbSet<Region> Regions { get; set; }

        /// <summary>
        /// Gets or sets the shippers.
        /// </summary>
        public DbSet<Shipper> Shippers { get; set; }

        /// <summary>
        /// Gets or sets the suppliers.
        /// </summary>
        public DbSet<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Gets or sets the territories.
        /// </summary>
        public DbSet<Territory> Territories { get; set; }
    }
}
