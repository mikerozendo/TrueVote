using TrueVote.Web.Repositories.Interfaces;
using TrueVote.Web.Services.Interfaces;

namespace TrueVote.Web.Services;

public class SubmitVoteService(IVoteRepository repository) : ISubmitVoteService
{
    public async Task SubmitAsync(Guid surveyId)
    {
        var voteToBeUpdated = await repository.GetBySurveyIdAsync(surveyId);
        voteToBeUpdated.ReceivedVotes++;
        
        await repository.UpdateAsync(voteToBeUpdated);
    }
}