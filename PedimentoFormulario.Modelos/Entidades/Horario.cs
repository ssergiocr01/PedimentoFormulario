using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_RyS_horarios")]
    public class Horario
    {
        public Horario()
        {
            SolicitudesPedimento = new HashSet<SolicitudPedimentoPersonal>();
        }

        [Key]
        [Required]
        [Column(TypeName = "numeric(4,0)")]
        public decimal CodHorario { get; set; }

        [Required]
        [StringLength(35)]
        [Column("horario")]
        public string NombreHorario { get; set; }

        [Required]
        [StringLength(145)]
        public string Detalles { get; set; }

        [Required]
        public bool Activo { get; set; }

        [StringLength(20)]
        public string UsuarioReg { get; set; }

        public DateTime? FechaReg { get; set; }

        [StringLength(20)]
        public string UsuarioMod { get; set; }

        public DateTime? FechaMod { get; set; }

        // Propiedad de navegación
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
    }
}