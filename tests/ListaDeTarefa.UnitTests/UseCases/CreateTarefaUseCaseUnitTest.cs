using AutoMapper;
using FluentAssertions;
using FluentValidation;
using ListaDeTarefas.Application.Mappings;
using ListaDeTarefas.Application.Requests;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Application.UseCases.CreateTarefa;
using ListaDeTarefas.Application.Validators;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;
using Moq;

namespace TestProject1.UseCases
{
    public class CreateTarefaUseCaseUnitTest
    {
        private readonly Mock<ITarefaRepository> _tarefaRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapperMock;
        private readonly IValidator<CreateTarefaRequest> _validatorMock;

        public CreateTarefaUseCaseUnitTest()
        {
            _tarefaRepositoryMock = new();
            _userRepositoryMock = new();
            _unitOfWorkMock = new();
            _mapperMock = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CreateTarefaMapper());
            }));
            _validatorMock = new CreateTarefaValidator();
        }

        [Fact]
        public async Task Should_ReturnCreateTarefaResponse_When_ValidUserAndValidRequest()
        {
            // Arrange
            CreateTarefaRequest request = new CreateTarefaRequest { Title = "Teste", Description = "Teste" };
            User user = new User { Id = 1, Tarefas = new List<Tarefa>(), DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Email= "email@email.com", Password = "123" };

            _userRepositoryMock.Setup(r => r.GetByEmail(user.Email, new CancellationToken())).ReturnsAsync(user);

            var useCase = new CreateTarefaUseCase(_tarefaRepositoryMock.Object, _userRepositoryMock.Object, _unitOfWorkMock.Object, _mapperMock, _validatorMock);

            // Act
            var result = await useCase.Execute(request, "email@email.com", new CancellationToken());

            // Assert
            result.Id.Should().Be(0);
            result.Title.Should().Be(request.Title);
            result.Description.Should().Be(request.Description);
            result.DateCreated.Should().NotBeNull();
            result.DateUpdated.Should().NotBeNull();
            result.IsCompleted.Should().BeFalse();
            result.CompletionDate.Should().BeNull();
            result.GetType().Should().Be(typeof(CreateTarefaResponse));
        }
    }
}
