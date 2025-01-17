﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Northwind
{
    internal class DropCreateDatabaseAlwaysInitializer : DropCreateDatabaseAlways<NorthwindContext>
    {
        protected override void Seed(NorthwindContext context)
        {
            SeedData.Seed(context);
            base.Seed(context);
        }
    }
}
