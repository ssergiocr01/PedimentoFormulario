using System;

namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para los resultados del procedimiento almacenado sp_rys_select_pedimento_personal
    /// </summary>
    public class PedimentoPersonalDto
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
        public string UsuarioMod { get; set; }
        public string UsuarioReg { get; set; }
        public string Institucion { get; set; }
        public string Dependencia { get; set; }
        public string NombreEstrato { get; set; }
        public string NombreGenerica { get; set; }
        public string TituloDeLaClase { get; set; }
        public string Especialidad { get; set; }
        public string Subespecialidad { get; set; }
        public string NombreCargo { get; set; }
        public string Departamento { get; set; }
        public string Motivo { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Jornada { get; set; }
        public string Horario { get; set; }
        public string TipoResolucion { get; set; }
        public bool AnulaPed { get; set; }
        public string NumPedimento { get; set; }
        public string Detalles { get; set; }
        public string ObservacionesPed { get; set; }
        public DateTime FechaReg { get; set; }
        public string Temporal { get; set; }
        public decimal Estado { get; set; }
        public string DetalleEstado { get; set; }
        public string JefeORH { get; set; }
        public string JefeUnidad { get; set; }
        public string SerCivil { get; set; }
        public int? DiasVencimiento { get; set; }
        public decimal? NumEstado { get; set; }
    }
}

