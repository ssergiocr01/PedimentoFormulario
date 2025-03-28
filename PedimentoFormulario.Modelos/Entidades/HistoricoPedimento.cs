﻿using System;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa el historial de cambios de un pedimento
    /// </summary>
    public class HistoricoPedimento
    {
        /// <summary>
        /// Identificador único del registro histórico
        /// </summary>
        public decimal IdHistorico { get; set; }

        /// <summary>
        /// Número de solicitud asociada
        /// </summary>
        public decimal NumSolicitud { get; set; }

        /// <summary>
        /// Código del pedimento
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Código de la institución
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Código de la dependencia
        /// </summary>
        public decimal CodDependencia { get; set; }

        /// <summary>
        /// Número del puesto
        /// </summary>
        public decimal NumPuesto { get; set; }

        /// <summary>
        /// Código presupuestario
        /// </summary>
        public decimal? CodPresupuesto { get; set; }

        /// <summary>
        /// Código del estrato
        /// </summary>
        public decimal CodEstrato { get; set; }

        /// <summary>
        /// Código de la clase genérica
        /// </summary>
        public decimal CodClaseGen { get; set; }

        /// <summary>
        /// Código de la clase
        /// </summary>
        public string CodClase { get; set; }

        /// <summary>
        /// Código de la especialidad
        /// </summary>
        public decimal CodEspecialidad { get; set; }

        /// <summary>
        /// Código de la subespecialidad
        /// </summary>
        public decimal CodSubEspecialidad { get; set; }

        /// <summary>
        /// Código del cargo
        /// </summary>
        public decimal CodCargo { get; set; }

        /// <summary>
        /// Código del motivo
        /// </summary>
        public decimal CodMotivo { get; set; }

        /// <summary>
        /// Identificación del interino
        /// </summary>
        public string IntIdentificacion { get; set; }

        /// <summary>
        /// Nombre del interino
        /// </summary>
        public string IntNombre { get; set; }

        /// <summary>
        /// Código del departamento
        /// </summary>
        public decimal CodDepartamento { get; set; }

        /// <summary>
        /// Código de la provincia
        /// </summary>
        public decimal CodProvincia { get; set; }

        /// <summary>
        /// Código del cantón
        /// </summary>
        public decimal CodCanton { get; set; }

        /// <summary>
        /// Código del distrito
        /// </summary>
        public decimal CodDistrito { get; set; }

        /// <summary>
        /// Indica si el puesto está destacado
        /// </summary>
        public decimal? Destacado { get; set; }

        /// <summary>
        /// Especificación del destacado
        /// </summary>
        public string EspecDestacado { get; set; }

        /// <summary>
        /// Indica si hay traslado
        /// </summary>
        public bool? Traslado { get; set; }

        /// <summary>
        /// Especificación del traslado
        /// </summary>
        public string EspecTraslado { get; set; }

        /// <summary>
        /// Código de la jornada
        /// </summary>
        public decimal CodJornada { get; set; }

        /// <summary>
        /// Código del horario
        /// </summary>
        public decimal CodHorario { get; set; }

        /// <summary>
        /// Observaciones generales
        /// </summary>
        public string Observaciones { get; set; }

        /// <summary>
        /// Código del tipo de resolución
        /// </summary>
        public decimal? CodTipoResolucion { get; set; }

        /// <summary>
        /// Detalles de la resolución
        /// </summary>
        public string DetallesResolucion { get; set; }

        /// <summary>
        /// Número consecutivo
        /// </summary>
        public decimal Consecutivo { get; set; }

        /// <summary>
        /// Año del pedimento
        /// </summary>
        public decimal Anno { get; set; }

        /// <summary>
        /// Indica si anula un pedimento anterior
        /// </summary>
        public bool? AnulaPed { get; set; }

        /// <summary>
        /// Número del pedimento anulado
        /// </summary>
        public string NumPedimento { get; set; }

        /// <summary>
        /// Detalles adicionales
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Observaciones específicas del pedimento
        /// </summary>
        public string ObservacionesPed { get; set; }

        /// <summary>
        /// Usuario que modificó el registro
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de registro
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que registró el pedimento
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de la última modificación
        /// </summary>
        public DateTime FechaMod { get; set; }
    }
}

