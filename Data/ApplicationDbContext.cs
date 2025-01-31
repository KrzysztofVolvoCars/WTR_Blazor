using Microsoft.EntityFrameworkCore;
using WTR_Blazor.Models;

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
            .HasOne(p => p.ProjectType)
            .WithMany()
            .HasForeignKey(p => p.ProjectTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.Email)
            .IsUnique();

        modelBuilder.Entity<Tooltree>()
            .HasOne(t => t.Project)
            .WithOne(p => p.Tooltree)
            .HasForeignKey<Tooltree>(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Tooltree>()
            .HasOne(t => t.TooltreeData)
            .WithOne(td => td.Tooltree)
            .HasForeignKey<TooltreeData>(td => td.TooltreeId);

        modelBuilder.Entity<TooltreeFile>()
            .HasOne(tf => tf.Project)
            .WithMany(p => p.TooltreeFiles)
            .HasForeignKey(tf => tf.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TooltreeFile>()
            .HasOne(tf => tf.Tooltree)
            .WithMany(t => t.TooltreeFiles)
            .HasForeignKey(tf => tf.TooltreeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}


//dotnet ef migrations add InitialCreate
//dotnet ef database update
