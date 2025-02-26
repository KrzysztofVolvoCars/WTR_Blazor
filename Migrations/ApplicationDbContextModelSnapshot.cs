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
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("WTR_Blazor.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PhotoData")
                        .HasMaxLength(100)
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("WTR_Blazor.Models.DeliverableModels.Deliverable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("Deliverables");
                });

            modelBuilder.Entity("WTR_Blazor.Models.DeliverableModels.DeliverableAnswerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DeliverableAnswerTypes");
                });

            modelBuilder.Entity("WTR_Blazor.Models.DeliverableModels.DeliverableQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeliverableAnswerTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProjectPhaseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("QuestionGroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DeliverableAnswerTypeId");

                    b.HasIndex("ProjectPhaseId");

                    b.HasIndex("QuestionGroupId");

                    b.ToTable("DeliverableQuestions", (string)null);
                });

            modelBuilder.Entity("WTR_Blazor.Models.DeliverableModels.DeliverableQuestionGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DeliverableId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("TooltreeDataId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DeliverableId");

                    b.HasIndex("TooltreeDataId");

                    b.ToTable("DeliverableQuestionGroups", (string)null);
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
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsInternal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PhotoData")
                        .HasColumnType("BLOB");

                    b.Property<int>("PositionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PositionId");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("WTR_Blazor.Models.EmployeePosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EmployeePositions");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EcNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("EngineerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Installation")
                        .HasColumnType("TEXT");

                    b.Property<string>("PowerBiUrl")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProjectPhaseId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProjectTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RmTechnikerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Sop")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TooltreeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EcNumber")
                        .IsUnique();

                    b.HasIndex("EngineerId");

                    b.HasIndex("ProjectPhaseId");

                    b.HasIndex("ProjectTypeId");

                    b.HasIndex("RmTechnikerId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("WTR_Blazor.Models.ProjectPhase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
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

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ProjectTypes");
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeModels.Tooltree", b =>
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

                    b.ToTable("Tooltrees", (string)null);
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeModels.TooltreeData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AssetCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("AssetNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentLinebuilder")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentVolvo")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("MachineNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Plc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PlcStationEquipment")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Station")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ToolNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("TooltreeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TooltreeId");

                    b.HasIndex("TypeId");

                    b.ToTable("TooltreeDatas", (string)null);
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeModels.TooltreeFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<long>("FileSize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("OrginalName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int>("TooltreeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TooltreeId");

                    b.ToTable("TooltreeFiles");
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeModels.TooltreeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TooltreeTypes");
                });

            modelBuilder.Entity("WTR_Blazor.Models.DeliverableModels.Deliverable", b =>
                {
                    b.HasOne("WTR_Blazor.Models.Project", "Project")
                        .WithOne("Deliverable")
                        .HasForeignKey("WTR_Blazor.Models.DeliverableModels.Deliverable", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("WTR_Blazor.Models.DeliverableModels.DeliverableQuestion", b =>
                {
                    b.HasOne("WTR_Blazor.Models.DeliverableModels.DeliverableAnswerType", "DeliverableAnswerType")
                        .WithMany("Questions")
                        .HasForeignKey("DeliverableAnswerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WTR_Blazor.Models.ProjectPhase", "ProjectPhase")
                        .WithMany()
                        .HasForeignKey("ProjectPhaseId");

                    b.HasOne("WTR_Blazor.Models.DeliverableModels.DeliverableQuestionGroup", "QuestionGroup")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeliverableAnswerType");

                    b.Navigation("ProjectPhase");

                    b.Navigation("QuestionGroup");
                });

            modelBuilder.Entity("WTR_Blazor.Models.DeliverableModels.DeliverableQuestionGroup", b =>
                {
                    b.HasOne("WTR_Blazor.Models.DeliverableModels.Deliverable", null)
                        .WithMany("QuestionGroups")
                        .HasForeignKey("DeliverableId");

                    b.HasOne("WTR_Blazor.Models.TooltreeModels.TooltreeData", "TooltreeData")
                        .WithMany()
                        .HasForeignKey("TooltreeDataId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TooltreeData");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Employee", b =>
                {
                    b.HasOne("WTR_Blazor.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WTR_Blazor.Models.EmployeePosition", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Project", b =>
                {
                    b.HasOne("WTR_Blazor.Models.Employee", "Engineer")
                        .WithMany()
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WTR_Blazor.Models.ProjectPhase", "ProjectPhase")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectPhaseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WTR_Blazor.Models.ProjectType", "ProjectType")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WTR_Blazor.Models.Employee", "RmTechniker")
                        .WithMany()
                        .HasForeignKey("RmTechnikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WTR_Blazor.Models.Company", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Engineer");

                    b.Navigation("ProjectPhase");

                    b.Navigation("ProjectType");

                    b.Navigation("RmTechniker");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeModels.Tooltree", b =>
                {
                    b.HasOne("WTR_Blazor.Models.Project", "Project")
                        .WithOne("Tooltree")
                        .HasForeignKey("WTR_Blazor.Models.TooltreeModels.Tooltree", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeModels.TooltreeData", b =>
                {
                    b.HasOne("WTR_Blazor.Models.TooltreeModels.Tooltree", "Tooltree")
                        .WithMany("TooltreeDatas")
                        .HasForeignKey("TooltreeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WTR_Blazor.Models.TooltreeModels.TooltreeType", "Type")
                        .WithMany("TooltreeDatas")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Tooltree");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeModels.TooltreeFile", b =>
                {
                    b.HasOne("WTR_Blazor.Models.TooltreeModels.Tooltree", "Tooltree")
                        .WithMany("TooltreeFiles")
                        .HasForeignKey("TooltreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tooltree");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("WTR_Blazor.Models.DeliverableModels.Deliverable", b =>
                {
                    b.Navigation("QuestionGroups");
                });

            modelBuilder.Entity("WTR_Blazor.Models.DeliverableModels.DeliverableAnswerType", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("WTR_Blazor.Models.DeliverableModels.DeliverableQuestionGroup", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("WTR_Blazor.Models.EmployeePosition", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("WTR_Blazor.Models.Project", b =>
                {
                    b.Navigation("Deliverable")
                        .IsRequired();

                    b.Navigation("Tooltree")
                        .IsRequired();
                });

            modelBuilder.Entity("WTR_Blazor.Models.ProjectPhase", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("WTR_Blazor.Models.ProjectType", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeModels.Tooltree", b =>
                {
                    b.Navigation("TooltreeDatas");

                    b.Navigation("TooltreeFiles");
                });

            modelBuilder.Entity("WTR_Blazor.Models.TooltreeModels.TooltreeType", b =>
                {
                    b.Navigation("TooltreeDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
