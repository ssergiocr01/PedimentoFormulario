namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para representar el resultado de la consulta de rubros salariales por pedimento
    /// </summary>
    public class RubroPedimentoResultadoDto
    {
        /// <summary>
        /// Código del rubro salarial
        /// </summary>
        public decimal CodRubroSalarial { get; set; }

        /// <summary>
        /// Usuario que registró la relación
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Código de la institución
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Identificador del pedimento
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Nombre del rubro salarial
        /// </summary>
        public string NombreRubroSalarial { get; set; }

        /// <summary>
        /// Detalles adicionales del rubro salarial para el pedimento
        /// </summary>
        public string Detalles { get; set; }
    }
}

