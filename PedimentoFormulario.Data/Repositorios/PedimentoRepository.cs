using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PedimentoFormulario.Data.Repositorios.Interfaces;
using PedimentoFormulario.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PedimentoFormulario.Data.Repositorios
{
    public class PedimentoRepository : IPedimentoRepository
    {
        private readonly PedimentoContext _context;
        private readonly ILogger<PedimentoRepository> _logger;

        public PedimentoRepository(PedimentoContext context, ILogger<PedimentoRepository> logger = null)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        public async Task<IEnumerable<SolicitudPedimentoPersonal>> GetPedimentosAsync(int tipoConsulta, bool mini, string? pedimento = null, int codInstitucion = 0)
        {
            try
            {
                // Verificar que el contexto no sea nulo
                if (_context == null)
                {
                    _logger?.LogError("El contexto de base de datos es nulo");
                    return new List<SolicitudPedimentoPersonal>();
                }

                // Verificar que la base de datos esté disponible
                if (_context.Database == null)
                {
                    _logger?.LogError("La propiedad Database del contexto es nula");
                    return new List<SolicitudPedimentoPersonal>();
                }

                // Obtenemos la conexión del contexto de EF Core
                var connection = _context.Database.GetDbConnection();
                if (connection == null)
                {
                    _logger?.LogError("No se pudo obtener la conexión a la base de datos");
                    return new List<SolicitudPedimentoPersonal>();
                }

                // Verificar el estado de la conexión
                if (connection.State != ConnectionState.Open)
                {
                    try
                    {
                        await connection.OpenAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError(ex, "Error al abrir la conexión a la base de datos");
                        return new List<SolicitudPedimentoPersonal>();
                    }
                }

                // Crear los parámetros
                var parameters = new DynamicParameters();
                parameters.Add("@Consulta", tipoConsulta, DbType.Decimal);
                parameters.Add("@mini", mini, DbType.Boolean);
                parameters.Add("@pedimento", pedimento ?? string.Empty, DbType.String);
                parameters.Add("@cod_institucion", codInstitucion, DbType.Decimal);

                // Ejecutamos el procedimiento almacenado con manejo de errores
                IEnumerable<dynamic> result;
                try
                {
                    result = await connection.QueryAsync<dynamic>(
                        "sp_rys_select_pedimento_personal",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, "Error al ejecutar el procedimiento almacenado");
                    return new List<SolicitudPedimentoPersonal>();
                }

                // Verificar que el resultado no sea nulo
                if (result == null)
                {
                    _logger?.LogWarning("El procedimiento almacenado no devolvió resultados");
                    return new List<SolicitudPedimentoPersonal>();
                }

                // Convertimos los resultados dinámicos a SolicitudPedimentoPersonal
                var solicitudes = new List<SolicitudPedimentoPersonal>();

                foreach (var item in result)
                {
                    try
                    {
                        // Verificar que cada propiedad no sea nula antes de asignarla
                        var solicitud = new SolicitudPedimentoPersonal
                        {
                            Pedimento = GetPropertyValue<string>(item, "pedimento") ?? string.Empty,
                            CodInstitucion = GetPropertyValue<decimal>(item, "cod_institucion"),
                            CodDependencia = GetPropertyValue<decimal>(item, "cod_dependencia"),
                            NumPuesto = GetPropertyValue<decimal>(item, "num_puesto"),
                            CodPresupuesto = GetPropertyValue<string>(item, "cod_presupuesto"),
                            CodEstrato = GetPropertyValue<decimal>(item, "cod_estrato"),
                            CodClaseGen = GetPropertyValue<decimal>(item, "cod_clase_gen"),
                            CodClase = GetPropertyValue<string>(item, "cod_clase") ?? string.Empty,
                            CodEspecialidad = GetPropertyValue<decimal>(item, "cod_especialidad"),
                            CodSubEspecialidad = GetPropertyValue<decimal>(item, "cod_sub_especialidad"),
                            CodCargo = GetPropertyValue<decimal>(item, "cod_cargo"),
                            CodMotivo = GetPropertyValue<decimal>(item, "cod_motivo"),
                            IntIdentificacion = GetPropertyValue<string>(item, "int_identificacion"),
                            IntNombre = GetPropertyValue<string>(item, "int_nombre"),
                            CodDepartamento = GetPropertyValue<decimal>(item, "cod_departamento"),
                            CodProvincia = GetPropertyValue<decimal>(item, "cod_provincia"),
                            CodCanton = GetPropertyValue<decimal>(item, "cod_canton"),
                            CodDistrito = GetPropertyValue<decimal>(item, "cod_distrito"),
                            Destacado = GetPropertyValue<decimal?>(item, "destacado"),
                            EspecDestacado = GetPropertyValue<string>(item, "espec_destacado"),
                            Traslado = GetPropertyValue<bool?>(item, "traslado"),
                            EspecTraslado = GetPropertyValue<string>(item, "espec_traslado"),
                            CodJornada = GetPropertyValue<decimal>(item, "cod_jornada"),
                            CodHorario = GetPropertyValue<decimal>(item, "cod_horario"),
                            Observaciones = GetPropertyValue<string>(item, "observaciones"),
                            CodTipoResolucion = GetPropertyValue<decimal?>(item, "cod_tipo_resolucion"),
                            DetallesResolucion = GetPropertyValue<string>(item, "detalles_resolucion"),
                            Consecutivo = GetPropertyValue<decimal>(item, "consecutivo"),
                            Anno = GetPropertyValue<decimal>(item, "anno"),
                            AnulaPed = GetPropertyValue<bool?>(item, "anula_ped") ?? false,
                            NumPedimento = GetPropertyValue<string>(item, "num_pedimento"),
                            Detalles = GetPropertyValue<string>(item, "detalles"),
                            ObservacionesPed = GetPropertyValue<string>(item, "observaciones_ped"),
                            UsuarioMod = GetPropertyValue<string>(item, "usuariomod") ?? string.Empty,
                            FechaReg = GetPropertyValue<DateTime>(item, "fechareg"),
                            UsuarioReg = GetPropertyValue<string>(item, "usuarioreg") ?? string.Empty,
                            FechaMod = DateTime.Now,
                            CodEstPedUlt = GetPropertyValue<decimal?>(item, "Estado"),
                            ReservaDiscapacidad = GetPropertyValue<bool?>(item, "ReservaDiscapacidad") ?? false,
                            ObservacionesConcursoInt = GetPropertyValue<string>(item, "ObservacionesConcursoInt"),
                            ReservaAfrodescendiente = GetPropertyValue<bool?>(item, "ReservaAfrodescendiente") ?? false
                        };

                        // Agregamos la solicitud a la lista
                        solicitudes.Add(solicitud);
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError(ex, "Error al mapear el pedimento");
                    }
                }

                return solicitudes;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error general en GetPedimentosAsync");
                return new List<SolicitudPedimentoPersonal>();
            }
        }

        // Método auxiliar para obtener valores de propiedades dinámicas de forma segura
        private T GetPropertyValue<T>(dynamic obj, string propertyName)
        {
            try
            {
                // Intentar obtener la propiedad como IDictionary<string, object>
                if (obj is IDictionary<string, object> dict)
                {
                    if (dict.TryGetValue(propertyName, out var value))
                    {
                        if (value == null)
                            return default;

                        // Si el valor es DBNull, devolver el valor predeterminado
                        if (value is DBNull)
                            return default;

                        // Intentar convertir el valor al tipo esperado
                        try
                        {
                            return (T)Convert.ChangeType(value, typeof(T));
                        }
                        catch
                        {
                            return default;
                        }
                    }
                    return default;
                }

                // Intentar obtener la propiedad de forma dinámica
                var property = obj.GetType().GetProperty(propertyName);
                if (property == null)
                    return default;

                var value2 = property.GetValue(obj);
                if (value2 == null || value2 is DBNull)
                    return default;

                return (T)Convert.ChangeType(value2, typeof(T));
            }
            catch
            {
                return default;
            }
        }
    }
}