using Microsoft.EntityFrameworkCore;
using ShipErp.Core.Domain.Identity;
using ShipErp.Core.Repositories;
using ShipErp.Infrastructure.Contexts;
using ShipErp.Infrastructure.Repositories.Base;

namespace ShipErp.Infrastructure.Repositories;
public class UserRepository : RepositoryBase<AppUser, Guid>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task RemoveUserFromRoles(Guid userId, string[] roleNames)
    {
        if (roleNames == null || roleNames.Length == 0)
            return;
        foreach (var roleName in roleNames)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == roleName);
            if (role == null)
            {
                return;
            }
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.RoleId == role.Id && x.UserId == userId);
            if (userRole == null)
            {
                return;
            }
            _context.UserRoles.Remove(userRole);
        }
    }
}
