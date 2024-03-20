using System.Reflection;
using Homework.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Notes.Domain.Notes;

namespace Homework.Infrastructure.Common.Persistence;

public class HomeworkDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    public DbSet<Note> Notes { get; set; } = null!;

    public async Task CommitChangesAsync()
    {
        await SaveChangesAsync();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}