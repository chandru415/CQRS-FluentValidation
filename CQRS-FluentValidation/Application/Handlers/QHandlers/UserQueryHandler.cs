using Application.Queries;
using Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.QHandlers
{
    public class UserQueryHandler : IRequestHandler<UserQuery, UserResponse>
    {
        public Task<UserResponse> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            /** Realtime - application have to call Repository layer to 
             *  fetch real user from Db */

            return Task.FromResult(new UserResponse
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Name = "Samantha"
            });
        }
    }
}
