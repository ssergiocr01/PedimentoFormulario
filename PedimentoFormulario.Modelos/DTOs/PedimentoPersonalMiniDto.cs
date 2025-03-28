namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para los resultados reducidos del procedimiento almacenado sp_rys_select_pedimento_personal
    /// </summary>
    public class PedimentoPersonalMiniDto
    {
        public string Pedimento { get; set; }
        public decimal NumPuesto { get; set; }
        public string CodPresupuesto { get; set; }
        public string Institucion { get; set; }
        public string Dependencia { get; set; }
        public string NombreEstrato { get; set; }
        public string NombreGenerica { get; set; }
        public string TituloDeLaClase { get; set; }
        public string Especialidad { get; set; }
        public string Subespecialidad { get; set; }
        public string NombreCargo { get; set; }
        public string Departamento { get; set; }
        public string Motivo { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Jornada { get; set; }
        public string Horario { get; set; }
        public string Temporal { get; set; }
        public decimal Estado { get; set; }
        public string DetalleEstado { get; set; }
    }
}

