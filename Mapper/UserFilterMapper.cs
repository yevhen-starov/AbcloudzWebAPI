using AbcloudzWebAPI.Application.User;
using AbcloudzWebAPI.Contracts.User;

namespace AbcloudzWebAPI.Mapper;

public static class UserFilterMapper
{
    public static UserFilter ToApplication(this UserFilterRequest request)
    {
        return new UserFilter()
        {
            Search = request.Search,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
