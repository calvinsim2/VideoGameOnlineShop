using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameOnlineShopInfrastructure.Migrations
{
    public partial class AddedCodePlatformOnGameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodePlatform",
                table: "Game",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodePlatform",
                table: "Game");
        }
    }
}
