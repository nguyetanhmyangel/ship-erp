using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShipErp.Core.Domain.Entities;
using ShipErp.Core.Dtos.Features;
using ShipErp.Core.Dtos.Paged;
using ShipErp.Core.Repositories;
using ShipErp.Infrastructure.Contexts;
using ShipErp.Infrastructure.Repositories.Base;

namespace ShipErp.Infrastructure.Repositories;
public class PostRepository : RepositoryBase<Post, Guid>, IPostRepository
{
    private readonly IMapper _mapper;
    public PostRepository(ApplicationDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public Task<List<Post>> GetPopularPostsAsync(int count)
    {
        return _context.Posts.OrderByDescending(x => x.ViewCount).Take(count).ToListAsync();
    }

    public async Task<PagedResult<PostInListResponse>> GetPostsPagingAsync(string? keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10)
    {
        var query = _context.Posts.AsQueryable();
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(x => x.Name.Contains(keyword));
        }

        if (categoryId.HasValue)
        {
            query = query.Where(x => x.CategoryId == categoryId.Value);
        }

        var totalRow = await query.CountAsync();

        query = query.OrderByDescending(x => x.CreatedAt)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);

        return new PagedResult<PostInListResponse>
        {
            Results = await _mapper.ProjectTo<PostInListResponse>(query).ToListAsync(),
            CurrentPage = pageIndex,
            RowCount = totalRow,
            PageSize = pageSize
        };
    }
}