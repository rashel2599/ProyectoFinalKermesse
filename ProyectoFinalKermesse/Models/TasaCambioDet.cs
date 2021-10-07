//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinalKermesse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TasaCambioDet
    {
        [Display(Name="Id Tasa Cambio")]
        public int idTasaCambioDet { get; set; }

        [Display(Name="Tasa Cambio")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int tasaCambio { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date, ErrorMessage = "Por favor ingrese un fecha válida")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public System.DateTime fecha { get; set; }

        [Display(Name = "Tipo Cambio")]
        [DataType(DataType.Currency, ErrorMessage = "Por favor ingrese un dato decimal")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public decimal tipoCambio { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int estado { get; set; }
    
        public virtual TasaCambio TasaCambio1 { get; set; }
    }
}
