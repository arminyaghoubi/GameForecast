using BuildingBlocks.Application.Commands;
using BuildingBlocks.Application.Results;

namespace Match.Application.Commands.CreateMatch;

public record CreateMatchCommand(
    int HomeTeamId,
    int AwayTeamId,
    DateTime MatchTime) : ICommand<Result<int>>
{ }
