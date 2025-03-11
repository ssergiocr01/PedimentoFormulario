using AutoMapper;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Utilities.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeo básico de SolicitudPedimentoPersonal sin propiedades de navegación
            CreateMap<SolicitudPedimentoPersonal, SolicitudPedimentoPersonalDto>();
            CreateMap<SolicitudPedimentoPersonalDto, SolicitudPedimentoPersonal>();

            // Mapeo de TareaPuesto
            CreateMap<TareaPuesto, TareaPuestoDto>();
            CreateMap<TareaPuestoDto, TareaPuesto>();

            // Mapeo de FirmaPedimento
            CreateMap<FirmaPedimento, FirmaPedimentoDto>();
            CreateMap<FirmaPedimentoDto, FirmaPedimento>();

            // Mapeo básico de EstadoPedimento sin propiedades de navegación
            CreateMap<EstadoPedimento, EstadoPedimentoDto>();
            CreateMap<EstadoPedimentoDto, EstadoPedimento>();

            // Otros mapeos que se necesiten para la aplicación
            // CreateMap<Clase, ClaseDto>();
            // CreateMap<Especialidad, EspecialidadDto>();
            // etc.
        }
    }
}