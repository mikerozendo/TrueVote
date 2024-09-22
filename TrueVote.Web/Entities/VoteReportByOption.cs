using Microsoft.EntityFrameworkCore.Metadata;

namespace TrueVote.Web.Entities;

public sealed class VoteReportByOption
{
    public VoteOptionDetails VoteOptionDetails { get; private set; }
    public int ReceivedVotesAmount { get; private set; }
    public int ReceivedVotesPercenteage { get; private set; }

    public VoteReportByOption(VoteOptionDetails details, int receivedVOtesAmount, int votesForALlCompetitors)
    {
        VoteOptionDetails = details;
        ReceivedVotesAmount = receivedVOtesAmount;

        if (ReceivedVotesAmount > 0)
            ReceivedVotesPercenteage = (ReceivedVotesAmount * 100) / votesForALlCompetitors;
    }
}