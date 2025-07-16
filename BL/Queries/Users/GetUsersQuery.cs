using AbcloudzWebAPI.BL.Models;
using MediatR;
using System.Linq.Expressions;

namespace AbcloudzWebAPI.BL.Queries.Users;

public class GetUsersQuery : IRequest<IReadOnlyCollection<UserModel>>
{
    public GetUsersQuery(PaginationModel paginationModel, Expression<Func<UserModel, bool>> filterExpressionModel)
    {
        PaginationModel = paginationModel ?? throw new ArgumentNullException(nameof(paginationModel));
        FilterExpressionModel = filterExpressionModel;
    }

    public PaginationModel PaginationModel { get; }

    public Expression<Func<UserModel, bool>> FilterExpressionModel { get; }
}
