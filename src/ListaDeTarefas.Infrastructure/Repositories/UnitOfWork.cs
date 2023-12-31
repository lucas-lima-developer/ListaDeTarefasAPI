﻿using ListaDeTarefas.Domain.Interfaces;
using ListaDeTarefas.Infrastructure.Context;

namespace ListaDeTarefas.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private bool _disposed;

        public UnitOfWork(AppDbContext context) 
        {
            _context = context;
        }

        public async Task Commit()
        {
             await _context.SaveChangesAsync();
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}
