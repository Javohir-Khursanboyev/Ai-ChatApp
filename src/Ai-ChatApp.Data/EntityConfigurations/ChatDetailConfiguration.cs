using Ai_ChatApp.Domain.Entities.Chats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ai_ChatApp.Data.EntityConfigurations;

public sealed class ChatDetailConfiguration : IEntityTypeConfiguration<ChatDetail>
{
    public void Configure(EntityTypeBuilder<ChatDetail> builder)
    {
        builder.ToTable("chat_details");

        builder.HasKey(cd => cd.Id);

        builder.Property(cd => cd.Text)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(cd => cd.SenderType)
            .IsRequired();

        builder.HasQueryFilter(cd => !cd.IsDeleted);
    }
}