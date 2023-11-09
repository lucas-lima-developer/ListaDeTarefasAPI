using AutoMapper;
using FluentValidation;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Application.Requests;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.CreateUser
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUserRequest> _validator;

        public CreateUserUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateUserRequest> validator)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateUserResponse> Execute(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid) throw new ValidationErrorException(result);

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            request.Password = passwordHash;

            var user = _mapper.Map<User>(request);

            _userRepository.Create(user);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}
