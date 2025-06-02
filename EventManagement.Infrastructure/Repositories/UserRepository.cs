namespace EventManagement.Infrastructure.Repositories;

using EventManagement.Domain.Entities;
using EventManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using EventManagement.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly EventManagementDbContext _context;

    public UserRepository(EventManagementDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.id;
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.id == id);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await GetUserByIdAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}

