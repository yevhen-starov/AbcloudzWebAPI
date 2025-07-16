using AbcloudzWebAPI.BL.Models;
using AbcloudzWebAPI.BL.Models.Clients.Request;
using AbcloudzWebAPI.BL.Models.Clients.Requests;
using AbcloudzWebAPI.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbcloudzWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(
        IUserService userService,
        ILogger<UserController> logger)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetUsers([FromQuery]GetUsersRequest getUsersRequest)
    {
        var result = await _userService.GetUsers(getUsersRequest);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest user)
    {
        var result = await _userService.CreateUser(user);

        return Ok(result);
    }
}
