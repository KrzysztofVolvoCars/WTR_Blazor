using Microsoft.EntityFrameworkCore;
using MudBlazor.Charts;
using WTR_Blazor.Components.Pages;
using WTR_Blazor.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
    public DbSet<Tooltree> Tooltrees { get; set; }
    public DbSet<EmployeePosition> EmployeePositions { get; set; }
    public DbSet<TooltreeData> TooltreeDatas { get; set; }
    public DbSet<TooltreeFile> TooltreeFiles { get; set; }
    public DbSet<TooltreeType> TooltreeTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.Engineer)
            .WithMany()
            .HasForeignKey(p => p.EngineerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.RMResponsible)
            .WithMany()
            .HasForeignKey(p => p.RMResponsibleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.Supplier)
            .WithMany()
            .HasForeignKey(p => p.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.ProjectPhase)
            .WithMany()
            .HasForeignKey(p => p.ProjectPhaseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.Tooltree)
            .WithMany()
            .HasForeignKey(p => p.TooltreeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.ProjectType)
            .WithMany()
            .HasForeignKey(p => p.ProjectTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.Email)
            .IsUnique();

        modelBuilder.Entity<TooltreeFile>()
            .HasOne(tf => tf.Project)
            .WithMany(p => p.TooltreeFiles)
            .HasForeignKey(tf => tf.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

//dotnet ef migrations add InitialCreate
//dotnet ef database update
