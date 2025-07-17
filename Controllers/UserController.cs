using AbcloudzWebAPI.Application.Services;
using AbcloudzWebAPI.Contracts.User;
using AbcloudzWebAPI.Domain.Models;
using AbcloudzWebAPI.Mapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AbcloudzWebAPI.Application.User.Commands;
using AbcloudzWebAPI.Application.User.Queries;

namespace AbcloudzWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(ISender mediator) : ControllerBase
{
    private readonly ISender _mediator = mediator;

    [HttpPost("Create")]
    public async Task<IActionResult> Create(UserRequest userRequest)
    {
        var command = new CreateUserCommand(userRequest.ToDomain());
        var user = await _mediator.Send(command);

        if (user is null)
            throw new Exception("User not Created");
    
        return Ok();
    }


    [HttpGet("list")]
    public async Task<PagedResult<UserResponse>> Get([FromQuery] UserFilterRequest filter)
    {
        var query = new GetUsersQuery(filter.ToApplication());
        var users = await _mediator.Send(query);

        if (users == null || users.Count == 0)
        {
            return new PagedResult<UserResponse>()
            {
                Items = new List<UserResponse>(),
                TotalCount = 0
            };
        }

        return new PagedResult<UserResponse>
        {
            Items = users.ToResponseList(),
            TotalCount = users.Count
        };
    }
}
