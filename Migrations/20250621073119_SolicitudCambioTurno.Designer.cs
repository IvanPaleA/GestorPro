﻿// <auto-generated />
using System;
using GestorPro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestorPro.Migrations
{
    [DbContext(typeof(GestorProContext))]
    [Migration("20250621073119_SolicitudCambioTurno")]
    partial class SolicitudCambioTurno
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("GestorPro.Models.Asistencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Dia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan?>("HoraEntrada")
                        .HasColumnType("time(6)");

                    b.Property<string>("IdEmpleado")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpleado");

                    b.ToTable("Asistencias");
                });

            modelBuilder.Entity("GestorPro.Models.Empleado", b =>
                {
                    b.Property<string>("IdEmpleado")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TurnoId")
                        .HasColumnType("int");

                    b.HasKey("IdEmpleado");

                    b.HasIndex("TurnoId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("GestorPro.Models.HorasExtra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadHoras")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IdEmpleado")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpleado");

                    b.ToTable("HorasExtras");
                });

            modelBuilder.Entity("GestorPro.Models.Jornada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("HoraFin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("HoraInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IdEmpleado")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpleado");

                    b.ToTable("Jornadas");
                });

            modelBuilder.Entity("GestorPro.Models.RegistroPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmpleadoId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("PagoBase")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PagoExtra")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Periodo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("RegistroPago");
                });

            modelBuilder.Entity("GestorPro.Models.SolicitudCambioTurno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aprobado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IdEmpleado")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TurnoSolicitadoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("TurnoSolicitadoId");

                    b.ToTable("SolicitudesCambioTurno");
                });

            modelBuilder.Entity("GestorPro.Models.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("GestorPro.Models.Asistencia", b =>
                {
                    b.HasOne("GestorPro.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("GestorPro.Models.Empleado", b =>
                {
                    b.HasOne("GestorPro.Models.Turno", "Turno")
                        .WithMany()
                        .HasForeignKey("TurnoId");

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("GestorPro.Models.HorasExtra", b =>
                {
                    b.HasOne("GestorPro.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("GestorPro.Models.Jornada", b =>
                {
                    b.HasOne("GestorPro.Models.Empleado", "Empleado")
                        .WithMany("Jornadas")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("GestorPro.Models.RegistroPago", b =>
                {
                    b.HasOne("GestorPro.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("GestorPro.Models.SolicitudCambioTurno", b =>
                {
                    b.HasOne("GestorPro.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorPro.Models.Turno", "TurnoSolicitado")
                        .WithMany()
                        .HasForeignKey("TurnoSolicitadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("TurnoSolicitado");
                });

            modelBuilder.Entity("GestorPro.Models.Empleado", b =>
                {
                    b.Navigation("Jornadas");
                });
#pragma warning restore 612, 618
        }
    }
}
