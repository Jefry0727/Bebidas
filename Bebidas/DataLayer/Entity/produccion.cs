//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class produccion
    {
        public int id { get; set; }
        public string codigo_lote { get; set; }
        public System.DateTime fecha { get; set; }
        public string comentarios { get; set; }
        public int cantidad { get; set; }
        public int presentacion_id { get; set; }
        public int tipo_cerveza_id { get; set; }
    
        public virtual presentacion presentacion { get; set; }
        public virtual tipo_cerveza tipo_cerveza { get; set; }
    }
}
