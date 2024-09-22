using TrueVote.Web.Entities;

namespace TrueVote.Web.Repositories.Interfaces;

public interface IReceivedVotesRepository
{
    Task CreateAsync(ReceivedVote receivedVote);
    Task<List<ReceivedVote>> GetVotesAsync();
}