using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*En este archivo .cs se manejaran todas las clases a utilizar para el manejo de datos, sea en tablas o para la creacion de JSON, tambien para manejar datos que
 * son necesarios para los reportes y diferentes funcionalidades
 * 
 * 
 */
namespace Proyecto2.DataRequest
{

    public class Maquina_Tipo
    {
    public string Serie { get; set; }
    public string ID { get; set; }
    }

    public class Empleado_Admin
    {
        public int Cedula { get; set; }
        public string ID_sucursal { get; set; }
    }

    public class Sucursal_Completa
    {
        public string ID { get; set; }
        public int Max_capacidad { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Canton { get; set; }
        public System.DateTime Fecha_apertura { get; set; }
        public int Numero { get; set; }
        public string Spa { get; set; }
        public string Tienda { get; set; }
        public int Administrador { get; set; }
    }

    public class EmpleadoCompleto
    {
        public int Cedula { get; set; }
        public string Correo { get; set; }
        public int Salario { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Canton { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Password { get; set; }
        public string ID_Puesto { get; set; }
        public string ID_sucursal { get; set; }
        public string ID { get; set; }

    }



        /*
         * Esta clase maneja la informacion de todos los dispositivos, se puede almacenar temporalmente y transportar la informacion
         */


    }