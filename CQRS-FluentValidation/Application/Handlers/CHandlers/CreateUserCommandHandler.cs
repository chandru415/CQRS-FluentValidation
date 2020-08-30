using Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        public Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new UserResponse
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Name = request.Name
            });
        }
    }
}
