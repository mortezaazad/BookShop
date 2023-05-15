using BookShop.Infrastracture.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace BookShop.Infrastracture
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BookData> Books { get; set; }
        public DbSet<BookCategory> Categories { get; set; }
        public DbSet<OrderData> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<BookData>().HasData(new BookData {
            //    Id= 1,
            //    Name ="Asp.net Core in Action" , 
            //    Description = "In ASP.NET Core in Action, Third Edition Microsoft MVP Andrew Lock teaches you how you can use your C# and .NET skills to build amazing cross-platform web applications. This revised bestseller reveals the latest .NET patterns, including minimal APIs and minimal hosting. Even if you've never worked with ASP.NET, you'll start creating productive cross-platform web apps fast.",
            //    Author= "Andrew Lock",
            //    Pages= 750,
            //    Price= 50 ,
            //    Year= 2023
            //});

            //Key haye tarkibi marboot be class RatingData
            builder.Entity<RatingData>().HasKey(r => new
            {
                r.OrderId,
                r.BookId
            });


            //Baraye inke amal multiple Cascade paths etefagh nayofte, bayad rabete ro tarif konim. be in soorat zir.
            //Har BookData rabete 1 be chand ba Rating dare va har rating ham 1 Book dare
            //Rooye halat NoAction mizrim. Manzoor ine ke age ketabi hazf shod. ba ratinghash kari nadashte bashim.

            builder.Entity<BookData>()
                .HasMany(b => b.Ratings)
                .WithOne(b => b.Book).OnDelete(DeleteBehavior.NoAction);


            //Baraye Order ham bayad relationha tarif konim
            //Har Order yek rating dare va har rating ham yek rabete ba order dare.
            builder.Entity<OrderData>()
                .HasOne(o=>o.Rating)
                .WithOne(o=>o.Order).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}