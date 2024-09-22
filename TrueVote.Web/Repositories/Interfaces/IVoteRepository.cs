using TrueVote.Web.Entities;

namespace TrueVote.Web.Repositories.Interfaces;

public interface IVoteRepository
{
    Task CreateAsync(ReceivedVote receivedVote);
    Task<List<ReceivedVote>> GetVotesAsync();
}