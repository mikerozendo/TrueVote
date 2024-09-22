namespace TrueVote.Web.Entities;

public class VoteOptionDetails
{
    public int OptionKey { get; set; }
    public string FilePath { get; set; }
    public IEnumerable<ReceivedVote> ReceivedVotes { get; set; }
}