using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradingAnalyticsLab.Domain.Entities;

namespace TradingAnalyticsLab.Infrastructure.Persistence.Configurations;

public sealed class JournalEntryConfiguration
    : IEntityTypeConfiguration<JournalEntry>
{
    public void Configure(
        EntityTypeBuilder<JournalEntry> builder)
    {
        builder.ToTable("journal_entries");

        builder.HasKey(x => x.EntryId);

        builder.Property(x => x.Content)
            .IsRequired();
    }
}