using Microsoft.EntityFrameworkCore.Migrations;

namespace EnhancedGamesApp.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Publisher = table.Column<string>(nullable: false),
                    FourKConfirmed = table.Column<bool>(nullable: false),
                    HdrRenderingAvailable = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
