using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Northwind
{
    internal class CreateDatabaseIfNotExistsInitializer : CreateDatabaseIfNotExists<NorthwindContext>
    {
        protected override void Seed(NorthwindContext context)
        {
            base.Seed(context);
        }
    }
}
