using ListaDeTarefas.API.Contracts;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Application.UseCases.CreateTarefa;
using ListaDeTarefas.Application.UseCases.DeleteTarefa;
using ListaDeTarefas.Application.UseCases.GetAllTarefa;
using ListaDeTarefas.Application.UseCases.GetByIdTarefa;
using ListaDeTarefas.Application.UseCases.UpdateTarefa;
using ListaDeTarefas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.API.Controllers
{
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllTarefaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<GetAllTarefaResponse>>> GetAll([FromServices] IGetAllTarefaUseCase useCase, CancellationToken cancellationToken)
        {
            var response = await useCase.Execute(cancellationToken);

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetByIdTarefaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Tarefa>> GetById([FromServices] IGetByIdTarefaUseCase useCase, int id, CancellationToken cancellationToken)
        {
            var response = await useCase.Execute(id, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateTarefaUseCase), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateTarefaResponse>> Create([FromServices] ICreateTarefaUseCase useCase, CreateTarefaRequest request, CancellationToken cancellationToken)
        {
            var response = await useCase.Execute(request, cancellationToken);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CreateTarefaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateTarefaResponse>> Update([FromServices] IUpdateTarefaUseCase useCase, long id, UpdateTarefaRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id)
            {
                throw new ValidationErrorException(Application.Exceptions.Resources.ErrorMessages.ID_PARAM_NOT_EQUAL_ID_BODY);
            }

            var response = await useCase.Execute(request, cancellationToken);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DeleteTarefaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeleteTarefaResponse>> Delete([FromServices] IDeleteTarefaUseCase useCase, int id, CancellationToken cancellationToken)
        {
            var response = await useCase.Execute(id, cancellationToken);

            return Ok(response);
        }
    }
}