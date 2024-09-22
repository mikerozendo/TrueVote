using Microsoft.EntityFrameworkCore;
using TrueVote.Web.Entities;
using TrueVote.Web.Repositories.Interfaces;

namespace TrueVote.Web.Repositories;

public class ReceivedVotesRepository(ApplicationDbContext context) : IReceivedVotesRepository
{
    public async Task CreateAsync(ReceivedVote receivedVote)
    {
        context.ReceivedVotes.Add(receivedVote);
        await context.SaveChangesAsync();
    }

    public async Task<List<ReceivedVote>> GetVotesAsync()
    {
        return await context.ReceivedVotes.ToListAsync();
    }
}