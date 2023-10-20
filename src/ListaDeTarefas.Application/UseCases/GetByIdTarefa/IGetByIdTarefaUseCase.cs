﻿namespace ListaDeTarefas.Application.UseCases.GetByIdTarefa
{
    public interface IGetByIdTarefaUseCase
    {
        Task<GetByIdTarefaResponse> Execute(int id, CancellationToken cancellationToken);
    }
}