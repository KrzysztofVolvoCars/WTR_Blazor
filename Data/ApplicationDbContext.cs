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
 

    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<ProjectPhase> ProjectPhases { get; set; }
    public DbSet<NewProject> NewProjects { get; set; }
}

//dotnet ef migrations add InitialCreate
//dotnet ef database update
