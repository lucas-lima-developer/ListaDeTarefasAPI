using FluentValidation;
using ListaDeTarefas.Application.Requests;

namespace ListaDeTarefas.Application.Validators
{
    public class UpdateTarefaValidator : AbstractValidator<UpdateTarefaRequest>
    {
        public UpdateTarefaValidator()
        {
            RuleFor(tarefa => tarefa.Id)
                .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.ID_EMPTY);
            RuleFor(tarefa => tarefa.Title)
                .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.TITLE_NOT_EMPTY)
                .MaximumLength(50).WithMessage(Exceptions.Resources.ErrorMessages.TITLE_MAX_LENGTH);
            RuleFor(tarefa => tarefa.Description)
                .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.DESCRIPTION_NOT_EMPTY)
                .MaximumLength(150).WithMessage(Exceptions.Resources.ErrorMessages.DESCRIPTION_MAX_LENGTH);
            RuleFor(tarefa => tarefa.IsCompleted)
                .NotNull().WithMessage(Exceptions.Resources.ErrorMessages.IS_COMPLETED_NOT_EMPTY);
        }
    }
}
