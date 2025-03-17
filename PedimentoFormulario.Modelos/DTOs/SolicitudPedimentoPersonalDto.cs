using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para transferir datos de solicitud de pedimento personal
    /// </summary>
    public class SolicitudPedimentoPersonalDto
    {
        // Propiedades principales
        public string Pedimento { get; set; }
        public decimal CodInstitucion { get; set; }
        public decimal CodDependencia { get; set; }
        public decimal NumPuesto { get; set; }
        public string CodPresupuesto { get; set; }

        // Clasificación del puesto
        public decimal CodEstrato { get; set; }
        public string NombreEstrato { get; set; }
        public decimal CodClaseGen { get; set; }
        public string NombreClaseGen { get; set; }
        public string CodClase { get; set; }
        public string NombreClase { get; set; }
        public decimal CodEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; }
        public decimal CodSubEspecialidad { get; set; }
        public string NombreSubEspecialidad { get; set; }
        public decimal CodCargo { get; set; }
        public string NombreCargo { get; set; }

        // Información de ubicación
        public decimal CodDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public decimal CodProvincia { get; set; }
        public string NombreProvincia { get; set; }
        public decimal CodCanton { get; set; }
        public string NombreCanton { get; set; }
        public decimal CodDistrito { get; set; }
        public string NombreDistrito { get; set; }

        // Información de jornada
        public decimal CodJornada { get; set; }
        public string NombreJornada { get; set; }
        public decimal CodHorario { get; set; }
        public string DescripcionHorario { get; set; }

        // Información de motivo y resolución
        public decimal CodMotivo { get; set; }
        public string NombreMotivo { get; set; }
        public decimal? CodTipoResolucion { get; set; }
        public string NombreTipoResolucion { get; set; }

        // Información adicional
        public string Observaciones { get; set; }
        public string DetallesResolucion { get; set; }
        public string Detalles { get; set; }
        public bool ReservaDiscapacidad { get; set; }
        public bool? ReservaAfrodescendiente { get; set; }

        // Información de estado
        public decimal? CodEstPedUlt { get; set; }
        public string NombreEstadoActual { get; set; }

        // Información de auditoría
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaMod { get; set; }
        public string UsuarioMod { get; set; }

        // Listas relacionadas
        public List<TareaPuestoDto> Tareas { get; set; } = new List<TareaPuestoDto>();
        public List<EstadoPedimentoDto> Estados { get; set; } = new List<EstadoPedimentoDto>();
        public List<FirmaPedimentoDto> Firmas { get; set; } = new List<FirmaPedimentoDto>();
    }
}

