using TrueVote.Web.Entities;

namespace TrueVote.Web.Repositories.Interfaces;

public interface IVoteRepository
{
    Task UpdateAsync(VoteOption voteOption);
    Task<VoteOption> GetBySurveyIdAsync(Guid surveyId);
}