using AutoMapper;
using FluentAssertions;
using FluentValidation;
using ListaDeTarefas.Application.Mappings;
using ListaDeTarefas.Application.Requests;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Application.UseCases.CreateUser;
using ListaDeTarefas.Application.Validators;
using ListaDeTarefas.Domain.Interfaces;
using Moq;

namespace ListaDeTarefas.UnitTests.UseCases
{
    public class CreateUserUsecaseUnitTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapperMock;
        private readonly IValidator<CreateUserRequest> _validatorMock;

        public CreateUserUsecaseUnitTest()
        {
            _userRepositoryMock = new();
            _unitOfWorkMock = new();
            _mapperMock = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CreateUserMapper());
            }));
            _validatorMock = new CreateUserValidator();
        }

        [Fact]
        public async Task Should_ReturnCreateUserResponse_When_RequestIsValid()
        {
            // Arrange
            CreateUserRequest request = new CreateUserRequest
            {
                Email = "user@email.com",
                Password = "Password"
            };

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var useCase = new CreateUserUseCase(_userRepositoryMock.Object, _unitOfWorkMock.Object, _mapperMock, _validatorMock);

            // Act
            var result = await useCase.Execute(request, new CancellationToken());

            // Assert
            result.Id.Should().Be(0);
            result.Email.Should().Be(request.Email);
            result.Password.Should().NotBeNull();
            result.DateCreated.Should().NotBeNull();
            result.DateUpdated.Should().NotBeNull();
            result.GetType().Should().Be(typeof(CreateUserResponse));
        }
    }
}
