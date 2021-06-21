//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

/*
 * Esta clase contiene los atributos necesarios para el manejo de la informacion sobre esta entidad, ademas contiene relaciones entre tablas , las cuales 
 * seran utiles en los get generales donde muestra todas las conexiones de la entidad y ademas para no incumplir las restricciones creadas por las tablas
 * en sql server
 */
namespace Proyecto1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clase()
        {
            this.Cliente = new HashSet<Cliente>();
        }
    
        public string ID { get; set; }
        public string ID_sucursal { get; set; }
        public string Tipo { get; set; }
        public string Modalidad { get; set; }
        public int Instructor { get; set; }
        public System.TimeSpan Hora_inicio { get; set; }
        public System.TimeSpan Hora_fin { get; set; }
        public System.DateTime Fecha { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
