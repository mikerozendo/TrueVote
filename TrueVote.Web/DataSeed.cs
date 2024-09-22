using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TrueVote.Web.Entities;
using TrueVote.Web.Repositories;

namespace TrueVote.Web;

public static class DataSeed
{
    public static IServiceCollection AddDataSeed(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        // dbContext.Database.EnsureCreated();
        // dbContext.Database.Migrate();
        
        var createdVoteOptionsDetails = dbContext.VoteOptionDetails.ToList();
        if (!createdVoteOptionsDetails.IsNullOrEmpty()) //should populate this table only once
            return services;
        
        List<VoteOptionDetails> voteOptionsDetails =
        [
            new() { OptionKey = 1, FilePath = @"images/boules.jpg" },
            new() { OptionKey = 2, FilePath = @"images/datena.jpeg" },
            new() { OptionKey = 3, FilePath = @"images/instala_drive.jpg" },
            new() { OptionKey = 4, FilePath = @"images/marina.jpg" },
            new() { OptionKey = 5, FilePath = @"images/ricardo_nunes_piscina.jpg" },
            new() { OptionKey = 6, FilePath = @"images/tabatha_amaral.jpg" },
        ];
        
        dbContext.VoteOptionDetails.AddRange(voteOptionsDetails);
        dbContext.SaveChanges();
        return services;
    }
}