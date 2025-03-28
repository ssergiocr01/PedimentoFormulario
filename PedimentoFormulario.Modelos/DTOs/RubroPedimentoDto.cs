namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para representar la relación entre un rubro salarial y un pedimento
    /// </summary>
    public class RubroPedimentoDto
    {
        /// <summary>
        /// Código del rubro salarial
        /// </summary>
        public decimal cod_rubro_salaria { get; set; }

        /// <summary>
        /// Código de la institución
        /// </summary>
        public decimal cod_institucion { get; set; }

        /// <summary>
        /// Identificador del pedimento
        /// </summary>
        public string pedimento { get; set; }

        /// <summary>
        /// Detalles adicionales del rubro salarial para el pedimento
        /// </summary>
        public string detalles { get; set; }

        /// <summary>
        /// Usuario que registra o modifica la relación
        /// </summary>
        public string usuario { get; set; }
    }
}

