using Microsoft.EntityFrameworkCore;
using WTR_Blazor.Data;
using WTR_Blazor.Models;

public static class DbInitializer
{
    public static async Task Initialize(IDbContextFactory<ApplicationDbContext> factory, bool shouldInitialize)
    {
        if (!shouldInitialize)
        {
            return;
        }

        using var context = await factory.CreateDbContextAsync();

        await context.Database.MigrateAsync();

        await InitializeProjectPhases(context);
        await InitializeEmployeePositions(context);   
        await InitializeCompanies(context);
        await InitializeTooltreeType(context);
        await InitializeProjectTypes(context);
        await InitializeEmployees(context);

        await context.SaveChangesAsync();
    }

    private static async Task InitializeProjectPhases(ApplicationDbContext context)
    {
        if (!await context.ProjectPhases.AnyAsync())
        {
            var phases = new List<ProjectPhase>
            {
                new ProjectPhase { Name = "RFQ", Order = 1 },
                new ProjectPhase { Name = "DR", Order = 2 },
                new ProjectPhase { Name = "Manu", Order = 3 },
                new ProjectPhase { Name = "FAT", Order = 4 },
                new ProjectPhase { Name = "Inst", Order = 5 },
                new ProjectPhase { Name = "Comm", Order = 6 },
                new ProjectPhase { Name = "SAT", Order = 7 },
                new ProjectPhase { Name = "MTO", Order = 8 },
                new ProjectPhase { Name = "TT", Order = 9 },
                new ProjectPhase { Name = "PP", Order = 10 },
                new ProjectPhase { Name = "MP1", Order = 11 },
                new ProjectPhase { Name = "SOP", Order = 12 },
                new ProjectPhase { Name = "Take over", Order = 13 },
                new ProjectPhase { Name = "FSR", Order = 14 }
            };

            await context.ProjectPhases.AddRangeAsync(phases);
        }
    }

    private static async Task InitializeEmployees(ApplicationDbContext context)
    {
        if (!await context.Employees.AnyAsync())
        {
            var engineerPosition = 1;
            var rmPosition = 2;

            var employees = new List<Employee>
        {
            new Employee { FirstName = "John", LastName = "Smith", Email = "john.smith@outlook.com", PhoneNumber = "+4 606 404 1541", IsInternal = true, IsActive = true, PositionId = engineerPosition },
            new Employee { FirstName = "Emma", LastName = "Johnson", Email = "emma.johnson@company.com", PhoneNumber = "+22 902 893 4046", IsInternal = false, IsActive = true, PositionId = rmPosition },
            new Employee { FirstName = "Michael", LastName = "Williams", Email = "michael.williams@example.com", PhoneNumber = "+79 112 410 8955", IsInternal = true, IsActive = true, PositionId = engineerPosition },
            new Employee { FirstName = "Sophia", LastName = "Brown", Email = "sophia.brown@outlook.com", PhoneNumber = "+82 858 887 9745", IsInternal = true, IsActive = true, PositionId = engineerPosition },
            new Employee { FirstName = "William", LastName = "Jones", Email = "william.jones@example.com", PhoneNumber = "+45 927 965 9782", IsInternal = true, IsActive = true, PositionId = engineerPosition },
            new Employee { FirstName = "Olivia", LastName = "Miller", Email = "olivia.miller@example.com", PhoneNumber = "+58 677 113 9047", IsInternal = true, IsActive = true, PositionId = engineerPosition },
            new Employee { FirstName = "James", LastName = "Davis", Email = "james.davis@example.com", PhoneNumber = "+14 924 621 3635", IsInternal = false, IsActive = true, PositionId = rmPosition },
            new Employee { FirstName = "Ava", LastName = "Garcia", Email = "ava.garcia@gmail.com", PhoneNumber = "+74 664 895 9950", IsInternal = false, IsActive = true, PositionId = rmPosition },
            new Employee { FirstName = "Alexander", LastName = "Rodriguez", Email = "alexander.rodriguez@outlook.com", PhoneNumber = "+66 489 555 3113", IsInternal = true, IsActive = true, PositionId = engineerPosition },
            new Employee { FirstName = "Isabella", LastName = "Wilson", Email = "isabella.wilson@outlook.com", PhoneNumber = "+39 526 223 6360", IsInternal = false, IsActive = true, PositionId = rmPosition }
        };

            await context.Employees.AddRangeAsync(employees);
        }
    }


    private static async Task InitializeEmployeePositions(ApplicationDbContext context)
    {
        if (!await context.EmployeePositions.AnyAsync())
        {
            var positions = new List<EmployeePosition>
            {
                new EmployeePosition { Name = "Engineer" },
                new EmployeePosition { Name = "R&M" }
            };

            await context.EmployeePositions.AddRangeAsync(positions);
        }
    }

    private static async Task InitializeCompanies(ApplicationDbContext context)
    {
        if (!await context.Companies.AnyAsync())
        {
            var companies = new List<Company>
            {
                new Company { Name = "TechCorp Solutions", IsActive = true },
                new Company { Name = "Global Innovations Inc.", IsActive = true },
                new Company { Name = "Quantum Dynamics Ltd.", IsActive = true },
                new Company { Name = "Eco Systems International", IsActive = true },
                new Company { Name = "Stellar Engineering Group", IsActive = true }
            };

            await context.Companies.AddRangeAsync(companies);
        }
    }

    private static async Task InitializeProjectTypes(ApplicationDbContext context)
    {
        if (!await context.ProjectTypes.AnyAsync())
        {
            var projectTypes = new List<ProjectType>
        {
            new ProjectType { Id = 1, Name = "Capex", Order = 1, IsActive = true, Color = "Color.Primary" },
            new ProjectType { Id = 2, Name = "New carmodel", Order = 2, IsActive = true, Color = "Color.Secondary" },
            new ProjectType { Id = 3, Name = "Adaption", Order = 3, IsActive = true, Color = "Color.Tertiary" }
        };

            await context.ProjectTypes.AddRangeAsync(projectTypes);
        }
    }

    private static async Task InitializeTooltreeType(ApplicationDbContext context)
    {
        if (!await context.ProjectTypes.AnyAsync())
        {
            var tooltreeType = new List<TooltreeType>
        {
            new TooltreeType { Id = 1, Code = "N", Description = "New equipment (new machinenumber)", IsActive = true },
            new TooltreeType { Id = 2, Code = "M", Description = "Modification (or rebuild) of existing equipment", IsActive = true},
            new TooltreeType { Id = 3, Code = "T", Description = "Transfered / moved existing equipment to other location", IsActive = true},
            new TooltreeType { Id = 4, Code = "C", Description = "During project decided to cancel machine", IsActive = true }
        };

            await context.TooltreeTypes.AddRangeAsync(tooltreeType);
        }
    }

}
