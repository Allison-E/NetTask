namespace NetTask.Infrastructure.Persistence.Contexts;
public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        var programID = Guid.NewGuid();

        if (Programs.Count() == 0)
            modelBuilder.Entity<Program>()
                .HasData(new List<Program>
                {
                    new() {
                        Title = "Learn C#",
                        Description = "Learn C# in 20 days.",
                        Summary = null,
                        Benefits = null,
                        Criteria = null,
                        Created = DateTime.Now,
                        ETag = Guid.NewGuid().ToString(),
                        KeySkills = new List<string> { "Programming", "Coding", },
                        Id = programID,
                        Modified = DateTime.Now,
                        AdditionalInfo = new()
                        {
                            Duration = null,
                            ApplicationCloseDate = DateTime.Now.AddDays(8),
                            ApplicationOpenDate = DateTime.Now.AddDays(1),
                            StartDate = DateTime.Now.AddDays(9),
                            MaxApplications = 300,
                            Location = new()
                            {
                                Address = "London, UK",
                               IsRemote = true,
                            },
                            Type = Domain.Enums.ProgramTypes.Course,
                            MinQualification = Domain.Enums.Qualifications.HighSchool,
                        }
                    }
                });

        if (ApplicationForms.Count() == 0)
            modelBuilder.Entity<ApplicationForm>()
            .HasData(new List<ApplicationForm>
            {
                new()
                {
                    CoverPhotoId = null,
                    ProgramId = programID,
                    PersonalInfo = new List<ApplicationQuestion>
                    {
                        new() { Message = "First Name", Type = ApplicationQuestionTypes.ShortAnswer, IsHidden = false, IsMandatory = true },
                        new() { Message = "Last Name", Type = ApplicationQuestionTypes.ShortAnswer, IsHidden = false, IsMandatory = true },
                        new() { Message = "Email", Type = ApplicationQuestionTypes.ShortAnswer, IsHidden = false, IsMandatory = true },
                        new() { Message = "Nationality", Type = ApplicationQuestionTypes.ShortAnswer, IsHidden = true, IsMandatory = false, IsInternal = false},
                        new() { Message = "Current Residence", Type = ApplicationQuestionTypes.ShortAnswer, IsHidden = true, IsMandatory = false, IsInternal = false},
                        new() { Message = "ID Number", Type = ApplicationQuestionTypes.Number, IsHidden = true, IsMandatory = false, IsInternal = false},
                        new() { Message = "Date of Birth", Type = ApplicationQuestionTypes.Date, IsHidden = true, IsMandatory = false, IsInternal = false},
                        new() { Message = "Gender", Type = ApplicationQuestionTypes.DropDown, IsHidden = true, IsMandatory = false, IsInternal = false, AdditionalInfo = JObject.FromObject(
                            new DropDownQuestionInfo()
                            {
                                Options = new List<string> { "Male", "Female", },
                                IsOtherEnabled = true,
                            }),
                        },
                    },
                    Profile = new List<ApplicationQuestion>
                    {
                        new() { Message = "Education", Type = ApplicationQuestionTypes.Paragraph, IsHidden = true, IsInternal = false, IsMandatory = false },
                        new() { Message = "Experience", Type = ApplicationQuestionTypes.Paragraph, IsHidden = false, IsInternal = false, IsMandatory = true, AdditionalInfo = JObject.FromObject(
                            new VideoQuestionInfo()
                            {
                                Segments = new List<VideoQuestionSegment>
                                {
                                    new() { Description = "Tell us about your last job experience", MaxDuration = 5, Question = "Tell us about experience", Unit  = VideoTimeUnits.Minute },
                                }
                            }),
                        },
                        new() { Message = "Resume", Type = ApplicationQuestionTypes.FileUpload, IsHidden = true, IsInternal = false, IsMandatory = false },
                    },
                    AdditionalQuestions = null,
                },
            });

        if (Workflows.Count() == 0)
            modelBuilder.Entity<Workflow>()
            .HasData(new List<Workflow>
            {
                new Workflow()
                {
                    ProgramId = programID,
                    Stages = new List<WorkflowStage>
                    {
                        new() { Name = "Applied", IsVisibleToCandidates = true, Type = WorkflowStageTypes.Shortlisting },
                    },
                },
            });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.Created = DateTime.UtcNow;
                entry.Entity.Modified = DateTime.UtcNow;
            }
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.Modified = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Program> Programs { get; set; }
    public DbSet<ApplicationForm> ApplicationForms { get; set; }
    public DbSet<Workflow> Workflows { get; set; }
}
