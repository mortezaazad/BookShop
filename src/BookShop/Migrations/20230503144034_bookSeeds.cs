using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Migrations
{
    /// <inheritdoc />
    public partial class bookSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Name", "Pages", "Price", "Year" },
                values: new object[] { 1, "Andrew Lock", "In ASP.NET Core in Action, Third Edition Microsoft MVP Andrew Lock teaches you how you can use your C# and .NET skills to build amazing cross-platform web applications. This revised bestseller reveals the latest .NET patterns, including minimal APIs and minimal hosting. Even if you've never worked with ASP.NET, you'll start creating productive cross-platform web apps fast.", "Asp.net Core in Action", 750, 50, 2023 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
