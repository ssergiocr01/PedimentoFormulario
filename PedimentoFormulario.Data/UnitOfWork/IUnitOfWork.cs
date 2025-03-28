using System;
using System.Threading.Tasks;

namespace PedimentoFormulario.Data.Interfaces
{
    /// <summary>
    /// Interfaz para el patrón Unit of Work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Repositorio de combos
        /// </summary>
        ICombosRepository Combos { get; }

        /// <summary>
        /// Repositorio de pedimentos
        /// </summary>
        IPedimentoRepository Pedimentos { get; }

        /// <summary>
        /// Repositorio de rubros salariales
        /// </summary>
        IRubrosSalarialesRepository RubrosSalariales { get; }

        /// <summary>
        /// Guarda todos los cambios pendientes en la base de datos
        /// </summary>
        /// <returns>Número de entidades afectadas</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Inicia una nueva transacción
        /// </summary>
        /// <returns>Tarea que representa la operación asíncrona</returns>
        Task BeginTransactionAsync();

        /// <summary>
        /// Confirma la transacción actual
        /// </summary>
        /// <returns>Tarea que representa la operación asíncrona</returns>
        Task CommitTransactionAsync();

        /// <summary>
        /// Revierte la transacción actual
        /// </summary>
        /// <returns>Tarea que representa la operación asíncrona</returns>
        Task RollbackTransactionAsync();
    }
}

