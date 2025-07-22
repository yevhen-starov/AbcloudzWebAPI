namespace AbcloudzWebAPI.Contracts.User;

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
}
