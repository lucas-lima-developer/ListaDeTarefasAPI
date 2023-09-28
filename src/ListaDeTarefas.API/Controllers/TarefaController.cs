using FluentValidation;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Add;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Delete;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll;
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

        private readonly IAddTarefaUseCase _addTarefaUseCase;
        private readonly IDeleteTarefaUseCase _deleteTarefaUseCase;
        private readonly IGetByIdTarefaUseCase _getByIdTarefaUseCase;
        private readonly IUpdateTearefaUseCase _updateTarefaUseCase;

        private readonly IValidator<AddTarefaRequest> _addTarefaRequestValidator;
        private readonly IValidator<UpdateTarefaRequest> _updateTarefaRequestValidator;

        public TarefaController(IMediator mediator, IAddTarefaUseCase addTarefaUseCase
            , IDeleteTarefaUseCase deleteTarefaUseCase, IGetByIdTarefaUseCase getByIdTarefaUseCase
            , IUpdateTearefaUseCase updateTearefaUseCase, IValidator<AddTarefaRequest> addTarefaRequestValidator
            , IValidator<UpdateTarefaRequest> updateTarefaRequestValidator)
        {
            _mediator = mediator;
            _addTarefaUseCase = addTarefaUseCase;
            _deleteTarefaUseCase = deleteTarefaUseCase;
            _getByIdTarefaUseCase = getByIdTarefaUseCase;
            _updateTarefaUseCase = updateTearefaUseCase;

            _addTarefaRequestValidator = addTarefaRequestValidator;
            _updateTarefaRequestValidator = updateTarefaRequestValidator;
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<Tarefa>> AddTarefa([FromBody] AddTarefaRequest request)
        {
            var validationResult = await _addTarefaRequestValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var tarefa = await _addTarefaUseCase.Execute(request);

            return Ok(new { Message = "Tarefa criada com sucesso!", Data = tarefa });
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

        [HttpGet]
        [Route("todas")]
        public async Task<ActionResult<List<GetAllTarefaResponse>>> GetAllTarefas(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllTarefaRequest(), cancellationToken);

            return Ok(response);
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