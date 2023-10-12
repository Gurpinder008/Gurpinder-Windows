using Microsoft.EntityFrameworkCore.Migrations;

namespace Gurpinder_Windows.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Window",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Style = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    Size = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Rating = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Window", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Window");
        }
    }
}
