namespace SupplyPoint.Infrastructure.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData("Products", new[] { "Id", "Name", "Text" }, new object[] { new Guid("f5217548-a3f9-472c-93fa-9d61cce61b0d"), "Product 1", "Some interesting product text" });
            migrationBuilder.InsertData("Products", new[] { "Id", "Name", "Text" }, new object[] { new Guid("979396ae-e3bf-4b06-a23b-73cb46680487"), "Product 2", "Some other interesting product text"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
