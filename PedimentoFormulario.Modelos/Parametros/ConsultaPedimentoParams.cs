namespace PedimentoFormulario.Modelos.Parametros
{
    /// <summary>
    /// Parámetros para la consulta de pedimentos de personal
    /// </summary>
    public class ConsultaPedimentoParams
    {
        /// <summary>
        /// Tipo de consulta (0-22)
        /// </summary>
        public decimal Consulta { get; set; }

        /// <summary>
        /// Indica si se debe devolver un conjunto reducido de datos (0=completo, 1=reducido)
        /// </summary>
        public bool Mini { get; set; }

        /// <summary>
        /// Código del pedimento específico a consultar (opcional)
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Código de la institución a filtrar (0=todas)
        /// </summary>
        public decimal CodInstitucion { get; set; }
    }
}

