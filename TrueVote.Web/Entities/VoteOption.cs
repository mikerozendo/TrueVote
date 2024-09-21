namespace TrueVote.Web.Entities;

public class VoteOption(Guid id, int optionKey)
{
    public Guid Id { get; init; } = id;
    public int OptionKey { get; init; } = optionKey;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}