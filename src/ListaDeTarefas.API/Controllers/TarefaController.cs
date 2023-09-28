using FluentValidation;
using ListaDeTarefas.Application.UseCases.AddTarefa;
using ListaDeTarefas.Application.UseCases.GetAllTarefa;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Delete;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.GetById;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Update;
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

        private readonly IDeleteTarefaUseCase _deleteTarefaUseCase;
        private readonly IGetByIdTarefaUseCase _getByIdTarefaUseCase;
        private readonly IUpdateTearefaUseCase _updateTarefaUseCase;

        private readonly IValidator<UpdateTarefaRequest> _updateTarefaRequestValidator;

        public TarefaController(IMediator mediator
            , IDeleteTarefaUseCase deleteTarefaUseCase, IGetByIdTarefaUseCase getByIdTarefaUseCase
            , IUpdateTearefaUseCase updateTearefaUseCase
            , IValidator<UpdateTarefaRequest> updateTarefaRequestValidator)
        {
            _mediator = mediator;
            _deleteTarefaUseCase = deleteTarefaUseCase;
            _getByIdTarefaUseCase = getByIdTarefaUseCase;
            _updateTarefaUseCase = updateTearefaUseCase;

            _updateTarefaRequestValidator = updateTarefaRequestValidator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllTarefaResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllTarefaRequest(), cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateTarefaResponse>> Create(CreateTarefaRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetByIdTaerfa(long id)
        {
            try
            {
                var tarefa = await _getByIdTarefaUseCase.Execute(id);
                return Ok(new { Data = tarefa });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("atualizar")]
        public async Task<ActionResult<Tarefa>> UpdateTarefa([FromBody] UpdateTarefaRequest updatedTarefa)
        {
            var validationResult = await _updateTarefaRequestValidator.ValidateAsync(updatedTarefa);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var tarefa = await _updateTarefaUseCase.Execute(updatedTarefa);
                return Ok(new { Message = "Tarefa atualizada com sucesso.", Data = tarefa });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<Tarefa>> DeleteTarefa(long id)
        {
            try
            {
                var tarefa = await _deleteTarefaUseCase.Execute(id);
                return Ok(new { Message = "Tarefa deletada com sucesso.", Data = tarefa });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}