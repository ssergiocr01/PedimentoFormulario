using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_RyS_pedimento_personal")]
    public class SolicitudPedimentoPersonal
    {
        public SolicitudPedimentoPersonal()
        {
            // Inicializar colecciones
            FirmasPedimento = new HashSet<FirmaPedimento>();
            EstadosPedimento = new HashSet<EstadoPedimento>();
        }

        [Key]
        [Required]
        [StringLength(15)]
        public string Pedimento { get; set; }

        [Required]
        [Column(TypeName = "numeric(3,0)")]
        public decimal CodInstitucion { get; set; }

        [Required]
        [Column(TypeName = "numeric(4,0)")]
        public decimal CodDependencia { get; set; }

        [Required]
        [Column(TypeName = "numeric(15,0)")]
        public decimal NumPuesto { get; set; }

        [StringLength(20)]
        public string CodPresupuesto { get; set; }

        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodEstrato { get; set; }

        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodClaseGen { get; set; }

        [Required]
        [StringLength(15)]
        public string CodClase { get; set; }

        [Required]
        [Column(TypeName = "numeric(3,0)")]
        public decimal CodEspecialidad { get; set; }

        [Required]
        [Column(TypeName = "numeric(3,0)")]
        public decimal CodSubEspecialidad { get; set; }

        [Required]
        [Column(TypeName = "numeric(5,0)")]
        public decimal CodCargo { get; set; }

        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodMotivo { get; set; }

        [StringLength(20)]
        public string IntIdentificacion { get; set; }

        [StringLength(80)]
        public string IntNombre { get; set; }

        [Required]
        [Column(TypeName = "numeric(6,0)")]
        public decimal CodDepartamento { get; set; }

        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodProvincia { get; set; }

        [Required]
        [Column(TypeName = "numeric(3,0)")]
        public decimal CodCanton { get; set; }

        [Required]
        [Column(TypeName = "numeric(3,0)")]
        public decimal CodDistrito { get; set; }

        [Column(TypeName = "numeric(1,0)")]
        public decimal? Destacado { get; set; }

        public string EspecDestacado { get; set; }

        public bool? Traslado { get; set; }

        public string EspecTraslado { get; set; }

        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodJornada { get; set; }

        [Required]
        [Column(TypeName = "numeric(4,0)")]
        public decimal CodHorario { get; set; }

        public string Observaciones { get; set; }

        [Column(TypeName = "numeric(2,0)")]
        public decimal? CodTipoResolucion { get; set; }

        public string DetallesResolucion { get; set; }

        [Required]
        [Column(TypeName = "numeric(5,0)")]
        public decimal Consecutivo { get; set; }

        [Required]
        [Column(TypeName = "numeric(4,0)")]
        public decimal Anno { get; set; }

        public bool? AnulaPed { get; set; }

        [StringLength(15)]
        public string NumPedimento { get; set; }

        public string Detalles { get; set; }

        public string ObservacionesPed { get; set; }

        public bool? Temporal { get; set; }

        [Column(TypeName = "numeric(5,0)")]
        public decimal? ConsecTemporal { get; set; }

        [Required]
        [StringLength(20)]
        public string UsuarioMod { get; set; }

        [Required]
        public DateTime FechaReg { get; set; }

        [Required]
        [StringLength(20)]
        public string UsuarioReg { get; set; }

        [Required]
        public DateTime FechaMod { get; set; }

        [Column(TypeName = "numeric(2,0)")]
        public decimal? CodEstPedUlt { get; set; }

        [Required]
        public bool ReservaDiscapacidad { get; set; }

        public string ObservacionesConcursoInt { get; set; }

        public bool? ReservaAfrodescendiente { get; set; }

        // Propiedades de navegación - Institucionales
        [ForeignKey("CodInstitucion")]
        public virtual Institucion Institucion { get; set; }

        [ForeignKey("CodDependencia,CodInstitucion")]
        public virtual Dependencia Dependencia { get; set; }

        [ForeignKey("CodDepartamento,CodInstitucion")]
        public virtual Departamento Departamento { get; set; }

        // Propiedades de navegación - Clasificación
        [ForeignKey("CodEstrato")]
        public virtual Estrato Estrato { get; set; }

        [ForeignKey("CodClaseGen,CodEstrato")]
        public virtual ClaseGenerica ClaseGenerica { get; set; }

        [ForeignKey("CodClase")]
        public virtual Clase Clase { get; set; }

        [ForeignKey("CodEspecialidad")]
        public virtual Especialidad Especialidad { get; set; }

        [ForeignKey("CodSubEspecialidad,CodEspecialidad")]
        public virtual SubEspecialidad SubEspecialidad { get; set; }

        [ForeignKey("CodCargo")]
        public virtual Cargo Cargo { get; set; }

        // Propiedades de navegación - División Territorial
        [ForeignKey("CodProvincia")]
        public virtual Provincia Provincia { get; set; }

        [ForeignKey("CodCanton,CodProvincia")]
        public virtual Canton Canton { get; set; }

        [ForeignKey("CodDistrito,CodCanton,CodProvincia")]
        public virtual Distrito Distrito { get; set; }

        // Relaciones con otras entidades
        public virtual ICollection<FirmaPedimento> FirmasPedimento { get; set; }
        public virtual ICollection<EstadoPedimento> EstadosPedimento { get; set; }

        // Otras propiedades de navegación se pueden agregar según sea necesario
    }
}