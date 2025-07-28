using Ai_ChatApp.Domain.Entities.Chats;
using Ai_ChatApp.Domain.Entities.Identity;
using Ai_ChatApp.Domain.Entities.Resources;
using Ai_ChatApp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Ai_ChatApp.Data.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<UserDetail> UserDetails { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatDetail> ChatDetails { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}