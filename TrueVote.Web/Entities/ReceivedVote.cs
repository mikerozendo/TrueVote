namespace TrueVote.Web.Entities;

public class ReceivedVote(Guid id, int optionKey)
{
    public Guid Id { get; init; } = id;
    public int OptionKey { get; init; } = optionKey;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public VoteOptionDetails VoteOptionDetails { get; init; }
}