using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migadd_birthdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Abouts");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "Abouts",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Abouts");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
