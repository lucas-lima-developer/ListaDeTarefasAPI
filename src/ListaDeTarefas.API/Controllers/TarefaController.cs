using ListaDeTarefas.Application.UseCases.AddTarefa;
using ListaDeTarefas.Application.UseCases.GetAllTarefa;
using ListaDeTarefas.Application.UseCases.GetByIdTarefa;
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
        public async Task<ActionResult<List<GetAllTarefaResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllTarefaRequest(), cancellationToken);

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
    }
}