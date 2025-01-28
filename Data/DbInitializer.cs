using Microsoft.EntityFrameworkCore;
using WTR_Blazor.Models;

namespace WTR_Blazor.Data;

public static class DbInitializer
{
    public static async Task Initialize(IDbContextFactory<ApplicationDbContext> factory)
    {
        using var context = await factory.CreateDbContextAsync();

        // Automatyczne tworzenie bazy danych i stosowanie migracji
        await context.Database.MigrateAsync();

        // Sprawdź czy tabela jest pusta
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
            await context.SaveChangesAsync();
        }
    }
}
