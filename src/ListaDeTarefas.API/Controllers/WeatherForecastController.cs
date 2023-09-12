using ListaDeTarefas.Application.UseCases.TarefaUseCase.Add;
using ListaDeTarefas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAddTarefaUseCase _addTarefaUseCase;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IAddTarefaUseCase addTarefaUseCase)
        {
            _logger = logger;
            _addTarefaUseCase = addTarefaUseCase;
        }

        [HttpPost(Name = "AddTarefa")]
        public async Task<IActionResult> AddTarefa([FromBody] Tarefa novaTarefa)
        {
            await _addTarefaUseCase.Execute(novaTarefa);

            return Ok("Executado com sucesso");
        }
    }
}