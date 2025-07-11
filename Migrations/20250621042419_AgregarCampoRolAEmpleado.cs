﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPro.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoRolAEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Empleados",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Empleados");
        }
    }
}
