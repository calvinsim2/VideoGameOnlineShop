using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameOnlineShopInfrastructure.Migrations
{
    public partial class AmendGameColumnAddCodePlatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeDecodePlatform",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false, defaultValueSql: "newsequentialId()"),
                    Code = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    DecodeValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeDecodePlatform", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeDecodePlatform");
        }
    }
}
