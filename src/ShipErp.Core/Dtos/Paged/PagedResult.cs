﻿namespace ShipErp.Core.Dtos.Paged;

public class PagedResult<T> : PagedResultBase where T : class
{
    public List<T> Results { get; set; }

    public PagedResult()
    {
        Results = new List<T>();
    }
}
