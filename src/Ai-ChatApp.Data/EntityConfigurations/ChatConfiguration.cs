using Ai_ChatApp.Domain.Entities.Chats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ai_ChatApp.Data.EntityConfigurations;

public sealed class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.ToTable("chats");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasQueryFilter(c => !c.IsDeleted);

        builder.HasMany<ChatDetail>()
            .WithOne(cd => cd.Chat)
            .HasForeignKey(cd => cd.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}