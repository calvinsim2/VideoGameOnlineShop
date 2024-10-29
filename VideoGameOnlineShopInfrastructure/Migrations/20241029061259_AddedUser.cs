using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameOnlineShopInfrastructure.Migrations
{
    public partial class AddedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false, defaultValueSql: "newsequentialId()"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateTimeUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
