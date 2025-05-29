namespace EventManagement.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using EventManagement.Domain.Entities;

public class EventManagementDbContext : DbContext
{
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Activity> Activities => Set<Activity>();

    public DbSet<Resource> Resources => Set<Resource>();

    public DbSet<ResourceAssignment> ResourceAssignments => Set<ResourceAssignment>();


    public EventManagementDbContext(DbContextOptions<EventManagementDbContext> options)
        : base(options)
    {
    }

    public DbSet<EventReport> EventReports { get; set; }

}
