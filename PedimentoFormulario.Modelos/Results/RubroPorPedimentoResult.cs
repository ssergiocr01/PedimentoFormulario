using System;

namespace PedimentoFormulario.Modelos.Results
{
    /// <summary>
    /// Objeto de resultado para mapear el procedimiento almacenado sp_rys_select_rubros_x_pedimento
    /// </summary>
    public class RubroPorPedimentoResult
    {
        /// <summary>
        /// Código del rubro salarial
        /// </summary>
        public decimal CodRubroSalarial { get; set; }

        /// <summary>
        /// Nombre o descripción del rubro salarial
        /// </summary>
        public string NombreRubroSalarial { get; set; }

        /// <summary>
        /// Detalles adicionales sobre el rubro salarial en este pedimento
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Código de la institución
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Identificador del pedimento
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Usuario que registró la relación
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó por última vez la relación
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de la última modificación
        /// </summary>
        public DateTime FechaMod { get; set; }
    }
}