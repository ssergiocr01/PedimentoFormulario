namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un cargo en el sistema de clasificación
    /// </summary>
    public class Cargo
    {
        /// <summary>
        /// Código del cargo
        /// </summary>
        public decimal CodCargo { get; set; }

        /// <summary>
        /// Código del manual de cargos
        /// </summary>
        public decimal CodManual { get; set; }

        /// <summary>
        /// Código de la institución
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Código de la clase
        /// </summary>
        public string CodClase { get; set; }

        /// <summary>
        /// Nombre del cargo
        /// </summary>
        public string NombreCargo { get; set; }

        /// <summary>
        /// Vínculo al documento PDF
        /// </summary>
        public string VinculoDocPdf { get; set; }

        /// <summary>
        /// Estado del cargo (activo/inactivo)
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Usuario que registró el cargo
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del cargo
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó el cargo
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación del cargo
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Clase asociada al cargo
        /// </summary>
        public virtual Clase Clase { get; set; }

        /// <summary>
        /// Institución asociada al cargo
        /// </summary>
        public virtual Institucion Institucion { get; set; }

        /// <summary>
        /// Manual de cargos asociado
        /// </summary>
        public virtual ManualDeCargos ManualDeCargos { get; set; }

        /// <summary>
        /// Solicitudes de pedimento asociadas al cargo
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

