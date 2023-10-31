using ListaDeTarefas.Application.UseCases.CreateUser;
using ListaDeTarefas.Application.UseCases.LoginUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<CreateUserResponse>> Create([FromServices] ICreateUserUseCase useCase, CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = await useCase.Execute(request, cancellationToken);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginUserResponse>> Login([FromServices] ILoginUserUseCase useCase, LoginUserRequest request, CancellationToken cancellationToken)
        {
            var response = await useCase.Execute(request, cancellationToken);

            return Ok(response);
        }

        [HttpGet("test-auth"), Authorize]
        public IActionResult TestAuth()
        {
            return Ok("Acesso Permitido");
        }
    }
}
