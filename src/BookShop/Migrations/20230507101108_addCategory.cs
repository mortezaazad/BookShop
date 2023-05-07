using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Migrations
{
    /// <inheritdoc />
    public partial class addCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Books",
            //    keyColumn: "Id",
            //    keyValue: 1);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverImage", "Description", "Language", "Name", "Pages", "Price", "Year" },
                values: new object[] { 1, "Andrew Lock", null, "In ASP.NET Core in Action, Third Edition Microsoft MVP Andrew Lock teaches you how you can use your C# and .NET skills to build amazing cross-platform web applications. This revised bestseller reveals the latest .NET patterns, including minimal APIs and minimal hosting. Even if you've never worked with ASP.NET, you'll start creating productive cross-platform web apps fast.", 0, "Asp.net Core in Action", 750, 50, 2023 });
        }
    }
}
