using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicaRevolution.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dateDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseDateDoctor",
                table: "PatientForms",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseDateDoctor",
                table: "PatientForms");
        }
    }
}
