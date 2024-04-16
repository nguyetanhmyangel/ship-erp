using ShipErp.Core.Domain.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShipErp.Core.Domain.Entities;

[Table("Tags")]
public class Tag : AuditableEntity<Guid>
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    public ICollection<Tag>? Tags { get; set; }
}
