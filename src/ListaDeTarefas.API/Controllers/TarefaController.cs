using ListaDeTarefas.Application.UseCases.TarefaUseCase.Add;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll;
using ListaDeTarefas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.API.Controllers
{
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        private readonly ILogger<TarefaController> _logger;
        private readonly IAddTarefaUseCase _addTarefaUseCase;
        private readonly IGetAllTarefaUseCase _getAllTarefaUseCase;

        public TarefaController(ILogger<TarefaController> logger, IAddTarefaUseCase addTarefaUseCase, IGetAllTarefaUseCase getAllTarefaUseCase)
        {
            _logger = logger;
            _addTarefaUseCase = addTarefaUseCase;
            _getAllTarefaUseCase = getAllTarefaUseCase;
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<Tarefa>> AddTarefa([FromBody] Tarefa novaTarefa)
        {
            var tarefa = await _addTarefaUseCase.Execute(novaTarefa);

            return Ok(tarefa);
        }

        [HttpGet]
        [Route("todas")]
        public async Task<ActionResult<List<Tarefa>>> GetAllTarefas()
        {
            var tarefas = await _getAllTarefaUseCase.Execute();

            return Ok(tarefas);
        }
    }
}