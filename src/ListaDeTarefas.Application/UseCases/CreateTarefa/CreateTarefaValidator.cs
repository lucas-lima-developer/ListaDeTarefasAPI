using FluentValidation;

namespace ListaDeTarefas.Application.UseCases.CreateTarefa
{
    public class CreateTarefaValidator : AbstractValidator<CreateTarefaRequest>
    {
        public CreateTarefaValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.TITLE_NOT_EMPTY)
                .MaximumLength(50).WithMessage(Exceptions.Resources.ErrorMessages.TITLE_MAX_LENGTH);
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.DESCRIPTION_NOT_EMPTY)
                .MaximumLength(150).WithMessage(Exceptions.Resources.ErrorMessages.DESCRIPTION_MAX_LENGTH);
        }
    }
}
