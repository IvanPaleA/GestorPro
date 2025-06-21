using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPro.Migrations
{
    /// <inheritdoc />
    public partial class AddTablaRegistroPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroPagos_Empleados_EmpleadoId",
                table: "RegistroPagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistroPagos",
                table: "RegistroPagos");

            migrationBuilder.RenameTable(
                name: "RegistroPagos",
                newName: "RegistroPago");

            migrationBuilder.RenameIndex(
                name: "IX_RegistroPagos_EmpleadoId",
                table: "RegistroPago",
                newName: "IX_RegistroPago_EmpleadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistroPago",
                table: "RegistroPago",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroPago_Empleados_EmpleadoId",
                table: "RegistroPago",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroPago_Empleados_EmpleadoId",
                table: "RegistroPago");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistroPago",
                table: "RegistroPago");

            migrationBuilder.RenameTable(
                name: "RegistroPago",
                newName: "RegistroPagos");

            migrationBuilder.RenameIndex(
                name: "IX_RegistroPago_EmpleadoId",
                table: "RegistroPagos",
                newName: "IX_RegistroPagos_EmpleadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistroPagos",
                table: "RegistroPagos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroPagos_Empleados_EmpleadoId",
                table: "RegistroPagos",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
