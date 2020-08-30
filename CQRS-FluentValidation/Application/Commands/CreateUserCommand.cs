using Application.Responses;
using MediatR;

namespace Application.Handlers.CHandlers
{
    public class CreateUserCommand : IRequest<UserResponse>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}
