using Microsoft.EntityFrameworkCore;
using TrueVote.Web.Entities;

namespace TrueVote.Web.Repositories;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<VoteOption> VoteOptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Survey>()
            .ToTable(nameof(Surveys))
            .HasKey(survey => survey.Id);
        
        modelBuilder.Entity<Survey>()
            .HasIndex(survey => survey.Id);
        
        modelBuilder.Entity<VoteOption>()
            .ToTable(nameof(VoteOptions))
            .HasKey(voteOption => voteOption.Id);
        
        modelBuilder.Entity<VoteOption>()
            .HasIndex(voteOption => voteOption.Id);
        
        modelBuilder.Entity<VoteOption>()
            .HasIndex(voteOption => voteOption.SurveyId);

        modelBuilder.Entity<VoteOption>()
            .HasOne(voteOption => voteOption.Survey)
            .WithMany(survey => survey.VoteOptions)
            .HasForeignKey(voteOption => voteOption.SurveyId);
    }
}