using ShipErp.Core.Domain.Identity;
using ShipErp.Core.Repositories.Base;

namespace ShipErp.Core.Repositories;

public interface IUserRepository : IRepository<AppUser, Guid>
{
    Task RemoveUserFromRoles(Guid userId, string[] roles);
}

