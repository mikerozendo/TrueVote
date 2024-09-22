using Microsoft.EntityFrameworkCore;
using TrueVote.Web.Entities;

namespace TrueVote.Web.Repositories;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<ReceivedVote> ReceivedVotes { get; set; }    
    public DbSet<VoteOptionDetails> VoteOptionDetails { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ReceivedVote>()
            .ToTable(nameof(ReceivedVotes))
            .HasKey(voteOption => voteOption.Id);
        
        modelBuilder.Entity<ReceivedVote>()
            .HasIndex(voteOption => voteOption.Id);
        
        modelBuilder.Entity<ReceivedVote>()
            .HasOne<VoteOptionDetails>(voteOption => voteOption.VoteOptionDetails)
            .WithMany(x => x.ReceivedVotes)
            .HasForeignKey(x => x.VoteOptionDetailsId);
        
        modelBuilder.Entity<VoteOptionDetails>()
            .HasMany<ReceivedVote>(voteOption => voteOption.ReceivedVotes)
            .WithOne(x => x.VoteOptionDetails)
            .HasForeignKey(x => x.Id);

        modelBuilder.Entity<VoteOptionDetails>()
            .ToTable(nameof(VoteOptionDetails))
            .HasKey(voteOptionDetails => voteOptionDetails.Id);

        modelBuilder.Entity<VoteOptionDetails>()
            .Property(x => x.FilePath)
            .HasMaxLength(50);
        
        modelBuilder.Entity<VoteOptionDetails>()
            .HasIndex(x => x.OptionKey);
        
        modelBuilder.Entity<VoteOptionDetails>()
            .HasIndex(x => x.Id);
    }
}