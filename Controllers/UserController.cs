using AbcloudzWebAPI.Contracts.User;
using AbcloudzWebAPI.Mapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AbcloudzWebAPI.Application.User.Commands;
using AbcloudzWebAPI.Application.User.Queries;


namespace AbcloudzWebAPI.Controllers;

[Route("[controller]")]
public class UserController(ISender mediator) : ApiController
{
    private readonly ISender _mediator = mediator;

    [HttpPost("Create")]
    public async Task<IActionResult> Create(UserRequest userRequest)
    {          
        var command = new CreateUserCommand(userRequest.ToDomain());
        var createUserResult = await _mediator.Send(command);

        return createUserResult.Match
            (user => Ok(user),
            Problem);
    }


    [HttpGet("list")]
    public async Task<IActionResult> Get([FromQuery] UserFilterRequest filter)
    {
        var query = new GetUsersQuery(filter.ToApplication());
        var listUsersResult = await _mediator.Send(query);

        return listUsersResult.Match(
            users =>  Ok(new PagedResult<UserResponse> 
                    { Items = users.ToResponseList(),TotalCount = users.Count }),
            Problem);
    }
}
