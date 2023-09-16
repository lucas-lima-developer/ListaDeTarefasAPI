using ListaDeTarefas.Application.UseCases.TarefaUseCase.Add;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Delete;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.GetById;
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

        public TarefaController(IAddTarefaUseCase addTarefaUseCase, IGetAllTarefaUseCase getAllTarefaUseCase
            , IDeleteTarefaUseCase deleteTarefaUseCase, IGetByIdTarefaUseCase getByIdTarefaUseCase)
        {
            _addTarefaUseCase = addTarefaUseCase;
            _getAllTarefaUseCase = getAllTarefaUseCase;
            _deleteTarefaUseCase = deleteTarefaUseCase;
            _getByIdTarefaUseCase = getByIdTarefaUseCase;
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

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeleteTarefa(long id)
        {
            await _deleteTarefaUseCase.Execute(id);
            return Ok("Tarefa deletada com sucesso.");
        }
    }
}