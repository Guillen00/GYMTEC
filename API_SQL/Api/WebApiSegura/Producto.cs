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
    
    public partial class Producto
    {
        public string Bar_code { get; set; }
        public string ID_servicio { get; set; }
        public string Nombre { get; set; }
        public int Costo { get; set; }
        public string Descripcion { get; set; }
    }
}
