using AutoMapper;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Utilities.Mappings
{
    /// <summary>
    /// Perfil de AutoMapper para configurar los mapeos entre entidades y DTOs
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Constructor que configura todos los mapeos
        /// </summary>
        public AutoMapperProfile()
        {
            // Mapeos de ubicación
            CreateMap<Provincia, ProvinciaDto>().ReverseMap();
            CreateMap<Canton, CantonDto>().ReverseMap();
            CreateMap<Distrito, DistritoDto>().ReverseMap();

            // Mapeos de clasificación
            CreateMap<Estrato, EstratoDto>().ReverseMap();
            CreateMap<ClaseGenerica, ClaseGenericaDto>().ReverseMap();
            CreateMap<Clase, ClaseDto>().ReverseMap();
            CreateMap<Especialidad, EspecialidadDto>().ReverseMap();
            CreateMap<SubEspecialidad, SubespecialidadDto>()
                .ForMember(dest => dest.CodSubEspecialidad, opt => opt.MapFrom(src => src.CodSubEspecialidad))
                .ForMember(dest => dest.CodEspecialidad, opt => opt.MapFrom(src => src.CodEspecialidad))
                .ForMember(dest => dest.NombreSubespecialidad, opt => opt.MapFrom(src => src.NombreSubespecialidad))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.Activo))
                .ReverseMap();

            // Mapeos institucionales
            CreateMap<Institucion, InstitucionDto>().ReverseMap();
            CreateMap<Dependencia, DependenciaDto>().ReverseMap();
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<Cargo, CargoDto>().ReverseMap();

            // Mapeos de jornada y horario
            CreateMap<Jornada, JornadaDto>().ReverseMap();
            CreateMap<Horario, HorarioDto>().ReverseMap();

            // Mapeos de motivos
            CreateMap<MotivoVacante, MotivoVacanteDto>()
                .ForMember(dest => dest.CodMotivo, opt => opt.MapFrom(src => src.CodMotivo))
                .ForMember(dest => dest.NombreMotivo, opt => opt.MapFrom(src => src.NombreMotivo))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.Activo))
                .ReverseMap();
            CreateMap<TipoResolucion, TipoResolucionDto>()
                .ForMember(dest => dest.CodTipoResolucion, opt => opt.MapFrom(src => src.CodTipoResolucion))
                .ForMember(dest => dest.NombreTipoResolucion, opt => opt.MapFrom(src => src.NombreTipoResolucion))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.Activo))
                .ReverseMap();

            // Mapeos de estados
            CreateMap<EstadoParaPedimento, EstadoParaPedimentoDto>().ReverseMap();
            CreateMap<EstadoPedimento, EstadoPedimentoDto>()
                .ForMember(dest => dest.NombreEstado, opt => opt.MapFrom(src => src.EstadoParaPedimento.NombreEstado))
                .ReverseMap();

            // Mapeos de pedimentos
            CreateMap<SolicitudPedimentoPersonal, SolicitudPedimentoPersonalDto>()
                .ForMember(dest => dest.NombreEstrato, opt => opt.MapFrom(src => src.Estrato.NombreEstrato))
                .ForMember(dest => dest.NombreClaseGen, opt => opt.MapFrom(src => src.ClaseGenerica.NombreGenerica))
                .ForMember(dest => dest.NombreClase, opt => opt.MapFrom(src => src.Clase.TituloDeLaClase))
                .ForMember(dest => dest.NombreEspecialidad, opt => opt.MapFrom(src => src.Especialidad.NombreEspecialidad))
                .ForMember(dest => dest.NombreSubEspecialidad, opt => opt.MapFrom(src => src.SubEspecialidad.NombreSubespecialidad))
                .ForMember(dest => dest.NombreCargo, opt => opt.MapFrom(src => src.Cargo.NombreCargo))
                .ForMember(dest => dest.NombreDepartamento, opt => opt.MapFrom(src => src.Departamento.NombreDepartamento))
                .ForMember(dest => dest.NombreProvincia, opt => opt.MapFrom(src => src.Provincia.NombreProvincia))
                .ForMember(dest => dest.NombreCanton, opt => opt.MapFrom(src => src.Canton.NombreCanton))
                .ForMember(dest => dest.NombreDistrito, opt => opt.MapFrom(src => src.Distrito.NombreDistrito))
                .ForMember(dest => dest.NombreJornada, opt => opt.MapFrom(src => src.Jornada.NombreJornada))
                .ForMember(dest => dest.DescripcionHorario, opt => opt.MapFrom(src => src.Horario.NombreHorario))
                .ForMember(dest => dest.NombreMotivo, opt => opt.MapFrom(src => src.MotivoVacante.NombreMotivo))
                .ForMember(dest => dest.NombreTipoResolucion, opt => opt.MapFrom(src => src.TipoResolucion != null ? src.TipoResolucion.NombreTipoResolucion : null))
                .ForMember(dest => dest.NombreEstadoActual, opt => opt.MapFrom(src =>
                    src.CodEstPedUlt.HasValue && src.EstadosPedimento.Count > 0 ?
                    src.EstadosPedimento.FirstOrDefault(e => e.CodEstado == src.CodEstPedUlt).EstadoParaPedimento.NombreEstado : null))
                .ForMember(dest => dest.Estados, opt => opt.MapFrom(src => src.EstadosPedimento))
                .ForMember(dest => dest.Firmas, opt => opt.MapFrom(src => src.FirmasPedimento))
                .ForMember(dest => dest.Tareas, opt => opt.MapFrom(src => src.TareasPuesto))
                .ReverseMap();

            // Mapeos de tareas y firmas
            CreateMap<TareaPuesto, TareaPuestoDto>().ReverseMap();
            CreateMap<FirmaPedimento, FirmaPedimentoDto>().ReverseMap();

            // Mapeos de solicitudes
            CreateMap<SolicitudAPedimento, SolicitudAPedimentoDto>()
                .ForMember(dest => dest.NombreInstitucion, opt => opt.MapFrom(src => src.Institucion.NombreInstitucion))
                .ForMember(dest => dest.NombreMotivo, opt => opt.MapFrom(src => src.MotivoVacante.NombreMotivo))
                .ForMember(dest => dest.NombreEstado, opt => opt.MapFrom(src => "")) // Aquí falta la relación con el estado
                .ReverseMap();

            
        }
    }
}

