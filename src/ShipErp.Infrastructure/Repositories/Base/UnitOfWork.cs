using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ShipErp.Core.Domain.Identity;
using ShipErp.Core.Repositories;
using ShipErp.Core.Repositories.Base;
using ShipErp.Infrastructure.Contexts;

namespace ShipErp.Infrastructure.Repositories.Base;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context, IMapper mapper, UserManager<AppUser> userManager)
    {
        _context = context;
        Posts = new PostRepository(context, mapper);
        //PostCategories = new PostCategoryRepository(context, mapper);
        Users = new UserRepository(context);
    }
    public IPostRepository Posts { get; private set; }
    //public IPostCategoryRepository PostCategories { get; private set; }

    public IUserRepository Users { get; private set; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
