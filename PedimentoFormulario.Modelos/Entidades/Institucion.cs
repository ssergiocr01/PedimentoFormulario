using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_DGSC_Instituciones")]
    public class Institucion
    {
        [Key]
        [Required]
        [Column(TypeName = "numeric(3,0)")]
        public decimal CodInstitucion { get; set; }

        [Required]
        [StringLength(450)]
        [Column("institucion")]
        public string NombreInstitucion { get; set; }

        [Required]
        [StringLength(4)]
        public string Sigla { get; set; }

        [Required]
        public bool Reclutamiento { get; set; }

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

        // Propiedades de navegación
        public virtual ICollection<Dependencia> Dependencias { get; set; }
        public virtual ICollection<Departamento> Departamentos { get; set; }
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
    }
}