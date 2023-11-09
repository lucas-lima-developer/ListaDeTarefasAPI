using FluentValidation;
using ListaDeTarefas.Application.Requests;

namespace ListaDeTarefas.Application.Validators
{
    public class CreateTarefaValidator : AbstractValidator<CreateTarefaRequest>
    {
        public CreateTarefaValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.TAREFA_TITLE_EMPTY)
                .MaximumLength(50).WithMessage(Exceptions.Resources.ErrorMessages.TAREFA_TITLE_MAX_LENGTH);
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.TAREFA_DESCRIPTION_EMPTY)
                .MaximumLength(150).WithMessage(Exceptions.Resources.ErrorMessages.TAREFA_DESCRIPTION_MAX_LENGTH);
        }
    }
}
