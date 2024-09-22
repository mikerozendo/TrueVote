using TrueVote.Web.Entities;
using TrueVote.Web.Repositories.Interfaces;
using TrueVote.Web.Services.Interfaces;

namespace TrueVote.Web.Services;

public class SubmitVoteService(
    IReceivedVotesRepository receivedVotesRepository,
    IVoteOptionsDetailsRepository voteOptionsDetailsRepository) : ISubmitVoteService
{
    public async Task CreateAsync(int voteOptionKey)
    {
        var optionDetails = await voteOptionsDetailsRepository.GetByOptionKeyAsync(voteOptionKey);
        var voteOption = new ReceivedVote(Guid.NewGuid(), optionDetails.Id);
        await receivedVotesRepository.CreateAsync(voteOption);
    }
}