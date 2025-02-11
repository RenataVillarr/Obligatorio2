﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Obligatorio2.Datos;

#nullable disable

namespace Obligatorio2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240706003144_TablasObl")]
    partial class TablasObl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Obligatorio2.Models.Ejercicio", b =>
                {
                    b.Property<int>("IdEjercicio")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTipoMaq")
                        .HasColumnType("int");

                    b.HasKey("IdEjercicio");

                    b.HasIndex("IdTipoMaq");

                    b.ToTable("ejercicios");
                });

            modelBuilder.Entity("Obligatorio2.Models.Local", b =>
                {
                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomRespon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeleRespon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLocal");

                    b.ToTable("locales");
                });

            modelBuilder.Entity("Obligatorio2.Models.Maquina", b =>
                {
                    b.Property<int>("IdMaq")
                        .HasColumnType("int");

                    b.Property<string>("Disponible")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoMaq")
                        .HasColumnType("int");

                    b.Property<double>("PrecioCompra")
                        .HasColumnType("float");

                    b.Property<int>("VidaUtil")
                        .HasColumnType("int");

                    b.HasKey("IdMaq");

                    b.HasIndex("IdLocal");

                    b.HasIndex("IdTipoMaq");

                    b.ToTable("maquinas");
                });

            modelBuilder.Entity("Obligatorio2.Models.Rutina", b =>
                {
                    b.Property<int>("IdRutina")
                        .HasColumnType("int");

                    b.Property<int>("CalifRutinaPromedio")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoRutina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRutina");

                    b.ToTable("rutinas");
                });

            modelBuilder.Entity("Obligatorio2.Models.RutinaEjercicio", b =>
                {
                    b.Property<int>("IdRutina")
                        .HasColumnType("int");

                    b.Property<int>("IdEjercicio")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.HasKey("IdRutina", "IdEjercicio");

                    b.HasIndex("IdEjercicio");

                    b.ToTable("rutinaejercicios");
                });

            modelBuilder.Entity("Obligatorio2.Models.Socio", b =>
                {
                    b.Property<int>("IdSocio")
                        .HasColumnType("int");

                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSocio");

                    b.HasIndex("IdLocal");

                    b.ToTable("socios");
                });

            modelBuilder.Entity("Obligatorio2.Models.SocioRutina", b =>
                {
                    b.Property<int>("IdSocio")
                        .HasColumnType("int");

                    b.Property<int>("IdRutina")
                        .HasColumnType("int");

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("IdSocio", "IdRutina");

                    b.HasIndex("IdRutina");

                    b.ToTable("sociorutinas");
                });

            modelBuilder.Entity("Obligatorio2.Models.TipoMaquina", b =>
                {
                    b.Property<int>("IdTipoMaq")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoMaq");

                    b.ToTable("tipomaquinas");
                });

            modelBuilder.Entity("Obligatorio2.Models.Ejercicio", b =>
                {
                    b.HasOne("Obligatorio2.Models.TipoMaquina", "TipoMaquina")
                        .WithMany()
                        .HasForeignKey("IdTipoMaq")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoMaquina");
                });

            modelBuilder.Entity("Obligatorio2.Models.Maquina", b =>
                {
                    b.HasOne("Obligatorio2.Models.Local", "Local")
                        .WithMany()
                        .HasForeignKey("IdLocal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Obligatorio2.Models.TipoMaquina", "TipoMaquina")
                        .WithMany()
                        .HasForeignKey("IdTipoMaq")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Local");

                    b.Navigation("TipoMaquina");
                });

            modelBuilder.Entity("Obligatorio2.Models.RutinaEjercicio", b =>
                {
                    b.HasOne("Obligatorio2.Models.Ejercicio", "Ejercicio")
                        .WithMany()
                        .HasForeignKey("IdEjercicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Obligatorio2.Models.Rutina", "Rutina")
                        .WithMany()
                        .HasForeignKey("IdRutina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ejercicio");

                    b.Navigation("Rutina");
                });

            modelBuilder.Entity("Obligatorio2.Models.Socio", b =>
                {
                    b.HasOne("Obligatorio2.Models.Local", "Local")
                        .WithMany()
                        .HasForeignKey("IdLocal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Local");
                });

            modelBuilder.Entity("Obligatorio2.Models.SocioRutina", b =>
                {
                    b.HasOne("Obligatorio2.Models.Rutina", "Rutina")
                        .WithMany()
                        .HasForeignKey("IdRutina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Obligatorio2.Models.Socio", "Socio")
                        .WithMany()
                        .HasForeignKey("IdSocio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rutina");

                    b.Navigation("Socio");
                });
#pragma warning restore 612, 618
        }
    }
}
