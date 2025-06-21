using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPro.Migrations
{
    /// <inheritdoc />
    public partial class SolicitudCambioTurno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolicitudesCambioTurno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEmpleado = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TurnoSolicitadoId = table.Column<int>(type: "int", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Aprobado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesCambioTurno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudesCambioTurno_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesCambioTurno_Turnos_TurnoSolicitadoId",
                        column: x => x.TurnoSolicitadoId,
                        principalTable: "Turnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesCambioTurno_IdEmpleado",
                table: "SolicitudesCambioTurno",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesCambioTurno_TurnoSolicitadoId",
                table: "SolicitudesCambioTurno",
                column: "TurnoSolicitadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitudesCambioTurno");
        }
    }
}
