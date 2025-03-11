using System;

namespace PedimentoFormulario.Modelos.DTOs
{
    public class EstadoPedimentoDto
    {
        public decimal NumEstado { get; set; }
        public decimal CodEstado { get; set; }
        public string Pedimento { get; set; }
        public string Observaciones { get; set; }
        public string Anexo { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaRige { get; set; }
        public DateTime? FechaVence { get; set; }
        public string NombreEstado { get; set; } // Propiedad adicional para mostrar el nombre del estado
    }
}