// See https://aka.ms/new-console-template for more information
using Models.Northwind;

Console.WriteLine("Hello, World!");

using (var ctx = new NorthwindContext())
{
    var cat = ctx.Categories.ToList();
}

Console.WriteLine("Initial EF 6 is done!");