using Models.Northwind.Entities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Text;
using System.Linq;

namespace Models.Northwind.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<NorthwindContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;// allow loss data when Modify or remove a property on class domain
        }

        /// <summary>
        /// Uncomment always to run
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        protected override void Seed(NorthwindContext context)
        {
            if (System.Diagnostics.Debugger.IsAttached == false)
            {
                System.Diagnostics.Debugger.Launch();
            }

            // This method will be called after migrating to the latest version.
            var entityTypes = new List<Type>
            {
                typeof(Category),
                typeof(Customer),
                typeof(CustomerDemographic),
                typeof(Demographic),
                typeof(Employee),
                typeof(EmployeeTerritory),
                typeof(Order),
                typeof(OrderDetail),
                typeof(Product),
                typeof(Region),
                typeof(Shipper),
                typeof(Supplier),
                typeof(Territory)
            };

            var ns = typeof(Configuration).Assembly.FullName.Split(',')[0];
            var dataNS = $"{ns}.Data";
            foreach (var type in entityTypes)
            {
                var dataFile = $"{dataNS}.{type.Name.ToLower()}.json";
                var json = GetResource(dataFile);

                var listType = typeof(IEnumerable<>).MakeGenericType(type);

                var entities = JsonConvert.DeserializeObject(json, listType);
                /* only support add
                //var dbset = context.Set(type);                
                //dbset.AddRange(entities as IEnumerable);
                */

                // support add and update
                AddOrUpdate(context, type, entities as IEnumerable);
            }

            context.SaveChanges();
        }

        private void AddOrUpdate(NorthwindContext context, Type type, IEnumerable data)
        {
            switch (type.Name)
            {
                case nameof(Category):
                    context.Set<Category>().AddOrUpdate(data.Cast<Category>().ToArray());
                    break;
                case nameof(Customer):
                    context.Set<Customer>().AddOrUpdate(data.Cast<Customer>().ToArray());
                    break;
                case nameof(CustomerDemographic):
                    context.Set<CustomerDemographic>().AddOrUpdate(data.Cast<CustomerDemographic>().ToArray());
                    break;
                case nameof(Demographic):
                    context.Set<Demographic>().AddOrUpdate(data.Cast<Demographic>().ToArray());
                    break;
                case nameof(Employee):
                    context.Set<Employee>().AddOrUpdate(data.Cast<Employee>().ToArray());
                    break;
                case nameof(EmployeeTerritory):
                    context.Set<EmployeeTerritory>().AddOrUpdate(data.Cast<EmployeeTerritory>().ToArray());
                    break;
                case nameof(Order):
                    context.Set<Order>().AddOrUpdate(data.Cast<Order>().ToArray());
                    break;
                case nameof(OrderDetail):
                    context.Set<OrderDetail>().AddOrUpdate(data.Cast<OrderDetail>().ToArray());
                    break;
                case nameof(Product):
                    context.Set<Product>().AddOrUpdate(data.Cast<Product>().ToArray());
                    break;
                case nameof(Region):
                    context.Set<Region>().AddOrUpdate(data.Cast<Region>().ToArray());
                    break;
                case nameof(Shipper):
                    context.Set<Shipper>().AddOrUpdate(data.Cast<Shipper>().ToArray());
                    break;
                case nameof(Supplier):
                    context.Set<Supplier>().AddOrUpdate(data.Cast<Supplier>().ToArray());
                    break;
                case nameof(Territory):
                    context.Set<Territory>().AddOrUpdate(data.Cast<Territory>().ToArray());
                    break;
            }
        }

        private string GetResource(string resourceName)
        {
            var result = string.Empty;
            var assembly = typeof(Configuration).Assembly;

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream, Encoding.GetEncoding("iso-8859-1")))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
