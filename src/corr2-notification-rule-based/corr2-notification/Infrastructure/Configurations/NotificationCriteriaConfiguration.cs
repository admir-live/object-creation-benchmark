using Corr2.Notification.PoC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corr2.Notification.PoC.Infrastructure.Configurations;

public class NotificationCriteriaConfiguration : IEntityTypeConfiguration<NotificationCriteria>
{
    public void Configure(EntityTypeBuilder<NotificationCriteria> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Expression).IsRequired();
        builder.Property(c => c.IsActive).IsRequired();
        builder.Property(c => c.MessageTemplate).IsRequired();

        builder.HasOne(c => c.Template)
            .WithMany(t => t.Criteria)
            .HasForeignKey(c => c.TemplateId);
    }
}
