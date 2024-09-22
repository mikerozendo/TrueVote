using Microsoft.EntityFrameworkCore;
using TrueVote.Web.Entities;

namespace TrueVote.Web.Repositories;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<ReceivedVote> VoteOptions { get; set; }    
    public DbSet<VoteOptionDetails> VoteOptionDetails { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ReceivedVote>()
            .ToTable(nameof(VoteOptions))
            .HasKey(voteOption => voteOption.Id);
        
        modelBuilder.Entity<ReceivedVote>()
            .HasIndex(voteOption => voteOption.Id);
        
        modelBuilder.Entity<ReceivedVote>()
            .HasIndex(voteOption => voteOption.OptionKey);
        
        modelBuilder.Entity<ReceivedVote>()
            .HasOne<VoteOptionDetails>(voteOption => voteOption.VoteOptionDetails)
            .WithMany(x => x.ReceivedVotes)
            .HasForeignKey(x => x.OptionKey);
        
        modelBuilder.Entity<VoteOptionDetails>()
            .HasMany<ReceivedVote>(voteOption => voteOption.ReceivedVotes)
            .WithOne(x => x.VoteOptionDetails)
            .HasForeignKey(x => x.OptionKey);

        modelBuilder.Entity<VoteOptionDetails>()
            .ToTable(nameof(VoteOptionDetails))
            .HasKey(x => x.OptionKey);
        
        modelBuilder.Entity<VoteOptionDetails>()
            .HasIndex(x => x.OptionKey);
    }
}