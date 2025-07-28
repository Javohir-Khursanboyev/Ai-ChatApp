using Ai_ChatApp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ai_ChatApp.Data.EntityConfigurations;

public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
{
    public void Configure(EntityTypeBuilder<UserDetail> builder)
    {
        builder.ToTable("user_details");

        builder.HasKey(detail => detail.Id);

        builder.Property(detail => detail.Address)
            .HasMaxLength(500);

        builder.HasOne(detail => detail.Picture)
            .WithMany()
            .HasForeignKey(detail => detail.PictureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}