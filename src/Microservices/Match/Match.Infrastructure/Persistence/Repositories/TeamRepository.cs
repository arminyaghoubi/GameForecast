using Match.Application.Abstractions.Persistence;
using Match.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Match.Infrastructure.Persistence.Repositories;

public class TeamRepository(MatchDbContext context) : ITeamRepository
{
    private readonly MatchDbContext _context = context;

    public async Task AddAsync(Team entity, CancellationToken cancellation)
    {
        await _context.Teams
            .AddAsync(entity, cancellation);
    }

    public async Task<IReadOnlyList<Team>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellation)
    {
        var skipCount = (pageNumber - 1) * pageSize;
        
        var teams = await _context.Teams
            .Skip(skipCount)
            .Take(pageSize)
            .ToListAsync(cancellation);

        return teams;
    }

    public async Task<int> GetCountAsync(CancellationToken cancellation)
    {
        var count = await _context.Teams
            .CountAsync(cancellation);

        return count;
    }
}
