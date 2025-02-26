using DocumentFormat.OpenXml.EMMA;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using System.Reflection.PortableExecutable;
using WTR_Blazor.Data;
using WTR_Blazor.Models;
using WTR_Blazor.Models.DeliverableModels;
using WTR_Blazor.Models.TooltreeModels;

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

        //Deliverable
        await InitializeDeliverableAnswerTypes(context);
        await InitializeDeliverableQuestionGroup(context);
        await InitializeDeliverableQuestion(context);

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
            new TooltreeType {  Code = "N", Description = "New equipment (new machinenumber)", IsActive = true },
            new TooltreeType {  Code = "M", Description = "Modification (or rebuild) of existing equipment", IsActive = true},
            new TooltreeType {  Code = "T", Description = "Transfered / moved existing equipment to other location", IsActive = true},
            new TooltreeType {  Code = "C", Description = "During project decided to cancel machine", IsActive = true }
        };

            await context.TooltreeTypes.AddRangeAsync(tooltreeType);
        }
    }



    private static async Task InitializeDeliverableQuestionGroup(ApplicationDbContext context)
    {
        if (!await context.DeliverableQuestionGroups.AnyAsync())
        {
            var deliverableQuestionGroups = new List<DeliverableQuestionGroup>
            {
                new DeliverableQuestionGroup
                {
                    Id=1,
                    Name = "A: Equipment checklist",
                    Description = "",
                    IsActive = true,
                    TooltreeDataId = 1
                },
                new DeliverableQuestionGroup
                {
                    Id=2,
                    Name = "B: Documentation",
                    Description = "",
                    IsActive = true,
                    TooltreeDataId = 1
                },
                new DeliverableQuestionGroup
                {
                    Id=3,
                    Name = "C: Determe asset structure",
                    Description = "",
                    IsActive = true,
                    TooltreeDataId = 1
                },
                new DeliverableQuestionGroup
                {
                    Id=4,
                    Name = "D: Setup Bill of Material",
                    Description = "",
                    IsActive = true,
                    TooltreeDataId = 1
                },
                new DeliverableQuestionGroup
                {
                    Id=5,
                    Name = "E: Identify and assure availability of spare parts",
                    Description = "",
                    IsActive = true,
                    TooltreeDataId = 1
                },
                new DeliverableQuestionGroup
                {
                    Id=6,
                    Name = "F: Prepare and execute MTO (machine try out) ifo capability,reliability & maintainability",
                    Description = "",
                    IsActive = true,
                    TooltreeDataId = 1
                },
                new DeliverableQuestionGroup
                {
                    Id=7,
                    Name = "G: Prepare & provide training",
                    Description = "",
                    IsActive = true,
                    TooltreeDataId = 1
                },
                new DeliverableQuestionGroup
                {
                    Id=8,
                    Name = "H: Execute maintenance schedule",
                    Description = "",
                    IsActive = true,
                    TooltreeDataId = 1
                },
                new DeliverableQuestionGroup
                {
                    Id=9,
                    Name = "I: Setup maintenance program = Maintenance matrix",
                    Description = "",
                    IsActive = true,
                    TooltreeDataId = 1
                },
                new DeliverableQuestionGroup
                {
                    Id=10,
                    Name = "J: Demolisch equipment",
                    Description = "",
                    IsActive = true,
                    TooltreeDataId = 1
                },
            };

            await context.DeliverableQuestionGroups.AddRangeAsync(deliverableQuestionGroups);
        }
    }

    private static async Task InitializeDeliverableQuestion(ApplicationDbContext context)
    {
        if (!await context.DeliverableQuestions.AnyAsync())
        {
            var deliverableQuestion = new List<DeliverableQuestion>
            {
                // A: Equipment checklist
                new DeliverableQuestion
                {
                    Id = 1,
                    Question = "1. Create object checklist maintenance engineer (DR_FAT_SAT)",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 1,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 2,
                    Question = "2. Design review",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 1,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 3,
                    Question = "3. FAT",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 1,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 4,
                    Question = "4. SAT",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 1,
                    ProjectPhaseId = null,
                },

                //B: Documentation
                new DeliverableQuestion
                {
                    Id = 5,
                    Question = "1. DDM check (doc delivery matrix)",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 2,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 6,
                    Question = "2. Documentation follow up file (Status_Report_Documentation_EXCEL)",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 2,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 7,
                    Question = "3. FINAL documentation in Documentation system (VEDOC, NAS GA)",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 2,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 8,
                    Question = "4. Documentation available for Maintenance",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 2,
                    ProjectPhaseId = null,
                },

                //C: Determe asset structure
                new DeliverableQuestion
                {
                    Id = 9,
                    Question = "1. Locaties in Maximo",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 3,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 10,
                    Question = "2. Locaties in Documentation system",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 3,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 11,
                    Question = "3. Asset created in Maximo (Add in tooltree)",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 3,
                    ProjectPhaseId = null,
                },
               
                //D: Setup Bill of Material
                new DeliverableQuestion
                {
                    Id = 12,
                    Question = "1. Buy Part list status (maximo data list)",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 4,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 13,
                    Question = "2. SparePart List in Maximo (BOM)",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 4,
                    ProjectPhaseId = null,
                },

                //E: Identify and assure availability of spare parts
                new DeliverableQuestion
                {
                    Id = 14,
                    Question = "1. Early phase: Determine critical / long delivery spare parts and order (BoughtPart List)",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 5,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 15,
                    Question = "2. Standardize and order new spare parts",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 5,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 16,
                    Question = "3. Check status AS procedure",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 5,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 17,
                    Question = "4. Existing spare parts stock situation adapted",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 5,
                    ProjectPhaseId = null,
                },

                //F: Prepare and execute MTO (machine try out) ifo capability, reliability &maintainability
                new DeliverableQuestion
                {
                    Id = 18,
                    Question = "1. Disturbance followup sytem adapted for objects on location (STW020, STW040)",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 6,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 19,
                    Question = "2. Test hotspare equipment and back up programs",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 6,
                    ProjectPhaseId = null,
                },
                
                //G: Prepare & provide training
                new DeliverableQuestion
                {
                    Id = 20,
                    Question = "1. Plan training line builder, agree content / nr persons + dates",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 7,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 21,
                    Question = "2. Organize training technicians, machine operators:  location, trainer, participants",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 7,
                    ProjectPhaseId = null,
                },
                                
                //H: Execute maintenance schedule
                new DeliverableQuestion
                {
                    Id = 22,
                    Question = "1. Assign operator maintenance tasks to the teams educate,execute and gather feedback",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 8,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 23,
                    Question = "2. Start execution specialized maintenance tasks , educate, execute and gather feedback ",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 8,
                    ProjectPhaseId = null,
                },
                                                
                //I: Setup maintenance program = Maintenance matrix
                new DeliverableQuestion
                {
                    Id = 24,
                    Question = "1. Jobplan in Maximo (WO's are created by Maximo)",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 9,
                    ProjectPhaseId = null,
                },

                //J: Demolisch equipment
                new DeliverableQuestion
                {
                    Id = 25,
                    Question = "1. Delete documentation in documentation system (VEDOC, NAS GA)",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 10,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 26,
                    Question = "2. Clean up Maximo (Location, Asset, BOM,SparePart List....)",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 10,
                    ProjectPhaseId = null,
                },
                new DeliverableQuestion
                {
                    Id = 27,
                    Question = "3. T-Client",
                    Description = null,
                    IsActive = true,
                    QuestionGroupId = 10,
                    ProjectPhaseId = null,
                },
            };

            await context.DeliverableQuestions.AddRangeAsync(deliverableQuestion);
        }
    }


    private static async Task InitializeDeliverableAnswerTypes(ApplicationDbContext context)
    {
        if (!await context.DeliverableAnswerTypes.AnyAsync())
        {
            var answerTypes = new List<DeliverableAnswerType>
        {
            new DeliverableAnswerType
            {
                Answer = "NA",
                Description = "Not applicable",
                Value = 0,
                Order = 1,
                IsActive = true
            },
            new DeliverableAnswerType
            {
                Answer = "0",
                Description = "Not started",
                Value = 0,
                Order = 2,
                IsActive = true
            },
            new DeliverableAnswerType
            {
                Answer = "49",
                Description = "To late",
                Value = 49,
                Order = 3,
                IsActive = true
            },
            new DeliverableAnswerType
            {
                Answer = "50",
                Description = "In progress",
                Value = 50,
                Order = 4,
                IsActive = true
            },
            new DeliverableAnswerType
            {
                Answer = "100",
                Description = "Finished",
                Value = 100,
                Order = 5,
                IsActive = true
            }
        };

            await context.DeliverableAnswerTypes.AddRangeAsync(answerTypes);
        }
    }


}
