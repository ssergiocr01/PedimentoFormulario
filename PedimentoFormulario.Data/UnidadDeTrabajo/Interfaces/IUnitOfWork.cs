using PedimentoFormulario.Data.Repositorios.Interfaces;
using System;
using System.Threading.Tasks;

namespace PedimentoFormulario.Data.UnidadDeTrabajo.Interfaces
{
    /// <summary>
    /// Interfaz que define una unidad de trabajo para coordinar múltiples operaciones de repositorio
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Repositorio para trabajar con solicitudes de pedimento de personal
        /// </summary>
        IPedimentoRepository PedimentoRepository { get; }

        /// <summary>
        /// Guarda todos los cambios realizados en el contexto
        /// </summary>
        /// <returns>Número de entidades modificadas</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Comienza una transacción
        /// </summary>
        Task BeginTransactionAsync();

        /// <summary>
        /// Confirma la transacción actual
        /// </summary>
        Task CommitTransactionAsync();

        /// <summary>
        /// Revierte la transacción actual
        /// </summary>
        Task RollbackTransactionAsync();
    }
}