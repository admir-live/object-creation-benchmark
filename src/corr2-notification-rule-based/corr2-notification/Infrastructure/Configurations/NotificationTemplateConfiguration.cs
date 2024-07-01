using Corr2.Notification.PoC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corr2.Notification.PoC.Infrastructure.Configurations;

public class NotificationTemplateConfiguration : IEntityTypeConfiguration<NotificationTemplate>
{
    public void Configure(EntityTypeBuilder<NotificationTemplate> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).IsRequired();

        builder.HasOne(t => t.Recipient)
            .WithMany(u => u.NotificationTemplates)
            .HasForeignKey(t => t.RecipientId);
    }
}
