using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedDatabaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Hero",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Hero",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Hero",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Hero",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Hero",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Hero");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Hero");
        }
    }
}
