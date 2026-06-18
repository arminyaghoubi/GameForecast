using Match.Application.Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Match.Infrastructure.Persistence.Repositories;

public class MatchRepository(MatchDbContext context) : IMatchRepository
{
    private readonly MatchDbContext _context = context;

    public async Task AddAsync(Domain.Entities.Match entity, CancellationToken cancellation)
    {
        await _context.Matches
            .AddAsync(entity, cancellation);
    }

    public async Task<IReadOnlyList<Domain.Entities.Match>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellation)
    {
        var skipCount = (pageNumber - 1) * pageSize;

        var matches = await _context.Matches
            .Skip(skipCount)
            .Take(pageSize)
            .ToListAsync(cancellation);

        return matches;
    }

    public async Task<Domain.Entities.Match?> GetByIdAsync(int id, CancellationToken cancellation)
    {
        var match = await _context.Matches
            .FindAsync(id, cancellation);

        return match;
    }

    public async Task<int> GetCountAsync(CancellationToken cancellation)
    {
        var count = await _context.Matches
            .CountAsync(cancellation);

        return count;
    }
}