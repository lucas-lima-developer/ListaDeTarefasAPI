using AutoMapper;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.CreateUser
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Execute(CreateUserRequest request, CancellationToken cancellationToken)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            request.Password = passwordHash;

            var user = _mapper.Map<User>(request);

            _userRepository.Create(user);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}
