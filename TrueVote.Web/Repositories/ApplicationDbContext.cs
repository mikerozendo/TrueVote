using Microsoft.EntityFrameworkCore;
using TrueVote.Web.Entities;

namespace TrueVote.Web.Repositories;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<VoteOption> VoteOptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<VoteOption>()
            .ToTable(nameof(VoteOptions))
            .HasKey(voteOption => voteOption.Id);
        
        modelBuilder.Entity<VoteOption>()
            .HasIndex(voteOption => voteOption.Id);
        
        modelBuilder.Entity<VoteOption>()
            .HasIndex(voteOption => voteOption.OptionKey);
    }
}