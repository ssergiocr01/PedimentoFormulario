using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PedimentoFormulario.Modelos.DTOs
{
    public class SolicitudPedimentoPersonalDto
    {
        public string Pedimento { get; set; }
        public decimal CodInstitucion { get; set; }
        public decimal CodDependencia { get; set; }
        public decimal NumPuesto { get; set; }
        public string CodPresupuesto { get; set; }
        public decimal CodEstrato { get; set; }
        public decimal CodClaseGen { get; set; }
        public string CodClase { get; set; }
        public decimal CodEspecialidad { get; set; }
        public decimal CodSubEspecialidad { get; set; }
        public decimal CodCargo { get; set; }
        public decimal CodMotivo { get; set; }
        public string IntIdentificacion { get; set; }
        public string IntNombre { get; set; }
        public decimal CodDepartamento { get; set; }
        public decimal CodProvincia { get; set; }
        public decimal CodCanton { get; set; }
        public decimal CodDistrito { get; set; }
        public decimal? Destacado { get; set; }
        public string EspecDestacado { get; set; }
        public bool? Traslado { get; set; }
        public string EspecTraslado { get; set; }
        public decimal CodJornada { get; set; }
        public decimal CodHorario { get; set; }
        public string Observaciones { get; set; }
        public decimal? CodTipoResolucion { get; set; }
        public string DetallesResolucion { get; set; }
        public decimal Consecutivo { get; set; }
        public decimal Anno { get; set; }
        public bool? AnulaPed { get; set; }
        public string NumPedimento { get; set; }
        public string Detalles { get; set; }
        public string ObservacionesPed { get; set; }
        public bool? Temporal { get; set; }
        public decimal? ConsecTemporal { get; set; }
        public decimal? CodEstPedUlt { get; set; }
        public bool ReservaDiscapacidad { get; set; }
        public string ObservacionesConcursoInt { get; set; }
        public bool? ReservaAfrodescendiente { get; set; }

        // Propiedades de navegación
        public List<TareaPuestoDto> TareasPuesto { get; set; } = new List<TareaPuestoDto>();
        public List<FirmaPedimentoDto> FirmasPedimento { get; set; } = new List<FirmaPedimentoDto>();
        public List<EstadoPedimentoDto> EstadosPedimento { get; set; } = new List<EstadoPedimentoDto>();
    }
}