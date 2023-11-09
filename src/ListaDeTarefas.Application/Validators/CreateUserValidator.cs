using FluentValidation;
using ListaDeTarefas.Application.Requests;

namespace ListaDeTarefas.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator() 
        { 
            RuleFor(x => x.Email)
                    .EmailAddress().WithMessage(Exceptions.Resources.ErrorMessages.USER_EMAIL_WRONG_FORMAT)
                    .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.USER_EMAIL_EMPTY);
            RuleFor(x => x.Password)
                    .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.USER_PASSWORD_EMPTY)
                    .MinimumLength(5).WithMessage(Exceptions.Resources.ErrorMessages.USER_PASSWORD_MIN_LENGTH)
                    .MaximumLength(20).WithMessage(Exceptions.Resources.ErrorMessages.USER_PASSWORD_MAX_LENGTH);
        }
    }
}
