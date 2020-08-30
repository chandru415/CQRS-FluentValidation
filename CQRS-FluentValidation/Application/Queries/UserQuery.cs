using Application.Responses;
using MediatR;

namespace Application.Queries
{
    public class UserQuery : IRequest<UserResponse>
    {
        public string UserId { get; set; }
    }
}
