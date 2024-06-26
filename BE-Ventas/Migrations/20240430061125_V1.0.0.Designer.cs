﻿// <auto-generated />
using System;
using BE_Ventas.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BEVentas.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20240430061125_V1.0.0")]
    partial class V100
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BE_Ventas.Repository.Entities.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("BE_Ventas.Repository.Entities.DetalleVenta", b =>
                {
                    b.Property<int>("IdDetalleVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleVenta"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("VentaIdVenta")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleVenta");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaIdVenta");

                    b.ToTable("DetalleVenta");
                });

            modelBuilder.Entity("BE_Ventas.Repository.Entities.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("IdProducto");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("BE_Ventas.Repository.Entities.Venta", b =>
                {
                    b.Property<int>("IdVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVenta"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("IdVenta");

                    b.HasIndex("ClienteId");

                    b.ToTable("Venta");
                });

            modelBuilder.Entity("BE_Ventas.Repository.Entities.DetalleVenta", b =>
                {
                    b.HasOne("BE_Ventas.Repository.Entities.Producto", null)
                        .WithMany("DetalleVentaProducto")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_Ventas.Repository.Entities.Venta", null)
                        .WithMany("DetalleVentas")
                        .HasForeignKey("VentaIdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BE_Ventas.Repository.Entities.Venta", b =>
                {
                    b.HasOne("BE_Ventas.Repository.Entities.Cliente", null)
                        .WithMany("VentaCliente")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BE_Ventas.Repository.Entities.Cliente", b =>
                {
                    b.Navigation("VentaCliente");
                });

            modelBuilder.Entity("BE_Ventas.Repository.Entities.Producto", b =>
                {
                    b.Navigation("DetalleVentaProducto");
                });

            modelBuilder.Entity("BE_Ventas.Repository.Entities.Venta", b =>
                {
                    b.Navigation("DetalleVentas");
                });
#pragma warning restore 612, 618
        }
    }
}
