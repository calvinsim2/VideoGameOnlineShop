﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameOnlineShopInfrastructure.Migrations
{
    public partial class AmendCTTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeCreated",
                table: "CodeDecodeMatureRating");

            migrationBuilder.DropColumn(
                name: "DateTimeUpdated",
                table: "CodeDecodeMatureRating");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTimeCreated",
                table: "CodeDecodeMatureRating",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTimeUpdated",
                table: "CodeDecodeMatureRating",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
