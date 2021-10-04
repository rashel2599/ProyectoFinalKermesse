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
    
    public partial class IngresoComunidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IngresoComunidad()
        {
            this.IngresoComunidadDet = new HashSet<IngresoComunidadDet>();
        }
    
        public int idIngresoComunidad { get; set; }
        public Nullable<int> kermesse { get; set; }
        public Nullable<int> comunidad { get; set; }
        public Nullable<int> producto { get; set; }
        public int cantProducto { get; set; }
        public int totalBonos { get; set; }
        public int usuarioCreacion { get; set; }
        public System.DateTime fechaCreacion { get; set; }
        public Nullable<int> usuarioModificacion { get; set; }
        public Nullable<System.DateTime> fechaModificacion { get; set; }
        public Nullable<int> usuarioEliminacion { get; set; }
        public Nullable<System.DateTime> fechaEliminacion { get; set; }
    
        public virtual Comunidad Comunidad1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IngresoComunidadDet> IngresoComunidadDet { get; set; }
        public virtual Kermesse Kermesse1 { get; set; }
        public virtual Producto Producto1 { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        public virtual Usuario Usuario2 { get; set; }
    }
}