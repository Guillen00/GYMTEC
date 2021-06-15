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
    /*
     * Esta clase maneja la informacion de todos los dispositivos, se puede almacenar temporalmente y transportar la informacion
     */


}