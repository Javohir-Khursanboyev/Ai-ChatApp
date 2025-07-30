using Ai_ChatApp.Data.Contexts;
using Ai_ChatApp.Data.Repositories;
using Ai_ChatApp.Domain.Entities.Chats;
using Ai_ChatApp.Domain.Entities.Identity;
using Ai_ChatApp.Domain.Entities.Resources;
using Ai_ChatApp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ai_ChatApp.Data.UnitOfWorks;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    private IDbContextTransaction transaction;
    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
        Chats = new Repository<Chat>(context);
        Roles = new Repository<Role>(context);
        Users = new Repository<User>(context);
        Assets = new Repository<Asset>(context);
        Permissions = new Repository<Permission>(context);
        UserDetails = new Repository<UserDetail>(context);
        UserRoles = new Repository<UserRole>(context);
        RolePermissions = new Repository<RolePermission>(context);
        ChatDetails = new Repository<ChatDetail>(context);
    }
    public IRepository<Chat> Chats { get; }

    public IRepository<Role> Roles { get; }

    public IRepository<User> Users { get; }

    public IRepository<Asset> Assets { get; }

    public IRepository<Permission> Permissions { get; }

    public IRepository<UserDetail> UserDetails { get; }

    public IRepository<UserRole> UserRoles { get; }

    public IRepository<ChatDetail> ChatDetails { get; }

    public IRepository<RolePermission> RolePermissions { get; }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task BeginTransactionAsync()
    {
        transaction = await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await transaction.CommitAsync();
    }


    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}