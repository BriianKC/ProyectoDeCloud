﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PELICULA.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230525202719_v02")]
    partial class v02
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("PELICULAS.ENTIDADES.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Edad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Directores");
                });

            modelBuilder.Entity("PELICULAS.ENTIDADES.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Anio")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DirectorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("PELICULAS.ENTIDADES.Pelicula", b =>
                {
                    b.HasOne("PELICULAS.ENTIDADES.Director", "Director")
                        .WithMany("Peliculas")
                        .HasForeignKey("DirectorId");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("PELICULAS.ENTIDADES.Director", b =>
                {
                    b.Navigation("Peliculas");
                });
#pragma warning restore 612, 618
        }
    }
}