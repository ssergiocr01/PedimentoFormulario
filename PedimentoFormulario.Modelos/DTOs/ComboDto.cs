namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO genérico para combos simples
    /// </summary>
    public class ComboDto
    {
        /// <summary>
        /// Valor que se enviará al servidor
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Texto que se mostrará en el combo
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Indica si el elemento está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}

