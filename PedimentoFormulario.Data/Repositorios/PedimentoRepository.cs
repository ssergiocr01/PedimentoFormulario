using Dapper;
using Microsoft.EntityFrameworkCore;
using PedimentoFormulario.Data.Repositorios.Interfaces;
using PedimentoFormulario.Modelos.Entidades;
using System.Data;

namespace PedimentoFormulario.Data.Repositorios
{
    public class PedimentoRepository : IPedimentoRepository
    {
        private readonly PedimentoContext _context;

        public PedimentoRepository(PedimentoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<SolicitudPedimentoPersonal>> GetPedimentosAsync(int tipoConsulta, bool mini, string? pedimento = null, int codInstitucion = 0)
        {
            // Obtenemos la conexión del contexto de EF Core
            var connection = _context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            var parameters = new DynamicParameters();
            parameters.Add("@Consulta", tipoConsulta, DbType.Decimal);
            parameters.Add("@mini", mini, DbType.Boolean);
            parameters.Add("@pedimento", pedimento ?? string.Empty, DbType.String);
            parameters.Add("@cod_institucion", codInstitucion, DbType.Decimal);

            // Ejecutamos el procedimiento almacenado
            var result = await connection.QueryAsync<dynamic>(
                "sp_rys_select_pedimento_personal",
                parameters,
                commandType: CommandType.StoredProcedure);

            // Convertimos los resultados dinámicos a SolicitudPedimentoPersonal
            var solicitudes = new List<SolicitudPedimentoPersonal>();

            foreach (var item in result)
            {
                try
                {
                    var solicitud = new SolicitudPedimentoPersonal
                    {
                        // Mapeamos los campos básicos
                        Pedimento = item.pedimento,
                        CodInstitucion = item.cod_institucion,
                        CodDependencia = item.cod_dependencia,
                        NumPuesto = item.num_puesto,
                        CodPresupuesto = item.cod_presupuesto,
                        CodEstrato = item.cod_estrato,
                        CodClaseGen = item.cod_clase_gen,
                        CodClase = item.cod_clase,
                        CodEspecialidad = item.cod_especialidad,
                        CodSubEspecialidad = item.cod_sub_especialidad,
                        CodCargo = item.cod_cargo,
                        CodMotivo = item.cod_motivo,
                        IntIdentificacion = item.int_identificacion,
                        IntNombre = item.int_nombre,
                        CodDepartamento = item.cod_departamento,
                        CodProvincia = item.cod_provincia,
                        CodCanton = item.cod_canton,
                        CodDistrito = item.cod_distrito,
                        Destacado = item.destacado,
                        EspecDestacado = item.espec_destacado,
                        Traslado = item.traslado,
                        EspecTraslado = item.espec_traslado,
                        CodJornada = item.cod_jornada,
                        CodHorario = item.cod_horario,
                        Observaciones = item.observaciones,
                        CodTipoResolucion = item.cod_tipo_resolucion,
                        DetallesResolucion = item.detalles_resolucion,
                        Consecutivo = item.consecutivo,
                        Anno = item.anno,
                        AnulaPed = item.anula_ped,
                        NumPedimento = item.num_pedimento,
                        Detalles = item.detalles,
                        ObservacionesPed = item.observaciones_ped,
                        UsuarioMod = item.usuariomod,
                        FechaReg = item.fechareg,
                        UsuarioReg = item.usuarioreg,
                        FechaMod = DateTime.Now, // No viene en el resultado, usamos la fecha actual
                        CodEstPedUlt = item.Estado, // Mapeamos el estado actual
                        ReservaDiscapacidad = item.ReservaDiscapacidad ?? false,
                        ObservacionesConcursoInt = item.ObservacionesConcursoInt,
                        ReservaAfrodescendiente = item.ReservaAfrodescendiente ?? false
                    };

                    // Agregamos la solicitud a la lista
                    solicitudes.Add(solicitud);
                }
                catch (Exception ex)
                {
                    // Manejo de errores al mapear los resultados
                    Console.WriteLine($"Error al mapear el pedimento: {ex.Message}");
                }
            }

            return solicitudes;
        }
    }
}