namespace EventManagement.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using EventManagement.Domain.Entities;

public class EventManagementDbContext : DbContext
{
    public DbSet<Event> Events => Set<Event>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RoleUser> RoleUsers => Set<RoleUser>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<RoleUserHistory> RoleUserHistories => Set<RoleUserHistory>();

    public EventManagementDbContext(DbContextOptions<EventManagementDbContext> options)
        : base(options)
    {
    }


}
