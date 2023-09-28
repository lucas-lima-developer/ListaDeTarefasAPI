using FluentValidation;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll
{
    public class GetAllTarefaValidator : AbstractValidator<GetAllTarefaRequest>
    {
        public GetAllTarefaValidator() { }
    }
}
