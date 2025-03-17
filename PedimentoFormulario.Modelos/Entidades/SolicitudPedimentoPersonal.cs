using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa una solicitud de pedimento de personal
    /// </summary>
    public class SolicitudPedimentoPersonal
    {
        /// <summary>
        /// Código del pedimento
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Código de la institución
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Código de la dependencia
        /// </summary>
        public decimal CodDependencia { get; set; }

        /// <summary>
        /// Número del puesto
        /// </summary>
        public decimal NumPuesto { get; set; }

        /// <summary>
        /// Código de presupuesto
        /// </summary>
        public string CodPresupuesto { get; set; }

        /// <summary>
        /// Código del estrato
        /// </summary>
        public decimal CodEstrato { get; set; }

        /// <summary>
        /// Código de la clase genérica
        /// </summary>
        public decimal CodClaseGen { get; set; }

        /// <summary>
        /// Código de la clase
        /// </summary>
        public string CodClase { get; set; }

        /// <summary>
        /// Código de la especialidad
        /// </summary>
        public decimal CodEspecialidad { get; set; }

        /// <summary>
        /// Código de la subespecialidad
        /// </summary>
        public decimal CodSubEspecialidad { get; set; }

        /// <summary>
        /// Código del cargo
        /// </summary>
        public decimal CodCargo { get; set; }

        /// <summary>
        /// Código del motivo
        /// </summary>
        public decimal CodMotivo { get; set; }

        /// <summary>
        /// Identificación del interesado
        /// </summary>
        public string IntIdentificacion { get; set; }

        /// <summary>
        /// Nombre del interesado
        /// </summary>
        public string IntNombre { get; set; }

        /// <summary>
        /// Código del departamento
        /// </summary>
        public decimal CodDepartamento { get; set; }

        /// <summary>
        /// Código de la provincia
        /// </summary>
        public decimal CodProvincia { get; set; }

        /// <summary>
        /// Código del cantón
        /// </summary>
        public decimal CodCanton { get; set; }

        /// <summary>
        /// Código del distrito
        /// </summary>
        public decimal CodDistrito { get; set; }

        /// <summary>
        /// Indica si el puesto está destacado
        /// </summary>
        public decimal? Destacado { get; set; }

        /// <summary>
        /// Especificación del destacado
        /// </summary>
        public string EspecDestacado { get; set; }

        /// <summary>
        /// Indica si el puesto requiere traslado
        /// </summary>
        public bool? Traslado { get; set; }

        /// <summary>
        /// Especificación del traslado
        /// </summary>
        public string EspecTraslado { get; set; }

        /// <summary>
        /// Código de la jornada
        /// </summary>
        public decimal CodJornada { get; set; }

        /// <summary>
        /// Código del horario
        /// </summary>
        public decimal CodHorario { get; set; }

        /// <summary>
        /// Observaciones generales
        /// </summary>
        public string Observaciones { get; set; }

        /// <summary>
        /// Código del tipo de resolución
        /// </summary>
        public decimal? CodTipoResolucion { get; set; }

        /// <summary>
        /// Detalles de la resolución
        /// </summary>
        public string DetallesResolucion { get; set; }

        /// <summary>
        /// Consecutivo del pedimento
        /// </summary>
        public decimal Consecutivo { get; set; }

        /// <summary>
        /// Año del pedimento
        /// </summary>
        public decimal Anno { get; set; }

        /// <summary>
        /// Indica si anula un pedimento anterior
        /// </summary>
        public bool? AnulaPed { get; set; }

        /// <summary>
        /// Número del pedimento anulado
        /// </summary>
        public string NumPedimento { get; set; }

        /// <summary>
        /// Detalles adicionales
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Observaciones del pedimento
        /// </summary>
        public string ObservacionesPed { get; set; }

        /// <summary>
        /// Indica si el pedimento es temporal
        /// </summary>
        public bool? Temporal { get; set; }

        /// <summary>
        /// Consecutivo temporal
        /// </summary>
        public decimal? ConsecTemporal { get; set; }

        /// <summary>
        /// Usuario que modificó el pedimento
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de registro del pedimento
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que registró el pedimento
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de modificación del pedimento
        /// </summary>
        public DateTime FechaMod { get; set; }

        /// <summary>
        /// Código del último estado del pedimento
        /// </summary>
        public decimal? CodEstPedUlt { get; set; }

        /// <summary>
        /// Indica si el puesto está reservado para personas con discapacidad
        /// </summary>
        public bool ReservaDiscapacidad { get; set; }

        /// <summary>
        /// Observaciones del concurso interno
        /// </summary>
        public string ObservacionesConcursoInt { get; set; }

        /// <summary>
        /// Indica si el puesto está reservado para personas afrodescendientes
        /// </summary>
        public bool? ReservaAfrodescendiente { get; set; }

        #region Navegación

        /// <summary>
        /// Institución asociada al pedimento
        /// </summary>
        public virtual Institucion Institucion { get; set; }

        /// <summary>
        /// Dependencia asociada al pedimento
        /// </summary>
        public virtual Dependencia Dependencia { get; set; }

        /// <summary>
        /// Departamento asociado al pedimento
        /// </summary>
        public virtual Departamento Departamento { get; set; }

        /// <summary>
        /// Estrato asociado al pedimento
        /// </summary>
        public virtual Estrato Estrato { get; set; }

        /// <summary>
        /// Clase genérica asociada al pedimento
        /// </summary>
        public virtual ClaseGenerica ClaseGenerica { get; set; }

        /// <summary>
        /// Clase asociada al pedimento
        /// </summary>
        public virtual Clase Clase { get; set; }

        /// <summary>
        /// Especialidad asociada al pedimento
        /// </summary>
        public virtual Especialidad Especialidad { get; set; }

        /// <summary>
        /// Subespecialidad asociada al pedimento
        /// </summary>
        public virtual SubEspecialidad SubEspecialidad { get; set; }

        /// <summary>
        /// Cargo asociado al pedimento
        /// </summary>
        public virtual Cargo Cargo { get; set; }

        /// <summary>
        /// Provincia asociada al pedimento
        /// </summary>
        public virtual Provincia Provincia { get; set; }

        /// <summary>
        /// Cantón asociado al pedimento
        /// </summary>
        public virtual Canton Canton { get; set; }

        /// <summary>
        /// Distrito asociado al pedimento
        /// </summary>
        public virtual Distrito Distrito { get; set; }

        /// <summary>
        /// Jornada asociada al pedimento
        /// </summary>
        public virtual Jornada Jornada { get; set; }

        /// <summary>
        /// Horario asociado al pedimento
        /// </summary>
        public virtual Horario Horario { get; set; }

        /// <summary>
        /// Motivo de vacante asociado al pedimento
        /// </summary>
        public virtual MotivoVacante MotivoVacante { get; set; }

        /// <summary>
        /// Tipo de resolución asociado al pedimento
        /// </summary>
        public virtual TipoResolucion TipoResolucion { get; set; }

        /// <summary>
        /// Estados del pedimento
        /// </summary>
        public virtual ICollection<EstadoPedimento> EstadosPedimento { get; set; } = new List<EstadoPedimento>();

        /// <summary>
        /// Tareas del puesto
        /// </summary>
        public virtual ICollection<TareaPuesto> TareasPuesto { get; set; } = new List<TareaPuesto>();

        /// <summary>
        /// Firmas del pedimento
        /// </summary>
        public virtual ICollection<FirmaPedimento> FirmasPedimento { get; set; } = new List<FirmaPedimento>();

        #endregion
    }
}

