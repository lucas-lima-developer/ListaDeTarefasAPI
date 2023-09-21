using FluentValidation;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.Add
{
    public class AddTarefaRequestValidator : AbstractValidator<AddTarefaRequest>
    {
        public AddTarefaRequestValidator()
        {
            RuleFor(request => request.Title).NotEmpty().MinimumLength(3).MaximumLength(30);
            RuleFor(request => request.Description).MaximumLength(200);
            RuleFor(request => request.Priority).IsInEnum();
            RuleFor(request => request.LimitDate).GreaterThan(DateTime.Now);
        }
    }
}
