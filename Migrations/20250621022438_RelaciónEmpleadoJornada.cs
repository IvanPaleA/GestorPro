using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPro.Migrations
{
    /// <inheritdoc />
    public partial class RelaciónEmpleadoJornada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jornadas_Empleados_EmpleadoId",
                table: "Jornadas");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "Jornadas",
                newName: "IdEmpleado");

            migrationBuilder.RenameIndex(
                name: "IX_Jornadas_EmpleadoId",
                table: "Jornadas",
                newName: "IX_Jornadas_IdEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Jornadas_Empleados_IdEmpleado",
                table: "Jornadas",
                column: "IdEmpleado",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jornadas_Empleados_IdEmpleado",
                table: "Jornadas");

            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Jornadas",
                newName: "EmpleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Jornadas_IdEmpleado",
                table: "Jornadas",
                newName: "IX_Jornadas_EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jornadas_Empleados_EmpleadoId",
                table: "Jornadas",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
