using ListaDeTarefas.Application.UseCases.TarefaUseCase.Add;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Complete;
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
        private readonly ICompleteTarefaUseCase _completeTarefaUseCase;
        public TarefaController(IAddTarefaUseCase addTarefaUseCase, IGetAllTarefaUseCase getAllTarefaUseCase
            , IDeleteTarefaUseCase deleteTarefaUseCase, IGetByIdTarefaUseCase getByIdTarefaUseCase, IUpdateTearefaUseCase updateTearefaUseCase
            , ICompleteTarefaUseCase completeTarefaUseCase)
        {
            _addTarefaUseCase = addTarefaUseCase;
            _getAllTarefaUseCase = getAllTarefaUseCase;
            _deleteTarefaUseCase = deleteTarefaUseCase;
            _getByIdTarefaUseCase = getByIdTarefaUseCase;
            _updateTarefaUseCase = updateTearefaUseCase;
            _completeTarefaUseCase = completeTarefaUseCase;
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<Tarefa>> AddTarefa([FromBody] Tarefa novaTarefa)
        {
            var tarefa = await _addTarefaUseCase.Execute(novaTarefa);

            return Ok(tarefa);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetByIdTaerfa(long id)
        {
            var tarefa = await _getByIdTarefaUseCase.Execute(id);

            return Ok(tarefa);
        }

        [HttpGet]
        [Route("todas")]
        public async Task<ActionResult<List<Tarefa>>> GetAllTarefas()
        {
            var tarefas = await _getAllTarefaUseCase.Execute();

            return Ok(tarefas);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> UpdateTarefa(long id, [FromBody] Tarefa updatedTarefa)
        {
            await _updateTarefaUseCase.Execute(id, updatedTarefa);
            return Ok("Tarefa atualizada com sucesso.");
        }

        [HttpPut("completar/{id}")]
        public async Task<IActionResult> SetCompletedTarefa(long id)
        {
            await _completeTarefaUseCase.Execute(id);
            return Ok("Tarefa completada com sucesso.");
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeleteTarefa(long id)
        {
            await _deleteTarefaUseCase.Execute(id);
            return Ok("Tarefa deletada com sucesso.");
        }
    }
}