using backend.Data;
using backend.Data.Mappers;
using backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class CvService(AppDbContext context) : ICvService
{
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await context.Users.OrderBy(u => u.Name).ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<Experience>> GetAllExperiencesAsync()
    {
        return await context.Experiences
            .OrderBy(e => e.StartDate)
            .ToListAsync();
    }

    public async Task<Experience?> GetExperienceByIdAsync(Guid id)
    {
        return await context.Experiences
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();

    }

    public async Task<IEnumerable<Experience>> GetExperiencesByTypeAsync(string type)
    {
        return await context.Experiences
            .Where(e => e.Type.Equals(type))
            .OrderBy(e => e.StartDate)
            .ToListAsync();
    }

    // TODO: Oppgave 4 ny metode (husk å legge den til i interfacet)
}
