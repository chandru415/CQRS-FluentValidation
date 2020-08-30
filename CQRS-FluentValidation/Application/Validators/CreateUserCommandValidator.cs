using Application.Handlers.CHandlers;
using FluentValidation;

namespace Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(s => s.UserId)
                .NotEmpty()
                .NotNull()
                .Matches("^[a-zA-Z0-9]*$")
                .WithMessage("User Id should consists alphanumeric only");
            RuleFor(s => s.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(225);
        }
    }
}
