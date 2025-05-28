namespace EventManagement.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using EventManagement.Domain.Entities;

public class EventManagementDbContext : DbContext
{
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Activity> Activities => Set<Activity>();

    public EventManagementDbContext(DbContextOptions<EventManagementDbContext> options)
        : base(options)
    {
    }
}
