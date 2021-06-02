using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using System.IO;
using System.Linq;

namespace Proyecto2.DataRequest
{
    /*
     * En esta clase se conectara con la base de datos en postgresql con todas las peticiones especificas para las tablas de la base 
     */
    public static class BDConection {
        
        
        public static GymTECEntities con = new GymTECEntities();
        

        public static List<Empleado> lista_empleados() {

            List<Empleado> lista = con.Empleado.ToList<Empleado>();
            
            return lista;
        }

        public static void agregar_empleado(Empleado emp)
        { 
            con.Empleado.Add(emp);
            con.SaveChanges();
        }

        
    }
}