namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para agregar una firma a un pedimento
    /// </summary>
    public class AgregarFirmaDto
    {
        /// <summary>
        /// Tipo de firma (0 = Jefe de Área, 1 = Jefe de ORH, 2 = Recibido Servicio Civil)
        /// </summary>
        public decimal TipoFirma { get; set; }

        /// <summary>
        /// Usuario que registra la firma
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Observaciones de la firma
        /// </summary>
        public string Observaciones { get; set; }
    }
}

