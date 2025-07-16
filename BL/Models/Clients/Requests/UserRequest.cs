using System.ComponentModel.DataAnnotations;

namespace AbcloudzWebAPI.BL.Models.Clients.Request;

public class UserRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}
