using System.Collections.Generic;
using System.Threading.Tasks;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.BLL.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de combos del formulario de pedimentos
    /// </summary>
    public interface ICombosService
    {
        #region Ubicación Geográfica

        /// <summary>
        /// Obtiene todas las provincias activas
        /// </summary>
        /// <returns>Lista de provincias</returns>
        Task<IEnumerable<ProvinciaDto>> GetProvinciasAsync();

        /// <summary>
        /// Obtiene los cantones activos de una provincia
        /// </summary>
        /// <param name="codProvincia">Código de la provincia</param>
        /// <returns>Lista de cantones</returns>
        Task<IEnumerable<CantonDto>> GetCantonesByProvinciaAsync(decimal codProvincia);

        /// <summary>
        /// Obtiene los distritos activos de un cantón
        /// </summary>
        /// <param name="codProvincia">Código de la provincia</param>
        /// <param name="codCanton">Código del cantón</param>
        /// <returns>Lista de distritos</returns>
        Task<IEnumerable<DistritoDto>> GetDistritosByCantonAsync(decimal codProvincia, decimal codCanton);

        #endregion

        #region Clasificación

        /// <summary>
        /// Obtiene todos los estratos activos
        /// </summary>
        /// <returns>Lista de estratos</returns>
        Task<IEnumerable<EstratoDto>> GetEstratosAsync();

        /// <summary>
        /// Obtiene las clases genéricas activas de un estrato
        /// </summary>
        /// <param name="codEstrato">Código del estrato</param>
        /// <returns>Lista de clases genéricas</returns>
        Task<IEnumerable<ClaseGenericaDto>> GetClasesGenericasByEstratoAsync(decimal codEstrato);

        /// <summary>
        /// Obtiene las clases activas de una clase genérica
        /// </summary>
        /// <param name="codEstrato">Código del estrato</param>
        /// <param name="codClaseGen">Código de la clase genérica</param>
        /// <returns>Lista de clases</returns>
        Task<IEnumerable<ClaseDto>> GetClasesByClaseGenericaAsync(decimal codEstrato, decimal codClaseGen);

        /// <summary>
        /// Obtiene las especialidades activas que aplican para una clase específica
        /// </summary>
        /// <param name="codClase">Código de la clase (opcional)</param>
        /// <returns>Lista de DTOs de especialidades aplicables</returns>
        Task<IEnumerable<EspecialidadDto>> GetEspecialidadesAsync(string codClase = null!);

        /// <summary>
        /// Obtiene las subespecialidades activas de una especialidad
        /// </summary>
        /// <param name="codEspecialidad">Código de la especialidad</param>
        /// <returns>Lista de subespecialidades</returns>
        Task<IEnumerable<SubespecialidadDto>> GetSubespecialidadesByEspecialidadAsync(decimal codEspecialidad);

        #endregion

        #region Institucional

        /// <summary>
        /// Obtiene todas las instituciones activas
        /// </summary>
        /// <returns>Lista de instituciones</returns>
        Task<IEnumerable<InstitucionDto>> GetInstitucionesAsync();

        /// <summary>
        /// Obtiene las dependencias activas de una institución
        /// </summary>
        /// <param name="codInstitucion">Código de la institución</param>
        /// <returns>Lista de dependencias</returns>
        Task<IEnumerable<DependenciaDto>> GetDependenciasByInstitucionAsync(decimal codInstitucion);

        /// <summary>
        /// Obtiene los departamentos activos de una institución
        /// </summary>
        /// <param name="codInstitucion">Código de la institución</param>
        /// <returns>Lista de departamentos</returns>
        Task<IEnumerable<DepartamentoDto>> GetDepartamentosByInstitucionAsync(decimal codInstitucion);

        /// <summary>
        /// Obtiene los cargos activos por institución y clase
        /// </summary>
        /// <param name="codInstitucion">Código de la institución</param>
        /// <param name="codClase">Código de la clase</param>
        /// <returns>Lista de cargos</returns>
        Task<IEnumerable<CargoDto>> GetCargosByInstitucionAndClaseAsync(decimal codInstitucion, string codClase);

        #endregion

        #region Jornada y Horario

        /// <summary>
        /// Obtiene todas las jornadas activas
        /// </summary>
        /// <returns>Lista de jornadas</returns>
        Task<IEnumerable<JornadaDto>> GetJornadasAsync();

        /// <summary>
        /// Obtiene todos los horarios activos
        /// </summary>
        /// <returns>Lista de horarios</returns>
        Task<IEnumerable<HorarioDto>> GetHorariosAsync();

        #endregion

        #region Motivos y Resoluciones

        /// <summary>
        /// Obtiene todos los motivos de vacante activos
        /// </summary>
        /// <returns>Lista de motivos de vacante</returns>
        Task<IEnumerable<MotivoVacanteDto>> GetMotivosVacanteAsync();

        /// <summary>
        /// Obtiene todos los tipos de resolución activos
        /// </summary>
        /// <returns>Lista de tipos de resolución</returns>
        Task<IEnumerable<TipoResolucionDto>> GetTiposResolucionAsync();

        #endregion

    }
}

