using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPro.Migrations
{
    /// <inheritdoc />
    public partial class AddTablaJornada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Jornadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpleadoId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    HoraFin = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jornadas_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_TurnoId",
                table: "Empleados",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jornadas_EmpleadoId",
                table: "Jornadas",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Empleados_IdEmpleado",
                table: "Asistencias",
                column: "IdEmpleado",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Turnos_TurnoId",
                table: "Empleados",
                column: "TurnoId",
                principalTable: "Turnos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Empleados_IdEmpleado",
                table: "Asistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Turnos_TurnoId",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "Jornadas");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_TurnoId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "TurnoId",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Asistencias",
                newName: "EmpleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Asistencias_IdEmpleado",
                table: "Asistencias",
                newName: "IX_Asistencias_EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Empleados_EmpleadoId",
                table: "Asistencias",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
