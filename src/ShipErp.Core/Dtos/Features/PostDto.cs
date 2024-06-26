﻿using AutoMapper;
using ShipErp.Core.Domain.Entities;

namespace ShipErp.Core.Dtos.Features;
public class PostDto : PostInListResponse
{
    public Guid CategoryId { get; set; }

    public string? Content { get; set; }

    public Guid AuthorUserId { get; set; }

    public string? Source { get; set; }

    public string? Tags { get; set; }

    public string? SeoDescription { get; set; }

    public DateTime? DateModified { get; set; }
    public bool IsPaid { get; set; }
    public double RoyaltyAmount { get; set; }
    public PostStatus Status { get; set; }

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Post, PostDto>();
        }
    }
}