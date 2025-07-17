using AbcloudzWebAPI.Application.Services;
using AbcloudzWebAPI.Contracts.User;
using AbcloudzWebAPI.Domain.Models;
using AbcloudzWebAPI.Mapper;
using MediatR;
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
        var user = _userService.CreateUser(userRequest.ToDomain());

        if (user is null)
            throw new Exception("User not Created");

        return Ok();
    }


    [HttpGet("list")]
    public PagedResult<UserResponse> Get([FromQuery] UserFilter filter)
    {
        var users = _userService.GetUsers();

        if (users == null || users.Count == 0)
            return new PagedResult<UserResponse>() {
                Items = new List<UserResponse>(),
                TotalCount = 0 };

        return new PagedResult<UserResponse>
        {
            Items = users.ToResponseList(),
            TotalCount = users.Count
        };
    }
}
