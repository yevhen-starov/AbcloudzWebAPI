﻿namespace AbcloudzWebAPI.Application.User;

public class UserFilter
{
    public string? Search { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 7;
}
