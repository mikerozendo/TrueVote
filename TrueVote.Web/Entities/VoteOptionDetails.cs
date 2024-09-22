namespace TrueVote.Web.Entities;

public class VoteOptionDetails
{
    public Guid Id { get; set; }
    public int OptionKey { get; set; }
    public string FilePath { get; set; }
    public IEnumerable<ReceivedVote> ReceivedVotes { get; set; }
}