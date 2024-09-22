using TrueVote.Web.Entities;
using TrueVote.Web.Repositories.Interfaces;
using TrueVote.Web.Services.Interfaces;

namespace TrueVote.Web.Services;

public class VoteOptionDetailsService(IVoteOptionsDetailsRepository repository) : IVoteOptionDetailsService
{
    public async Task<IEnumerable<VoteOptionDetails>> GetAsync()
        => await repository.GetAsync();
}