using Ai_ChatApp.Data.Repositories;
using Ai_ChatApp.Domain.Entities.Chats;
using Ai_ChatApp.Domain.Entities.Identity;
using Ai_ChatApp.Domain.Entities.Resources;
using Ai_ChatApp.Domain.Entities.Users;

namespace Ai_ChatApp.Data.UnitOfWorks;

public interface IUnitOfWork
{
    IRepository<User> Users { get; }
    IRepository<UserDetail> UserDetails { get; }
    IRepository<Role> Roles { get; }
    IRepository<Permission> Permissions { get; }
    IRepository<RolePermission> RolePermissions { get; }
    IRepository<UserRole> UserRoles { get; }
    IRepository<Asset> Assets { get; }
    IRepository<Chat> Chats { get; }
    IRepository<ChatDetail> ChatDetails { get; }

    Task<bool> SaveAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
}