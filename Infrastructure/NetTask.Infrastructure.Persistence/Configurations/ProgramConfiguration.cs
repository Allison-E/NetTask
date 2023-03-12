using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetTask.Infrastructure.Persistence.Configurations;
internal class ProgramConfiguration: IEntityTypeConfiguration<Program>
{
    public void Configure(EntityTypeBuilder<Program> builder)
    {
        builder.OwnsOne(
                p => p.AdditionalInfo,
                ad =>
                {
                    ad.ToJsonProperty("AdditionalInfo");
                    ad.Property(a => a.StartDate).ToJsonProperty("StartDate");
                    ad.Property(a => a.ApplicationOpenDate).ToJsonProperty("ApplicationOpenDate");
                    ad.Property(a => a.ApplicationCloseDate).ToJsonProperty("ApplicationCloseDate");
                    ad.Property(a => a.Duration).ToJsonProperty("Duration");
                    ad.Property(a => a.MinimumQualification).ToJsonProperty("MinQualification");
                    ad.Property(a => a.MaximumApplications).ToJsonProperty("MaxApplications");
                    ad.OwnsOne(a => a.Location);
                });

        builder.Property(p => p.ETag)
            .IsETagConcurrency();
    }
}
