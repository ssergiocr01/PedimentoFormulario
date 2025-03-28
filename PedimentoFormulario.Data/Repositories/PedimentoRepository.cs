using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PedimentoFormulario.Data.Interfaces;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Parametros;
using System.Data;
using System.Diagnostics;
using Newtonsoft.Json;

namespace PedimentoFormulario.Data.Repositories
{
    /// <summary>
    /// Implementación del repositorio de pedimentos de personal
    /// </summary>
    public class PedimentoRepository : IPedimentoRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<PedimentoRepository> _logger;

        /// <summary>
        /// Constructor del repositorio de pedimentos
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación</param>
        /// <param name="logger">Logger para registrar eventos</param>
        public PedimentoRepository(IConfiguration configuration, ILogger<PedimentoRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        /// <summary>
        /// Registra los detalles de una consulta SQL
        /// </summary>
        /// <param name="procedureName">Nombre del procedimiento almacenado</param>
        /// <param name="parameters">Parámetros de la consulta</param>
        private void LogSqlQuery(string procedureName, DynamicParameters parameters)
        {
            var parameterValues = new List<string>();

            // Obtener los nombres de los parámetros
            var parameterNames = parameters.ParameterNames.ToList();

            // Crear un diccionario para almacenar los parámetros y sus valores
            var paramDict = new Dictionary<string, string>();

            foreach (var name in parameterNames)
            {
                // Obtener el valor del parámetro
                var value = parameters.Get<object>(name);

                // Formatear el valor según su tipo
                string formattedValue;
                if (value == null)
                {
                    formattedValue = "NULL";
                }
                else if (value is string)
                {
                    formattedValue = $"'{value}'";
                }
                else if (value is DateTime dateTime)
                {
                    formattedValue = $"'{dateTime:yyyy-MM-dd HH:mm:ss}'";
                }
                else if (value is bool boolean)
                {
                    formattedValue = boolean ? "1" : "0";
                }
                else
                {
                    formattedValue = value.ToString();
                }

                // Almacenar el parámetro y su valor
                paramDict[name] = formattedValue;
            }

            // Generar dos representaciones de la consulta SQL

            // 1. Formato con nombres de parámetros (para referencia)
            var namedParamsList = parameterNames.Select(name => $"{name} = {paramDict[name]}");
            var namedParamsQuery = $"EXEC {procedureName} {string.Join(", ", namedParamsList)}";

            // 2. Formato posicional (para ejecución directa)
            var positionalParamsList = parameterNames.Select(name => paramDict[name]);
            var positionalParamsQuery = $"EXEC {procedureName} {string.Join(", ", positionalParamsList)}";

            // Registrar ambas representaciones
            _logger.LogInformation("SQL Query (Named Parameters): {NamedSql}", namedParamsQuery);
            _logger.LogInformation("SQL Query (Executable): {ExecutableSql}", positionalParamsQuery);
        }

        public async Task<IEnumerable<PedimentoPersonalDto>> ConsultarPedimentosAsync(ConsultaPedimentoParams parametros)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Consulta", 19, DbType.Decimal);
                    parameters.Add("@mini", 0, DbType.Boolean);
                    parameters.Add("@pedimento", parametros.Pedimento ?? string.Empty, DbType.String);
                    parameters.Add("@cod_institucion", parametros.CodInstitucion, DbType.Decimal);

                    // Registrar la consulta SQL
                    LogSqlQuery("sp_rys_select_pedimento_personal", parameters);

                    // Medir el tiempo de ejecución
                    var stopwatch = Stopwatch.StartNew();

                    // Usar QueryAsync<dynamic> para obtener los resultados sin mapeo automático
                    var rawResults = await connection.QueryAsync<dynamic>(
                        "sp_rys_select_pedimento_personal",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    stopwatch.Stop();

                    // Registrar los resultados sin procesar para depuración
                    if (rawResults.Any())
                    {
                        var firstRow = rawResults.First();
                        // Convertir a string manualmente
                        string rowAsString = string.Join(", ", ((IDictionary<string, object>)firstRow).Select(kv => $"{kv.Key}={kv.Value}"));
                        _logger.LogInformation("Primera fila sin mapear: {0}", rowAsString);

                        // Acceder a las propiedades dinámicas de manera segura
                        var rowDict = (IDictionary<string, object>)firstRow;

                        _logger.LogInformation("Valores numéricos de la primera fila: " +
                            "cod_institucion={0}, " +
                            "cod_dependencia={1}, " +
                            "cod_departamento={2}, " +
                            "cod_provincia={3}, " +
                            "cod_canton={4}, " +
                            "cod_distrito={5}",
                            rowDict.ContainsKey("cod_institucion") ? rowDict["cod_institucion"] : "N/A",
                            rowDict.ContainsKey("cod_dependencia") ? rowDict["cod_dependencia"] : "N/A",
                            rowDict.ContainsKey("cod_departamento") ? rowDict["cod_departamento"] : "N/A",
                            rowDict.ContainsKey("cod_provincia") ? rowDict["cod_provincia"] : "N/A",
                            rowDict.ContainsKey("cod_canton") ? rowDict["cod_canton"] : "N/A",
                            rowDict.ContainsKey("cod_distrito") ? rowDict["cod_distrito"] : "N/A");
                    }

                    // Mapeo manual para asegurar que los valores se asignen correctamente
                    var mappedResults = new List<PedimentoPersonalDto>();

                    foreach (var row in rawResults)
                    {
                        var rowDict = (IDictionary<string, object>)row;

                        var dto = new PedimentoPersonalDto
                        {
                            Pedimento = GetStringValue(rowDict, "pedimento"),
                            CodInstitucion = GetDecimalValue(rowDict, "cod_institucion"),
                            CodDependencia = GetDecimalValue(rowDict, "cod_dependencia"),
                            NumPuesto = GetDecimalValue(rowDict, "num_puesto"),
                            CodPresupuesto = GetStringValue(rowDict, "cod_presupuesto"),
                            CodEstrato = GetDecimalValue(rowDict, "cod_estrato"),
                            CodClaseGen = GetDecimalValue(rowDict, "cod_clase_gen"),
                            CodClase = GetStringValue(rowDict, "cod_clase"),
                            CodEspecialidad = GetDecimalValue(rowDict, "cod_especialidad"),
                            CodSubEspecialidad = GetDecimalValue(rowDict, "cod_sub_especialidad"),
                            CodCargo = GetDecimalValue(rowDict, "cod_cargo"),
                            CodMotivo = GetDecimalValue(rowDict, "cod_motivo"),
                            IntIdentificacion = GetStringValue(rowDict, "int_identificacion"),
                            IntNombre = GetStringValue(rowDict, "int_nombre"),
                            CodDepartamento = GetDecimalValue(rowDict, "cod_departamento"),
                            CodProvincia = GetDecimalValue(rowDict, "cod_provincia"),
                            CodCanton = GetDecimalValue(rowDict, "cod_canton"),
                            CodDistrito = GetDecimalValue(rowDict, "cod_distrito"),
                            Destacado = GetNullableDecimalValue(rowDict, "destacado"),
                            EspecDestacado = GetStringValue(rowDict, "espec_destacado"),
                            Traslado = GetBooleanValue(rowDict, "traslado"),
                            EspecTraslado = GetStringValue(rowDict, "espec_traslado"),
                            CodJornada = GetDecimalValue(rowDict, "cod_jornada"),
                            CodHorario = GetDecimalValue(rowDict, "cod_horario"),
                            Observaciones = GetStringValue(rowDict, "observaciones"),
                            CodTipoResolucion = GetNullableDecimalValue(rowDict, "cod_tipo_resolucion"),
                            DetallesResolucion = GetStringValue(rowDict, "detalles_resolucion"),
                            Consecutivo = GetDecimalValue(rowDict, "consecutivo"),
                            Anno = GetDecimalValue(rowDict, "anno"),
                            UsuarioMod = GetStringValue(rowDict, "usuariomod"),
                            UsuarioReg = GetStringValue(rowDict, "usuarioreg"),
                            Institucion = GetStringValue(rowDict, "institucion"),
                            Dependencia = GetStringValue(rowDict, "dependencia"),
                            NombreEstrato = GetStringValue(rowDict, "nombre_estrato"),
                            NombreGenerica = GetStringValue(rowDict, "nombre_generica"),
                            TituloDeLaClase = GetStringValue(rowDict, "titulo_de_la_clase"),
                            Especialidad = GetStringValue(rowDict, "especialidad"),
                            Subespecialidad = GetStringValue(rowDict, "subespecialidad"),
                            NombreCargo = GetStringValue(rowDict, "nombre_cargo"),
                            Departamento = GetStringValue(rowDict, "departamento"),
                            Motivo = GetStringValue(rowDict, "motivo"),
                            Provincia = GetStringValue(rowDict, "provincia"),
                            Canton = GetStringValue(rowDict, "canton"),
                            Distrito = GetStringValue(rowDict, "distrito"),
                            Jornada = GetStringValue(rowDict, "jornada"),
                            Horario = GetStringValue(rowDict, "horario"),
                            TipoResolucion = GetStringValue(rowDict, "tipo_resolucion"),
                            AnulaPed = GetBooleanValue(rowDict, "anula_ped"),
                            NumPedimento = GetStringValue(rowDict, "num_pedimento"),
                            Detalles = GetStringValue(rowDict, "detalles"),
                            ObservacionesPed = GetStringValue(rowDict, "observaciones_ped"),
                            FechaReg = GetDateTimeValue(rowDict, "fechareg"),
                            Temporal = GetStringValue(rowDict, "temporal"),
                            Estado = GetDecimalValue(rowDict, "Estado"),
                            DetalleEstado = GetStringValue(rowDict, "Detalle_Estado"),
                            JefeORH = GetStringValue(rowDict, "Jefe_ORH"),
                            JefeUnidad = GetStringValue(rowDict, "Jefe_Unidad"),
                            SerCivil = GetStringValue(rowDict, "SerCivil"),
                            DiasVencimiento = GetInt32Value(rowDict, "DiasVencimiento"),
                            NumEstado = GetNullableDecimalValue(rowDict, "num_estado")
                        };

                        mappedResults.Add(dto);
                    }

                    _logger.LogInformation("Query executed in {0}ms. Returned {1} rows.",
                        stopwatch.ElapsedMilliseconds, mappedResults.Count);

                    return mappedResults;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar pedimentos con parámetros: Consulta=19, mini=0, pedimento={0}, cod_institucion={1}",
                    parametros.Pedimento, parametros.CodInstitucion);
                throw;
            }
        }

        // Métodos auxiliares para obtener valores de manera segura del diccionario dinámico
        private string GetStringValue(IDictionary<string, object> dict, string key)
        {
            if (!dict.ContainsKey(key) || dict[key] == null || dict[key] == DBNull.Value)
                return null;

            return dict[key].ToString();
        }

        private decimal GetDecimalValue(IDictionary<string, object> dict, string key)
        {
            if (!dict.ContainsKey(key) || dict[key] == null || dict[key] == DBNull.Value)
                return 0;

            if (dict[key] is decimal decimalValue)
                return decimalValue;

            if (decimal.TryParse(dict[key].ToString(), out decimal result))
                return result;

            return 0;
        }

        private decimal? GetNullableDecimalValue(IDictionary<string, object> dict, string key)
        {
            if (!dict.ContainsKey(key) || dict[key] == null || dict[key] == DBNull.Value)
                return null;

            if (dict[key] is decimal decimalValue)
                return decimalValue;

            if (decimal.TryParse(dict[key].ToString(), out decimal result))
                return result;

            return null;
        }

        private bool GetBooleanValue(IDictionary<string, object> dict, string key)
        {
            if (!dict.ContainsKey(key) || dict[key] == null || dict[key] == DBNull.Value)
                return false;

            if (dict[key] is bool boolValue)
                return boolValue;

            if (dict[key] is int intValue)
                return intValue != 0;

            if (bool.TryParse(dict[key].ToString(), out bool result))
                return result;

            // En SQL Server, a menudo 1 = true, 0 = false
            if (int.TryParse(dict[key].ToString(), out int intResult))
                return intResult != 0;

            return false;
        }

        private DateTime GetDateTimeValue(IDictionary<string, object> dict, string key)
        {
            if (!dict.ContainsKey(key) || dict[key] == null || dict[key] == DBNull.Value)
                return DateTime.MinValue;

            if (dict[key] is DateTime dateTimeValue)
                return dateTimeValue;

            if (DateTime.TryParse(dict[key].ToString(), out DateTime result))
                return result;

            return DateTime.MinValue;
        }

        private int GetInt32Value(IDictionary<string, object> dict, string key)
        {
            if (!dict.ContainsKey(key) || dict[key] == null || dict[key] == DBNull.Value)
                return 0;

            if (dict[key] is int intValue)
                return intValue;

            if (int.TryParse(dict[key].ToString(), out int result))
                return result;

            return 0;
        }

        // Método auxiliar para obtener valores de manera segura del diccionario dinámico
        private T GetValueOrDefault<T>(IDictionary<string, object> dict, string key, T defaultValue = default)
        {
            if (!dict.ContainsKey(key) || dict[key] == null || dict[key] == DBNull.Value)
                return defaultValue;

            try
            {
                // Intentar convertir el valor al tipo esperado
                return (T)Convert.ChangeType(dict[key], typeof(T));
            }
            catch
            {
                // Si la conversión falla, devolver el valor por defecto
                return defaultValue;
            }
        }

        /// <inheritdoc/>
        public async Task<string> AgregarPedimentoAsync(InsertarPedimentoPersonalDto pedimento)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new DynamicParameters();

                    // Parámetro de salida para el código de pedimento generado
                    parameters.Add("@pedimento", dbType: DbType.String, direction: ParameterDirection.Output, size: 15);

                    // Parámetros de entrada
                    parameters.Add("@cod_institucion", pedimento.CodInstitucion, DbType.Decimal);
                    parameters.Add("@cod_dependencia", pedimento.CodDependencia, DbType.Decimal);
                    parameters.Add("@num_puesto", pedimento.NumPuesto, DbType.Decimal);
                    parameters.Add("@cod_presupuesto", pedimento.CodPresupuesto, DbType.String);
                    parameters.Add("@cod_estrato", pedimento.CodEstrato, DbType.Decimal);
                    parameters.Add("@cod_clase_gen", pedimento.CodClaseGen, DbType.Decimal);
                    parameters.Add("@cod_clase", pedimento.CodClase, DbType.String);
                    parameters.Add("@cod_especialidad", pedimento.CodEspecialidad, DbType.Decimal);
                    parameters.Add("@cod_sub_especialidad", pedimento.CodSubEspecialidad, DbType.Decimal);
                    parameters.Add("@cod_cargo", pedimento.CodCargo, DbType.Decimal);
                    parameters.Add("@cod_motivo", pedimento.CodMotivo, DbType.Decimal);
                    parameters.Add("@int_identificacion", pedimento.IntIdentificacion, DbType.String);
                    parameters.Add("@int_nombre", pedimento.IntNombre, DbType.String);
                    parameters.Add("@cod_departamento", pedimento.CodDepartamento, DbType.Decimal);
                    parameters.Add("@cod_provincia", pedimento.CodProvincia, DbType.Decimal);
                    parameters.Add("@cod_canton", pedimento.CodCanton, DbType.Decimal);
                    parameters.Add("@cod_distrito", pedimento.CodDistrito, DbType.Decimal);
                    parameters.Add("@destacado", pedimento.Destacado, DbType.Decimal);
                    parameters.Add("@espec_destacado", pedimento.EspecDestacado, DbType.String);
                    parameters.Add("@traslado", pedimento.Traslado, DbType.Boolean);
                    parameters.Add("@espec_traslado", pedimento.EspecTraslado, DbType.String);
                    parameters.Add("@cod_jornada", pedimento.CodJornada, DbType.Decimal);
                    parameters.Add("@cod_horario", pedimento.CodHorario, DbType.Decimal);
                    parameters.Add("@observaciones", pedimento.Observaciones, DbType.String);
                    parameters.Add("@cod_tipo_resolucion", pedimento.CodTipoResolucion, DbType.Decimal);
                    parameters.Add("@detalles_resolucion", pedimento.DetallesResolucion, DbType.String);
                    parameters.Add("@usuario", pedimento.Usuario, DbType.String);
                    parameters.Add("@anula_ped", pedimento.AnulaPed, DbType.Boolean);
                    parameters.Add("@num_pedimento", pedimento.NumPedimento, DbType.String);
                    parameters.Add("@detalles", pedimento.Detalles, DbType.String);
                    parameters.Add("@observaciones_ped", pedimento.ObservacionesPed, DbType.String);

                    // Registrar la consulta SQL
                    LogSqlQuery("sp_rys_insert_pedimento_personal", parameters);

                    // Medir el tiempo de ejecución
                    var stopwatch = Stopwatch.StartNew();

                    await connection.ExecuteAsync(
                        "sp_rys_insert_pedimento_personal",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    stopwatch.Stop();

                    // Obtener el código de pedimento generado
                    string codigoPedimento = parameters.Get<string>("@pedimento");

                    // Registrar el tiempo de ejecución y el resultado
                    _logger.LogInformation("Query executed in {ElapsedMs}ms. Pedimento created with code: {CodigoPedimento}",
                        stopwatch.ElapsedMilliseconds, codigoPedimento);

                    return codigoPedimento;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar pedimento para la institución {CodInstitucion}, dependencia {CodDependencia}, puesto {NumPuesto}",
                    pedimento.CodInstitucion, pedimento.CodDependencia, pedimento.NumPuesto);
                throw;
            }
        }
    }
}