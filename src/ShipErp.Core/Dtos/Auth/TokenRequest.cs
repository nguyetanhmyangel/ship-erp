﻿namespace ShipErp.Core.Dtos.Auth;
public class TokenRequest
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}
