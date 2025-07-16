using AbcloudzWebAPI.BL.Commands.Users;
using AbcloudzWebAPI.BL.Models;
using AbcloudzWebAPI.BL.Models.Clients.Request;
using AbcloudzWebAPI.BL.Models.Clients.Requests;
using AbcloudzWebAPI.BL.Queries.Users;
using AutoMapper;
using MediatR;
using System.Linq.Expressions;

namespace AbcloudzWebAPI.BL.Services;

public class UserService : IUserService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    public Task<IReadOnlyCollection<UserModel>> GetUsers(GetUsersRequest getUsersRequest)
    {
        ArgumentNullException.ThrowIfNull(getUsersRequest);
        var pagination = _mapper.Map<PaginationModel>(getUsersRequest);

        var filter = ExpressionHelper.BuildEquals<UserModel>(getUsersRequest.ColumnName, getUsersRequest.ColumnValue);
        var userQuery = new GetUsersQuery(pagination, filter);
        
        return _mediator.Send(userQuery);
    }

    public Task<long> CreateUser(CreateUserRequest user)
    {
        ArgumentNullException.ThrowIfNull(user);

        var userModel = _mapper.Map<UserModel>(user);
        var addUserCommand = new CreateUserCommand(userModel);

        return _mediator.Send(addUserCommand);
    }
}
