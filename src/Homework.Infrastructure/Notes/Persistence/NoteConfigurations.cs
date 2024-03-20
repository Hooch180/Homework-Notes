using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain.Notes;

namespace Homework.Infrastructure.Notes.Persistence;

public class NoteConfigurations : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasKey(n => n.Id);
        
        builder.Property(n => n.Id)
            .ValueGeneratedNever();
        
        builder.Property(n => n.Content)
            .HasMaxLength(1000);
    }
}