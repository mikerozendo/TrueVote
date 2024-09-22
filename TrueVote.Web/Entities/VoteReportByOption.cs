namespace TrueVote.Web.Entities;

public class VoteReportByOption
{
    public Guid OptionDetailsId { get; private set; }
    public int ReceivedVotesAmout { get; private set; }
    public int OtherCompetitorReceivedVotes { get; private set; }
    public int ReceivedVotesPercenteage { get; private set; }

    public VoteReportByOption(IGrouping<Guid, ReceivedVote> currentVoteOption, int otherCompetitorReceivedVotes)
    {
        OptionDetailsId = currentVoteOption.Key;
        ReceivedVotesAmout = currentVoteOption.Count();
        OtherCompetitorReceivedVotes = otherCompetitorReceivedVotes;
        
        if (ReceivedVotesAmout > 0)
            ReceivedVotesPercenteage = (ReceivedVotesAmout * 100) / OtherCompetitorReceivedVotes;
    }
}