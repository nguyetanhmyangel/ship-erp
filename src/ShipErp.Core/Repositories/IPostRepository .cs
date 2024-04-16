using ShipErp.Core.Domain.Entities;
using ShipErp.Core.Dtos.Features;
using ShipErp.Core.Dtos.Paged;
using ShipErp.Core.Repositories.Base;

namespace ShipErp.Core.Repositories;
public interface IPostRepository : IRepository<Post, Guid>
{
    Task<List<Post>> GetPopularPostsAsync(int count);
    Task<PagedResult<PostInListResponse>> GetPostsPagingAsync(string? keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10);
}
