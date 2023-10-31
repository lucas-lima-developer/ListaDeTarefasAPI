using AutoMapper;
using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.UseCases.CreateUser
{
    public class CreateUserMapper : Profile
    {
        public CreateUserMapper() 
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, CreateUserResponse>();
        }
    }
}
