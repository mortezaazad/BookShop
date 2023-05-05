using BookShop.Infrastracture.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace BookShop.Infrastracture
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BookData> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookData>().HasData(new BookData {
                Id= 1,
                Name ="Asp.net Core in Action" , 
                Description = "In ASP.NET Core in Action, Third Edition Microsoft MVP Andrew Lock teaches you how you can use your C# and .NET skills to build amazing cross-platform web applications. This revised bestseller reveals the latest .NET patterns, including minimal APIs and minimal hosting. Even if you've never worked with ASP.NET, you'll start creating productive cross-platform web apps fast.",
                Author= "Andrew Lock",
                Pages= 750,
                Price= 50 ,
                Year= 2023
            });
            base.OnModelCreating(builder);
        }
    }
}