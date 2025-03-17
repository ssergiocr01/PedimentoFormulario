namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO genérico para elementos de combos (dropdowns)
    /// </summary>
    public class ComboDto
    {
        /// <summary>
        /// Valor del elemento (generalmente el código o ID)
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Texto a mostrar en el combo (generalmente el nombre o descripción)
        /// </summary>
        public string Text { get; set; }
    }
}

