using Microsoft.EntityFrameworkCore;
using TrueVote.Web.Entities;
using TrueVote.Web.Repositories.Interfaces;

namespace TrueVote.Web.Repositories;

public class VoteRepository(ApplicationDbContext context) : IVoteRepository
{
    public async Task CreateAsync(VoteOption voteOption)
    {
        context.VoteOptions.Add(voteOption);
        await context.SaveChangesAsync();
    }

    public async Task<List<VoteOption>> GetVotesAsync()
    {
        return await context.VoteOptions.ToListAsync();
    }
}