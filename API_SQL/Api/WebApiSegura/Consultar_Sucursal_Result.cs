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
    
    public partial class Consultar_Sucursal_Result
    {
        public string ID { get; set; }
        public int Max_capacidad { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Canton { get; set; }
        public System.DateTime Fecha_apertura { get; set; }
    }
}
