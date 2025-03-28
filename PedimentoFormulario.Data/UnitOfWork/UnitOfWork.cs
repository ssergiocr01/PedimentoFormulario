using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PedimentoFormulario.Data.Interfaces;
using PedimentoFormulario.Data.Repositories;

namespace PedimentoFormulario.Data.UnitOfWork
{
    /// <summary>
    /// Implementación del patrón Unit of Work para coordinar múltiples operaciones de base de datos
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PedimentoContext _context;
        private readonly ILogger<UnitOfWork> _logger;
        private readonly ILogger<CombosRepository> _combosLogger;
        private readonly ILogger<PedimentoRepository> _pedimentoLogger;
        private readonly ILogger<RubrosSalarialesRepository> _rubrosSalarialesLogger;
        private readonly IConfiguration _configuration;
        private IDbContextTransaction _transaction;
        private bool _disposed = false;

        private ICombosRepository _combosRepository;
        private IPedimentoRepository _pedimentoRepository;
        private IRubrosSalarialesRepository _rubrosSalarialesRepository;

        /// <summary>
        /// Constructor de la unidad de trabajo
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        /// <param name="logger">Logger para registrar eventos</param>
        /// <param name="combosLogger">Logger para el repositorio de combos</param>
        /// <param name="pedimentoLogger">Logger para el repositorio de pedimentos</param>
        /// <param name="rubrosSalarialesLogger">Logger para el repositorio de rubros salariales</param>
        /// <param name="configuration">Configuración de la aplicación</param>
        public UnitOfWork(
            PedimentoContext context,
            ILogger<UnitOfWork> logger,
            ILogger<CombosRepository> combosLogger,
            ILogger<PedimentoRepository> pedimentoLogger,
            ILogger<RubrosSalarialesRepository> rubrosSalarialesLogger,
            IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _combosLogger = combosLogger ?? throw new ArgumentNullException(nameof(combosLogger));
            _pedimentoLogger = pedimentoLogger ?? throw new ArgumentNullException(nameof(pedimentoLogger));
            _rubrosSalarialesLogger = rubrosSalarialesLogger ?? throw new ArgumentNullException(nameof(rubrosSalarialesLogger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Repositorio de combos
        /// </summary>
        public ICombosRepository Combos
        {
            get
            {
                if (_combosRepository == null)
                {
                    _combosRepository = new CombosRepository(_context, _combosLogger);
                }
                return _combosRepository;
            }
        }

        /// <summary>
        /// Repositorio de pedimentos
        /// </summary>
        public IPedimentoRepository Pedimentos
        {
            get
            {
                if (_pedimentoRepository == null)
                {
                    _pedimentoRepository = new PedimentoRepository(_configuration, _pedimentoLogger);
                }
                return _pedimentoRepository;
            }
        }

        /// <summary>
        /// Repositorio de rubros salariales
        /// </summary>
        public IRubrosSalarialesRepository RubrosSalariales
        {
            get
            {
                if (_rubrosSalarialesRepository == null)
                {
                    _rubrosSalarialesRepository = new RubrosSalarialesRepository(_context, _rubrosSalarialesLogger);
                }
                return _rubrosSalarialesRepository;
            }
        }

        /// <summary>
        /// Guarda todos los cambios pendientes en la base de datos
        /// </summary>
        /// <returns>Número de entidades afectadas</returns>
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error al guardar cambios en la base de datos");
                throw;
            }
        }

        /// <summary>
        /// Inicia una nueva transacción
        /// </summary>
        /// <returns>Tarea que representa la operación asíncrona</returns>
        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                _logger.LogWarning("Ya existe una transacción activa");
                return;
            }

            try
            {
                _transaction = await _context.Database.BeginTransactionAsync();
                _logger.LogInformation("Transacción iniciada");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al iniciar la transacción");
                throw;
            }
        }

        /// <summary>
        /// Confirma la transacción actual
        /// </summary>
        /// <returns>Tarea que representa la operación asíncrona</returns>
        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
            {
                _logger.LogWarning("No hay una transacción activa para confirmar");
                return;
            }

            try
            {
                await _transaction.CommitAsync();
                _logger.LogInformation("Transacción confirmada");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al confirmar la transacción");
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <summary>
        /// Revierte la transacción actual
        /// </summary>
        /// <returns>Tarea que representa la operación asíncrona</returns>
        public async Task RollbackTransactionAsync()
        {
            if (_transaction == null)
            {
                _logger.LogWarning("No hay una transacción activa para revertir");
                return;
            }

            try
            {
                await _transaction.RollbackAsync();
                _logger.LogInformation("Transacción revertida");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al revertir la transacción");
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <summary>
        /// Libera los recursos utilizados por la unidad de trabajo
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Libera los recursos utilizados por la unidad de trabajo
        /// </summary>
        /// <param name="disposing">Indica si se están liberando recursos administrados</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}

