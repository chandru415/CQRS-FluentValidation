using Application.Queries;
using FluentValidation;

namespace Application.Validators
{
    public class UserQueryValidator : AbstractValidator<UserQuery>
    {
        public UserQueryValidator()
        {
            RuleFor(x => x.UserId)
             .NotNull()
             .NotEmpty()
             .Matches("^[a-zA-Z0-9]*$");
        }
    }
}
