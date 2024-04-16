using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShipErp.Core.Domain.Entities;
using ShipErp.Core.Dtos.Features;
using ShipErp.Core.Dtos.Paged;
using ShipErp.Core.Repositories.Base;
using static ShipErp.Core.Constants.Permissions;

namespace ShipErp.Api.Controllers.AdminApi;

[Route("api/admin/post")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PostController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize(Posts.Create)]
    public async Task<IActionResult> CreatePost([FromBody] CreateUpdatePostRequest request)
    {
        var post = _mapper.Map<CreateUpdatePostRequest, Post>(request);

        _unitOfWork.Posts.Add(post);

        var result = await _unitOfWork.CompleteAsync();
        return result > 0 ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    [Authorize(Posts.Edit)]
    public async Task<IActionResult> UpdatePost(Guid id, [FromBody] CreateUpdatePostRequest request)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        _mapper.Map(request, post);

        var result = await _unitOfWork.CompleteAsync();
        return result > 0 ? Ok() : BadRequest();
    }

    [HttpDelete]
    [Authorize(Posts.Delete)]
    public async Task<IActionResult> DeletePosts([FromQuery] Guid[] ids)
    {
        foreach (var id in ids)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            _unitOfWork.Posts.Remove(post);
        }
        var result = await _unitOfWork.CompleteAsync();
        return result > 0 ? Ok() : BadRequest();
    }

    [HttpGet]
    [Route("{id}")]
    [Authorize(Posts.View)]
    public async Task<ActionResult<PostDto>> GetPostById(Guid id)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }
    [HttpGet]
    [Route("paging")]
    [Authorize(Posts.View)]
    public async Task<ActionResult<PagedResult<PostInListResponse>>> GetPostsPaging(string? keyword, Guid? categoryId,
        int pageIndex, int pageSize = 10)
    {
        var result = await _unitOfWork.Posts.GetPostsPagingAsync(keyword, categoryId, pageIndex, pageSize);
        return Ok(result);
    }
}
