namespace Match.Application.Abstractions.Persistence;

public interface IMatchRepository
{
    Task<Domain.Entities.Match?> GetByIdAsync(int id, CancellationToken cancellation);

    Task<IReadOnlyList<Domain.Entities.Match>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellation);

    Task<int> GetCountAsync(CancellationToken cancellation);

    Task AddAsync(Domain.Entities.Match entity, CancellationToken cancellation);
}
