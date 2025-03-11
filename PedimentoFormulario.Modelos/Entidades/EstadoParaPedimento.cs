using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_RyS_estados_para_pedimentos")]
    public class EstadoParaPedimento
    {
        public EstadoParaPedimento()
        {
            // Inicializar colecciones
            EstadosPedimento = new HashSet<EstadoPedimento>();
        }

        [Key]
        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodEstado { get; set; }

        [Required]
        [StringLength(75)]
        [Column("estado")]
        public string NombreEstado { get; set; }

        [StringLength(3000)]
        public string Descripcion { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        [StringLength(20)]
        public string UsuarioReg { get; set; }

        [Required]
        public DateTime FechaReg { get; set; }

        [Required]
        [StringLength(20)]
        public string UsuarioMod { get; set; }

        [Required]
        public DateTime FechaMod { get; set; }

        // Propiedad de navegación para la relación con EstadoPedimento
        public virtual ICollection<EstadoPedimento> EstadosPedimento { get; set; }
    }
}