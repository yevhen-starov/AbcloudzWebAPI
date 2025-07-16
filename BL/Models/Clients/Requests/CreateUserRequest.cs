using AbcloudzWebAPI.BL.Models.Clients.Requests;

namespace AbcloudzWebAPI.BL.Models.Clients.Request;

public class CreateUserRequest
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }
}
