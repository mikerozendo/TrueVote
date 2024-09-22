using Microsoft.EntityFrameworkCore;
using TrueVote.Web.Entities;
using TrueVote.Web.Repositories.Interfaces;

namespace TrueVote.Web.Repositories;

public class VoteRepository(ApplicationDbContext context) : IVoteRepository
{
    public async Task CreateAsync(ReceivedVote receivedVote)
    {
        context.VoteOptions.Add(receivedVote);
        await context.SaveChangesAsync();
    }

    public async Task<List<ReceivedVote>> GetVotesAsync()
    {
        return await context.VoteOptions.ToListAsync();
    }
}