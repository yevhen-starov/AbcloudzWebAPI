using AbcloudzWebAPI.Application.Services;
using AbcloudzWebAPI.Contracts.User;
using AbcloudzWebAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AbcloudzWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost("Create")]
    public IActionResult Create(UserRequest userRequest)
    {
        var user = _userService.CreateUser(new User { Id = Guid.NewGuid(),  Name = userRequest.UserName, Email = userRequest.Email, Password = userRequest.Password});

        if (user is null)
            throw new Exception("User not Created");

        return Ok();
    }


    [HttpGet("list")]
    public IEnumerable<UserResponse> Get()
    {
        var users = _userService.GetUsers();

        if (users == null || users.Count == 0)
            return new List<UserResponse>();

        var result = users.Select(u=> new UserResponse { UserId= u.Id, UserName = u.Name});

        return result;
    }
}
