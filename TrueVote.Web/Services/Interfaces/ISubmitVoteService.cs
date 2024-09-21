namespace TrueVote.Web.Services.Interfaces;

public interface ISubmitVoteService
{
    Task CreateAsync(int optionKey);
}