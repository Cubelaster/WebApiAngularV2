using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Added_Claims_Table_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "Claims",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "Claims",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Claims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Claims",
                newName: "ClaimType");
        }
    }
}
