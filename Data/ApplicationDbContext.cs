using Microsoft.EntityFrameworkCore;
using WTR_Blazor.Models;
using WTR_Blazor.Models.Tooltree;

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

        modelBuilder.Entity<Project>()
           .HasOne(p => p.Tooltree)
           .WithOne(t => t.Project)
           .HasForeignKey<Tooltree>(t => t.ProjectId)
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Tooltree>()
            .HasMany(t => t.TooltreeData)
            .WithOne(td => td.Tooltree)
            .HasForeignKey(td => td.TooltreeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Tooltree>()
            .HasMany(t => t.TooltreeFiles)
            .WithOne(tf => tf.Tooltree)
            .HasForeignKey(tf => tf.TooltreeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TooltreeType>()
            .HasIndex(t => t.Code)
            .IsUnique();

    }
}


//dotnet ef migrations add InitialCreate
//dotnet ef database update
