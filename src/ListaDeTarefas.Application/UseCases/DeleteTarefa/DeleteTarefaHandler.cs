﻿using AutoMapper;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Enum;
using ListaDeTarefas.Domain.Interfaces;
using MediatR;

namespace ListaDeTarefas.Application.UseCases.DeleteTarefa
{
    public class DeleteTarefaHandler : IRequestHandler<DeleteTarefaRequest, DeleteTarefaResponse>
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTarefaHandler(IUnitOfWork unitOfWork, ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteTarefaResponse> Handle(DeleteTarefaRequest request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.GetById(request.Id, cancellationToken);

            if (tarefa == null) return default;

            _tarefaRepository.Delete(tarefa);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteTarefaResponse>(tarefa);
        }
    }

    public sealed record DeleteTarefaRequest(long Id) : IRequest<DeleteTarefaResponse>;

    public sealed record DeleteTarefaResponse
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LimitDate { get; set; }
        public Priority? Priority { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public sealed class DeleteUserMapper : Profile
    {
        public DeleteUserMapper()
        {
            CreateMap<DeleteTarefaRequest, Tarefa>();
            CreateMap<Tarefa, DeleteTarefaResponse>();
        }
    }
}