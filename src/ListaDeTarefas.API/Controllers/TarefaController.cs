using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Application.UseCases.CreateTarefa;
using ListaDeTarefas.Application.UseCases.DeleteTarefa;
using ListaDeTarefas.Application.UseCases.GetAllTarefa;
using ListaDeTarefas.Application.UseCases.GetByIdTarefa;
using ListaDeTarefas.Application.UseCases.UpdateTarefa;
using ListaDeTarefas.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.API.Controllers
{
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TarefaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllTarefaResponse>>> GetAll([FromServices] IGetAllTarefaUseCase useCase, CancellationToken cancellationToken)
        {
            var response = await useCase.Execute(cancellationToken);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetById(long id, CancellationToken cancellationToken)
        {
            var request = new GetByIdTarefaRequest(id);
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateTarefaResponse>> Create(CreateTarefaRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateTarefaResponse>> Update(long id, UpdateTarefaRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id)
            {
                throw new ValidationErrorException(Application.Exceptions.Resources.ErrorMessages.ID_PARAM_NOT_EQUAL_ID_BODY);
            }

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteTarefaResponse>> Delete(long id, CancellationToken cancellationToken)
        {
            var request = new DeleteTarefaRequest(id);

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}