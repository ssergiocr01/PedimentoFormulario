using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PedimentoFormulario.Data.Interfaces;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PedimentoFormulario.Data.Repositories
{
    /// <summary>
    /// Implementación del repositorio de rubros salariales
    /// </summary>
    public class RubrosSalarialesRepository : IRubrosSalarialesRepository
    {
        private readonly PedimentoContext _context;
        private readonly ILogger<RubrosSalarialesRepository> _logger;

        /// <summary>
        /// Constructor del repositorio de rubros salariales
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        /// <param name="logger">Logger para registrar eventos</param>
        public RubrosSalarialesRepository(PedimentoContext context, ILogger<RubrosSalarialesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RubroSalarial>> GetRubrosSalarialesAsync()
        {
            try
            {
                return await _context.RubrosSalariales
                    .Where(r => r.Activo)
                    .OrderBy(r => r.NombreRubroSalarial)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener rubros salariales");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RubroSalarial>> GetRubrosSalarialesByInstitucionAsync(decimal codInstitucion)
        {
            try
            {
                return await _context.RubrosSalariales
                    .Where(r => r.CodInstitucion == codInstitucion && r.Activo)
                    .OrderBy(r => r.NombreRubroSalarial)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener rubros salariales para la institución {CodInstitucion}", codInstitucion);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<RubroSalarial> GetRubroSalarialAsync(decimal codRubroSalarial, decimal codInstitucion)
        {
            try
            {
                return await _context.RubrosSalariales
                    .FirstOrDefaultAsync(r => r.CodRubroSalarial == codRubroSalarial &&
                                             r.CodInstitucion == codInstitucion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener rubro salarial {CodRubroSalarial} para la institución {CodInstitucion}",
                                codRubroSalarial, codInstitucion);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RubroPedimentoResultadoDto>> GetRubrosPedimentoAsync()
        {
            try
            {
                // Ejecutar el procedimiento almacenado
                var result = new List<RubroPedimentoResultadoDto>();

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_rys_select_rubros_x_pedimento";
                    command.CommandType = CommandType.StoredProcedure;

                    await _context.Database.OpenConnectionAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new RubroPedimentoResultadoDto
                            {
                                CodRubroSalarial = reader.GetDecimal(0),
                                UsuarioReg = reader.GetString(1),
                                CodInstitucion = reader.GetDecimal(2),
                                Pedimento = reader.GetString(3),
                                NombreRubroSalarial = reader.GetString(4),
                                Detalles = reader.IsDBNull(5) ? null : reader.GetString(5)
                            });
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener rubros salariales por pedimento");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> AgregarRubroPedimentoAsync(RubroPedimentoDto rubroPedimentoDto)
        {
            try
            {
                // Ejecutar el procedimiento almacenado
                var parameters = new[]
                {
                    new SqlParameter("@cod_rubro_salaria", SqlDbType.Decimal) { Value = rubroPedimentoDto.cod_rubro_salaria },
                    new SqlParameter("@cod_institucion", SqlDbType.Decimal) { Value = rubroPedimentoDto.cod_institucion },
                    new SqlParameter("@pedimento", SqlDbType.VarChar, 15) { Value = rubroPedimentoDto.pedimento },
                    new SqlParameter("@detalles", SqlDbType.VarChar, 3000) { Value = (object)rubroPedimentoDto.detalles ?? DBNull.Value },
                    new SqlParameter("@usuario", SqlDbType.VarChar, 20) { Value = rubroPedimentoDto.usuario }
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_rys_insert_rubros_x_pedimento @cod_rubro_salaria, @cod_institucion, @pedimento, @detalles, @usuario",
                    parameters);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar rubro salarial {CodRubroSalarial} para el pedimento {Pedimento}",
                        rubroPedimentoDto.cod_rubro_salaria, rubroPedimentoDto.pedimento);
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> ActualizarRubroPedimentoAsync(RubroPedimentoDto rubroPedimentoDto)
        {
            try
            {
                // Ejecutar el procedimiento almacenado
                var parameters = new[]
                {
                    new SqlParameter("@cod_rubro_salaria", SqlDbType.Decimal) { Value = rubroPedimentoDto.cod_rubro_salaria },
                    new SqlParameter("@cod_institucion", SqlDbType.Decimal) { Value = rubroPedimentoDto.cod_institucion },
                    new SqlParameter("@pedimento", SqlDbType.VarChar, 15) { Value = rubroPedimentoDto.pedimento },
                    new SqlParameter("@Detalles", SqlDbType.VarChar, 3000) { Value = (object)rubroPedimentoDto.detalles ?? DBNull.Value }
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_rys_update_rubros_x_pedimento @cod_rubro_salaria, @cod_institucion, @pedimento, @Detalles",
                    parameters);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar rubro salarial {CodRubroSalarial} para el pedimento {Pedimento}",
                        rubroPedimentoDto.cod_rubro_salaria, rubroPedimentoDto.pedimento);
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> EliminarRubroPedimentoAsync(decimal codRubroSalarial, decimal codInstitucion, string pedimento)
        {
            try
            {
                // Ejecutar el procedimiento almacenado
                var parameters = new[]
                {
                    new SqlParameter("@cod_rubro_salaria", SqlDbType.Decimal) { Value = codRubroSalarial },
                    new SqlParameter("@cod_institucion", SqlDbType.Decimal) { Value = codInstitucion },
                    new SqlParameter("@pedimento", SqlDbType.VarChar, 15) { Value = pedimento }
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_rys_delete_rubros_x_pedimento @cod_rubro_salaria, @cod_institucion, @pedimento",
                    parameters);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar rubro salarial {CodRubroSalarial} para el pedimento {Pedimento}",
                                codRubroSalarial, pedimento);
                return false;
            }
        }
    }
}

