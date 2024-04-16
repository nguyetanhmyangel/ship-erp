using ShipErp.Core.Dtos.Systems;

namespace ShipErp.Core.Models.System;
public class PermissionDto
{
    public string RoleId { get; set; }
    public IList<RoleClaimsDto> RoleClaims { get; set; }
}

