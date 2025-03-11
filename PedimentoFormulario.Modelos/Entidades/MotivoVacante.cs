using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_RyS_motivos_vacante")]
    public class MotivoVacante
    {
        public MotivoVacante()
        {
            SolicitudesPedimento = new HashSet<SolicitudPedimentoPersonal>();
            SolicitudesAPedimento = new HashSet<SolicitudAPedimento>();
        }

        [Key]
        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodMotivo { get; set; }

        [Required]
        [StringLength(35)]
        [Column("motivo")]
        public string NombreMotivo { get; set; }

        [StringLength(3000)]
        public string Detalles { get; set; }

        [Required]
        public bool Activo { get; set; }

        [StringLength(20)]
        public string UsuarioReg { get; set; }

        public DateTime? FechaReg { get; set; }

        [StringLength(20)]
        public string UsuarioMod { get; set; }

        public DateTime? FechaMod { get; set; }

        // Propiedades de navegación
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
        public virtual ICollection<SolicitudAPedimento> SolicitudesAPedimento { get; set; }
    }
}