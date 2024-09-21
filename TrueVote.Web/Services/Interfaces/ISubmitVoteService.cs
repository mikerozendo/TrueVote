namespace TrueVote.Web.Services.Interfaces;

public interface ISubmitVoteService
{
    Task SubmitAsync(Guid surveyId);
}