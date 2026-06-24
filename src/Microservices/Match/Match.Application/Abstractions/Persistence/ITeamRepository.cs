using Match.Domain.Entities;

namespace Match.Application.Abstractions.Persistence;

public interface ITeamRepository
{
    Task AddAsync(Team entity, CancellationToken cancellation);

    Task<IReadOnlyList<Team>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellation);

    Task<int> GetCountAsync(CancellationToken cancellation);

    Task<bool> ExistsAsync(int id, CancellationToken);
}
