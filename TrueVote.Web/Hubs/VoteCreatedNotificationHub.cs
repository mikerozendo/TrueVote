using Microsoft.AspNetCore.SignalR;

namespace TrueVote.Web.Hubs;

public class VoteCreatedNotificationHub : Hub
{
    public async Task OnVoteCreated(int voteOptionKey)
    {
        await Clients.Others.SendAsync("OnVoteCreated", voteOptionKey);
    }
}