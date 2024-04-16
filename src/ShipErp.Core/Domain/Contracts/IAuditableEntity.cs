using static ShipErp.Core.Domain.Contracts.IEntity;

namespace ShipErp.Core.Domain.Contracts;

public interface IAuditableEntity<TId> : IAuditableEntity, IEntity<TId>
{
}

public interface IAuditableEntity : IEntity
{
    string? CreatedBy { get; set; }

    DateTime? CreatedAt { get; set; }

    string? LastUpdatedBy { get; set; }

    DateTime? LastUpdatedAt { get; set; }
}
