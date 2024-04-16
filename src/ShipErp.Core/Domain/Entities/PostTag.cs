using Microsoft.EntityFrameworkCore;
using ShipErp.Core.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShipErp.Core.Domain.Entities;

[Table("PostTags")]
[PrimaryKey(nameof(PostId), nameof(TagId))]

public class PostTag : AuditableEntity
{
    public Guid PostId { set; get; }
    public Guid TagId { set; get; }
    [ForeignKey("TagId")]
    public required Tag Tag { get; set; }
}
