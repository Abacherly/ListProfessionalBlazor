﻿// <auto-generated />
using ListProfessionalBlazor.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ListProfessionalBlazor.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230712141232_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ListProfessionalBlazor.Shared.ListProfessional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkId")
                        .HasColumnType("int");

                    b.Property<string>("Years")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.ToTable("ListProfessionals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "João",
                            Position = "Gerente",
                            WorkId = 1,
                            Years = "4"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Maria",
                            Position = "Desenvolvedora Sênior",
                            WorkId = 2,
                            Years = "8"
                        });
                });

            modelBuilder.Entity("ListProfessionalBlazor.Shared.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Works");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Home Office"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Empresa"
                        });
                });

            modelBuilder.Entity("ListProfessionalBlazor.Shared.ListProfessional", b =>
                {
                    b.HasOne("ListProfessionalBlazor.Shared.Work", "Work")
                        .WithMany()
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Work");
                });
#pragma warning restore 612, 618
        }
    }
}
