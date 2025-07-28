using Ai_ChatApp.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ai_ChatApp.Data.EntityConfigurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");

        builder.HasKey(role => role.Id);

        builder.Property(role => role.Name).IsRequired();

        builder.HasIndex(role => role.Name).IsUnique();

        builder.HasQueryFilter(role => !role.IsDeleted);

        builder.HasData(
                new Role { Id = Role.AdminId, Name = Role.Admin, CreatedAt = new DateTime(2025, 01, 01) },
                new Role { Id = Role.UserId, Name = Role.User, CreatedAt = new DateTime(2025, 01, 01) }
                //new Role { Id = 3, Name = "Guest", CreatedAt = DateTime.UtcNow }
            );
    }
}