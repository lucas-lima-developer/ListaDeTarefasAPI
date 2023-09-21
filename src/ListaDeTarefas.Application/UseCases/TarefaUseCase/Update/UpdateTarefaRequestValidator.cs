using FluentValidation;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.Update
{
    public class UpdateTarefaRequestValidator : AbstractValidator<UpdateTarefaRequest>
    {
        public UpdateTarefaRequestValidator()
        {
            RuleFor(request => request.Id).NotEmpty().GreaterThan(0);
            RuleFor(request => request.Title).NotEmpty().MinimumLength(3).MaximumLength(30);
            RuleFor(request => request.Description).MaximumLength(200);
            RuleFor(request => request.Priority).IsInEnum();
            RuleFor(request => request.LimitDate).GreaterThan(DateTime.Now);
            RuleFor(request => request.IsCompleted).NotNull();
        }
    }
}
