namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un cantón (división administrativa)
    /// </summary>
    public class Canton
    {
        /// <summary>
        /// Código del cantón
        /// </summary>
        public decimal CodCanton { get; set; }

        /// <summary>
        /// Código de la provincia a la que pertenece el cantón
        /// </summary>
        public decimal CodProvincia { get; set; }

        /// <summary>
        /// Nombre del cantón
        /// </summary>
        public string NombreCanton { get; set; }

        /// <summary>
        /// Indica si el cantón está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró el cantón
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del cantón
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó el cantón
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación del cantón
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Provincia a la que pertenece el cantón
        /// </summary>
        public virtual Provincia Provincia { get; set; }

        /// <summary>
        /// Distritos que pertenecen al cantón
        /// </summary>
        public virtual ICollection<Distrito> Distritos { get; set; } = new List<Distrito>();

        /// <summary>
        /// Solicitudes de pedimento asociadas al cantón
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

