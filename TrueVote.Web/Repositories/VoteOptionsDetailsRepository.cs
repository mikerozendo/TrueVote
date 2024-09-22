using Microsoft.EntityFrameworkCore;
using TrueVote.Web.Entities;
using TrueVote.Web.Repositories.Interfaces;

namespace TrueVote.Web.Repositories;

public class VoteOptionsDetailsRepository(ApplicationDbContext context) : IVoteOptionsDetailsRepository
{
    public async Task<VoteOptionDetails> GetByOptionKeyAsync(int optionKey)
        => await context.VoteOptionDetails.SingleAsync(x => x.OptionKey == optionKey);
}