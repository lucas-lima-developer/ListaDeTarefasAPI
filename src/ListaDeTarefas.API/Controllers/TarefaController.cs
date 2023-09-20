using ListaDeTarefas.Application.UseCases.TarefaUseCase.Add;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Delete;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.GetById;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Update;
using ListaDeTarefas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.API.Controllers
{
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {

        private readonly IAddTarefaUseCase _addTarefaUseCase;
        private readonly IGetAllTarefaUseCase _getAllTarefaUseCase;
        private readonly IDeleteTarefaUseCase _deleteTarefaUseCase;
        private readonly IGetByIdTarefaUseCase _getByIdTarefaUseCase;
        private readonly IUpdateTearefaUseCase _updateTarefaUseCase;
        
        public TarefaController(IAddTarefaUseCase addTarefaUseCase, IGetAllTarefaUseCase getAllTarefaUseCase
            , IDeleteTarefaUseCase deleteTarefaUseCase, IGetByIdTarefaUseCase getByIdTarefaUseCase, IUpdateTearefaUseCase updateTearefaUseCase)
        {
            _addTarefaUseCase = addTarefaUseCase;
            _getAllTarefaUseCase = getAllTarefaUseCase;
            _deleteTarefaUseCase = deleteTarefaUseCase;
            _getByIdTarefaUseCase = getByIdTarefaUseCase;
            _updateTarefaUseCase = updateTearefaUseCase;
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<Tarefa>> AddTarefa([FromBody] AddTarefaRequest request)
        {
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
        public async Task<ActionResult<List<Tarefa>>> GetAllTarefas()
        {
            var tarefas = await _getAllTarefaUseCase.Execute();

            return Ok(new { Data = tarefas });
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<Tarefa>> UpdateTarefa([FromBody] UpdateTarefaRequest updatedTarefa)
        {
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