using Microsoft.AspNetCore.SignalR;

namespace TrueVote.Web.Hubs;

public class VoteCreatedNotificationHub : Hub
{
    public async Task OnVoteCreated()
    {
        await Clients.Others.SendAsync("OnVoteCreated", "Toma cadeirada");
    }
}