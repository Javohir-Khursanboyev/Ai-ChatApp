using Ai_ChatApp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ai_ChatApp.Data.EntityConfigurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        // FirstName
        builder.Property(user => user.FirstName)
            .IsRequired()
            .HasMaxLength(255);

        // LastName
        builder.Property(user => user.LastName)
            .HasMaxLength(255);

        // Email
        builder.Property(user => user.Email)
            .IsRequired()
            .HasMaxLength(255);
        builder.HasIndex(user => user.Email).IsUnique();

        // Password
        builder.Property(user => user.Password)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasQueryFilter(user => !user.IsDeleted);

        // One-to-one: User ↔ UserDetail
        builder.HasOne(user => user.UserDetail)
            .WithOne(detail => detail.User)
            .HasForeignKey<UserDetail>(detail => detail.UserId)
            .OnDelete(DeleteBehavior.Cascade); 

        // One-to-many: User ↔ Chats
        builder.HasMany(user => user.Chats)
            .WithOne(chat => chat.User)
            .HasForeignKey(chat => chat.UserId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}