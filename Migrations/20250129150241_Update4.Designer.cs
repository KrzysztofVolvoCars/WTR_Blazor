﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WTR_Blazor.Data;

#nullable disable

namespace WTR_Blazor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250129150241_Update4")]
    partial class Update4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("WTR_Blazor.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("LogoData")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsInternal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PhotoData")
                        .HasColumnType("BLOB");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WTR_Blazor.Models.NewProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ECNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EngineerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Installation")
                        .HasColumnType("TEXT");

                    b.Property<string>("PowerBI_URL")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProjectPhaseId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RMResponsibleId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("SOP")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EngineerId");

                    b.HasIndex("ProjectPhaseId");

                    b.HasIndex("RMResponsibleId");

                    b.HasIndex("SupplierId");

                    b.ToTable("NewProjects");
                });

            modelBuilder.Entity("WTR_Blazor.Models.ProjectPhase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ProjectPhases");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Employee", b =>
                {
                    b.HasOne("WTR_Blazor.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WTR_Blazor.Models.NewProject", b =>
                {
                    b.HasOne("WTR_Blazor.Models.Employee", "Engineer")
                        .WithMany()
                        .HasForeignKey("EngineerId");

                    b.HasOne("WTR_Blazor.Models.ProjectPhase", "ProjectPhase")
                        .WithMany()
                        .HasForeignKey("ProjectPhaseId");

                    b.HasOne("WTR_Blazor.Models.Employee", "RMResponsible")
                        .WithMany()
                        .HasForeignKey("RMResponsibleId");

                    b.HasOne("WTR_Blazor.Models.Company", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");

                    b.Navigation("Engineer");

                    b.Navigation("ProjectPhase");

                    b.Navigation("RMResponsible");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
