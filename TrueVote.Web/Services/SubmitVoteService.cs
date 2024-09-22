using TrueVote.Web.Entities;
using TrueVote.Web.Repositories.Interfaces;
using TrueVote.Web.Services.Interfaces;

namespace TrueVote.Web.Services;

public class SubmitVoteService(IVoteRepository repository) : ISubmitVoteService
{
    public async Task CreateAsync(int voteOptionKey)
    {
        var voteOption = new ReceivedVote(Guid.NewGuid(), voteOptionKey);
        await repository.CreateAsync(voteOption);
    }
}