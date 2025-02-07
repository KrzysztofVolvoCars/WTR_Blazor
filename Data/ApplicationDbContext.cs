using Microsoft.EntityFrameworkCore;
using WTR_Blazor.Models;

using WTR_Blazor.Models.DeliverableModels;

using WTR_Blazor.Models.TooltreeModels;

namespace WTR_Blazor.Data;

 
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<ProjectPhase> ProjectPhases { get; set; }
    public DbSet<ProjectType> ProjectTypes { get; set; }
    public DbSet<EmployeePosition> EmployeePositions { get; set; }
    public DbSet<Tooltree> Tooltrees { get; set; }
    public DbSet<TooltreeData> TooltreeDatas { get; set; }
    public DbSet<TooltreeFile> TooltreeFiles { get; set; }
    public DbSet<TooltreeType> TooltreeTypes { get; set; }


    // New DbSet properties
    public DbSet<Deliverable> Deliverables { get; set; }
    public DbSet<DeliverableQuestionGroup> DeliverableQuestionGroups { get; set; }
    public DbSet<DeliverableQuestion> DeliverableQuestions { get; set; }
    public DbSet<DeliverableAnswerType> DeliverableAnswerTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Project configuration
        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Projects");

            entity.Property(e => e.EcNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.ProjectName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.PowerBiUrl)
                .HasMaxLength(500);

            entity.HasOne(p => p.Engineer)
                .WithMany()
                .HasForeignKey(p => p.EngineerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.Supplier)
                .WithMany()
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.ProjectPhase)
                .WithMany(pp => pp.Projects)
                .HasForeignKey(p => p.ProjectPhaseId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.ProjectType)
                .WithMany(pt => pt.Projects)
                .HasForeignKey(p => p.ProjectTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => e.EcNumber).IsUnique();
        });

        // Employee configuration
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employees");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15);

            entity.HasOne(e => e.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => e.Email).IsUnique();
        });

        // Company configuration
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Companies");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
 

            entity.HasIndex(e => e.Name).IsUnique();
        });

        // Tooltree configuration
        modelBuilder.Entity<Tooltree>(entity =>
        {
            entity.ToTable("Tooltrees");

            entity.HasOne(t => t.Project)
                .WithOne(p => p.Tooltree)
                .HasForeignKey<Tooltree>(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // TooltreeData configuration
        modelBuilder.Entity<TooltreeData>(entity =>
        {
            entity.ToTable("TooltreeDatas");

            entity.Property(e => e.PlcStationEquipment)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.MachineNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Station)
                .HasMaxLength(50);

            entity.Property(e => e.AssetCode)
                .HasMaxLength(50);

            entity.HasOne(td => td.Type)
                .WithMany(tt => tt.TooltreeDatas)
                .HasForeignKey(td => td.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(td => td.Tooltree)
                .WithMany(t => t.TooltreeDatas)
                .HasForeignKey(td => td.TooltreeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // DeliverableQuestionGroup configuration
        modelBuilder.Entity<DeliverableQuestionGroup>(entity =>
        {
            entity.ToTable("DeliverableQuestionGroups");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .HasMaxLength(500);

            entity.HasOne(dqg => dqg.TooltreeData)
                .WithMany()
                .HasForeignKey(dqg => dqg.TooltreeDataId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // DeliverableQuestion configuration
        modelBuilder.Entity<DeliverableQuestion>(entity =>
        {
            entity.ToTable("DeliverableQuestions");

            entity.Property(e => e.Question)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.Description)
                .HasMaxLength(500);

            entity.HasOne(dq => dq.QuestionGroup)
                .WithMany(dqg => dqg.Questions)
                .HasForeignKey(dq => dq.QuestionGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(dq => dq.PossibleAnswers)
                .WithMany(dat => dat.Questions)
                .UsingEntity(j => j.ToTable("DeliverableQuestionAnswerTypes"));
        });

        base.OnModelCreating(modelBuilder);
    }
}



//dotnet ef migrations add InitialCreate
//dotnet ef database update
