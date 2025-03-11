using Microsoft.EntityFrameworkCore.Storage;
using PedimentoFormulario.Data.Repositorios;
using PedimentoFormulario.Data.Repositorios.Interfaces;
using PedimentoFormulario.Data.UnidadDeTrabajo.Interfaces;

namespace PedimentoFormulario.Data.UnidadDeTrabajo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PedimentoContext _context;
        private IDbContextTransaction _transaction;
        private bool _disposed;

        private IPedimentoRepository _pedimentoRepository;

        public UnitOfWork(PedimentoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IPedimentoRepository PedimentoRepository =>
            _pedimentoRepository ??= new PedimentoRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();

                // Corregido: Verificar si _transaction no es nulo antes de usarlo
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            finally
            {
                // Corregido: Verificar si _transaction no es nulo antes de usarlo
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                // Corregido: Verificar si _transaction no es nulo antes de usarlo
                if (_transaction != null)
                {
                    await _transaction.RollbackAsync();
                }
            }
            finally
            {
                // Corregido: Verificar si _transaction no es nulo antes de usarlo
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _transaction?.Dispose();
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}