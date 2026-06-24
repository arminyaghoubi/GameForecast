using Match.Domain.Exceptions;

namespace Match.Domain.Entities;

public class Match
{
    private Match() { }

    public Match(
        int homeTeamId,
        int awayTeamId,
        DateTime matchTime)
    {
        if (homeTeamId == awayTeamId)
            throw new DomainException("Home and away teams cannot be the same.");

        HomeTeamId = homeTeamId;
        AwayTeamId = awayTeamId;
        MatchTime = matchTime;
        Status = MatchStatus.Scheduled;
    }

    public int Id { get; private set; }

    public int HomeTeamId { get; private set; }
    public Team? HomeTeam { get; private set; }

    public int AwayTeamId { get; private set; }
    public Team? AwayTeam { get; private set; }

    public DateTime MatchTime { get; private set; }

    public MatchStatus Status { get; private set; }

    public short? HomeTeamScore { get; private set; }
    public short? AwayTeamScore { get; private set; }

    public void Start()
    {
        if (Status != MatchStatus.Scheduled)
            throw new DomainException("Only scheduled matches can be started.");

        Status = MatchStatus.InProgress;
    }

    public void SetScore(short homeScore, short awayScore)
    {
        if (Status is not MatchStatus.InProgress and not MatchStatus.Scheduled)
            throw new DomainException("Cannot update score when match is not in progress or scheduled.");

        if (homeScore < 0 || awayScore < 0)
            throw new DomainException("Scores cannot be negative.");

        HomeTeamScore = homeScore;
        AwayTeamScore = awayScore;
    }

    public void Completed()
    {
        if (Status != MatchStatus.InProgress)
            throw new DomainException("Only in progress matches can be completed.");

        if (HomeTeamScore is null || AwayTeamScore is null)
            throw new DomainException("Cannot complete match without final score.");

        Status = MatchStatus.Completed;
    }

    public void Cancel()
    {
        if (Status == MatchStatus.Completed)
            throw new DomainException("Completed match cannot be cancell");
    }
}

public enum MatchStatus
{
    Scheduled,
    InProgress,
    Completed,
    Cancelled
}
