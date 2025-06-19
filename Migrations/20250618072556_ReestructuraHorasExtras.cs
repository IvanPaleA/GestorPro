using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPro.Migrations
{
    /// <inheritdoc />
    public partial class ReestructuraHorasExtras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorasExtras_Empleados_EmpleadoId",
                table: "HorasExtras");

            migrationBuilder.DropColumn(
                name: "Horas",
                table: "HorasExtras");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "HorasExtras",
                newName: "IdEmpleado");

            migrationBuilder.RenameIndex(
                name: "IX_HorasExtras_EmpleadoId",
                table: "HorasExtras",
                newName: "IX_HorasExtras_IdEmpleado");

            migrationBuilder.AddColumn<int>(
                name: "CantidadHoras",
                table: "HorasExtras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_HorasExtras_Empleados_IdEmpleado",
                table: "HorasExtras",
                column: "IdEmpleado",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorasExtras_Empleados_IdEmpleado",
                table: "HorasExtras");

            migrationBuilder.DropColumn(
                name: "CantidadHoras",
                table: "HorasExtras");

            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "HorasExtras",
                newName: "EmpleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_HorasExtras_IdEmpleado",
                table: "HorasExtras",
                newName: "IX_HorasExtras_EmpleadoId");

            migrationBuilder.AddColumn<double>(
                name: "Horas",
                table: "HorasExtras",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_HorasExtras_Empleados_EmpleadoId",
                table: "HorasExtras",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
