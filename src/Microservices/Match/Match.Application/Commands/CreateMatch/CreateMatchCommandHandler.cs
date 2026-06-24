using BuildingBlocks.Application.Commands;
using BuildingBlocks.Application.Results;
using Match.Application.Abstractions.Persistence;
using Match.Domain.Exceptions;

namespace Match.Application.Commands.CreateMatch;

public class CreateMatchCommandHandler(
    IUnitOfWork _unitOfWork,
    IMatchRepository _matchRepository,
    ITeamRepository _teamRepository) : ICommandHandler<CreateMatchCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IMatchRepository _matchRepository = _matchRepository;
    private readonly ITeamRepository _teamRepository = _teamRepository;

    public async Task<Result<int>> Handle(CreateMatchCommand command, CancellationToken cancellation)
    {
        try
        {
            if (!await _teamRepository.ExistsAsync(command.HomeTeamId, cancellation))
                return Result<int>.Failure(new($"Home team with id '{command.HomeTeamId} was not found.'"));

            if (!await _teamRepository.ExistsAsync(command.AwayTeamId, cancellation))
                return Result<int>.Failure(new($"Away team with id '{command.AwayTeamId} was not found.'"));


            Domain.Entities.Match match = new(command.HomeTeamId, command.AwayTeamId, command.MatchTime);

            await _matchRepository.AddAsync(match, cancellation);

            await _unitOfWork.SaveChangesAsync(cancellation);

            return Result<int>.Success(match.Id);
        }
        catch (DomainException ex)
        {
            return Result<int>.Failure(new(ex.Message));
        }
    }
}
