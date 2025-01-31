﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WTR_Blazor.Data;

#nullable disable

namespace WTR_Blazor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsInternal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PhotoData")
                        .HasColumnType("BLOB");

                    b.Property<int?>("PositionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WTR_Blazor.Models.EmployeePosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EmployeePositions");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Project", b =>
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

                    b.Property<int?>("ProjectTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RMResponsibleId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("SOP")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EngineerId");

                    b.HasIndex("ProjectPhaseId");

                    b.HasIndex("ProjectTypeId");

                    b.HasIndex("RMResponsibleId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WTR_Blazor.Models.ProjectPhase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ProjectPhases");
                });

            modelBuilder.Entity("WTR_Blazor.Models.ProjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ProjectTypes");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Tooltree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDone")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("Tooltrees");
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AssetCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AssetNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentLinebuilder")
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentVolvo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MachineNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PLC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PLCStationEquipment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Station")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ToolNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TooltreeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TooltreeId");

                    b.HasIndex("TypeId");

                    b.ToTable("TooltreeDatas");
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<long>("FileSize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrginalName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TooltreeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TooltreeId");

                    b.ToTable("TooltreeFiles");
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("TooltreeTypes");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Employee", b =>
                {
                    b.HasOne("WTR_Blazor.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("WTR_Blazor.Models.EmployeePosition", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.Navigation("Company");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Project", b =>
                {
                    b.HasOne("WTR_Blazor.Models.Employee", "Engineer")
                        .WithMany()
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WTR_Blazor.Models.ProjectPhase", "ProjectPhase")
                        .WithMany()
                        .HasForeignKey("ProjectPhaseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WTR_Blazor.Models.ProjectType", "ProjectType")
                        .WithMany()
                        .HasForeignKey("ProjectTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WTR_Blazor.Models.Employee", "RMResponsible")
                        .WithMany()
                        .HasForeignKey("RMResponsibleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WTR_Blazor.Models.Company", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Engineer");

                    b.Navigation("ProjectPhase");

                    b.Navigation("ProjectType");

                    b.Navigation("RMResponsible");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Tooltree", b =>
                {
                    b.HasOne("WTR_Blazor.Models.Project", "Project")
                        .WithOne("Tooltree")
                        .HasForeignKey("WTR_Blazor.Models.Tooltree", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeData", b =>
                {
                    b.HasOne("WTR_Blazor.Models.Tooltree", "Tooltree")
                        .WithMany("TooltreeData")
                        .HasForeignKey("TooltreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WTR_Blazor.Models.TooltreeType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tooltree");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeFile", b =>
                {
                    b.HasOne("WTR_Blazor.Models.Project", null)
                        .WithMany("TooltreeFiles")
                        .HasForeignKey("ProjectId");

                    b.HasOne("WTR_Blazor.Models.Tooltree", "Tooltree")
                        .WithMany("TooltreeFiles")
                        .HasForeignKey("TooltreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tooltree");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Project", b =>
                {
                    b.Navigation("Tooltree");

                    b.Navigation("TooltreeFiles");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Tooltree", b =>
                {
                    b.Navigation("TooltreeData");

                    b.Navigation("TooltreeFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
