namespace AbcloudzWebAPI.Contracts.User
{
    public class UserFilterRequest
    {
        public string? Search { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
