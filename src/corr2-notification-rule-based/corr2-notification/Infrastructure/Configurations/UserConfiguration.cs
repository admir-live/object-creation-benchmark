using Corr2.Notification.PoC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corr2.Notification.PoC.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Username).IsRequired();
        builder.Property(u => u.Email).IsRequired();

        builder.HasMany(u => u.NotificationTemplates)
            .WithOne(t => t.Recipient)
            .HasForeignKey(t => t.RecipientId);
    }
}
