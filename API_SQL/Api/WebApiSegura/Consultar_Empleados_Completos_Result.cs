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
    
    public partial class Consultar_Empleados_Completos_Result
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Canton { get; set; }
        public Nullable<int> Cedula { get; set; }
        public string Correo { get; set; }
        public string Distrito { get; set; }
        public string Password { get; set; }
        public string Provincia { get; set; }
        public Nullable<int> Salario { get; set; }
        public string ID_puesto { get; set; }
        public string ID_tipo_planilla { get; set; }
    }
}
