using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using System.IO;
using System.Linq;
//using EntityFramework.Extension;


namespace Proyecto2.DataRequest
{
    /*
     * En esta clase se conectara con la base de datos en postgresql con todas las peticiones especificas para las tablas de la base 
     */
    public static class BDConection {
        
        
        public static GymTECEntities con = new GymTECEntities();
        
        //-------------------------------------------------------------------------------Empleado---------------------------------------------------------------
        public static List<Empleado> lista_empleados() {

            List<Empleado> lista = con.Empleado.ToList<Empleado>();
            
            return lista;
        }

        public static void agregar_empleado(Empleado emp)
        {
            
            con.Empleado.Add(emp);

            con.SaveChanges();
        }
        public static void borrar_empleado(Empleado emp)
        {
            
            var customer = con.Empleado.Single(o => o.Cedula == emp.Cedula);
            con.Empleado.Remove(customer);
            con.SaveChanges();
        }
        public static Empleado login_empleado(Empleado emp)
        {
            var customer = con.Empleado.Single(o => o.Cedula == emp.Cedula);
            

            Empleado empleado = con.Empleado.Find(customer.Cedula);

            con.SaveChanges();
            return empleado;
        }

        public static Empleado editar_empleado(Empleado emp)
        {
            var customer = con.Empleado.Single(o => o.Cedula == emp.Cedula);

            
            Empleado empleado = con.Empleado.Find(customer.Cedula);
            
            if (emp.Apellido1 != "") { empleado.Apellido1 = emp.Apellido1; }
            
            if (emp.Apellido2 != "") { empleado.Apellido2 = emp.Apellido2; }
            
            if (emp.Canton != "") { empleado.Canton = emp.Canton; }
            
            if (emp.Correo != "") { empleado.Correo = emp.Correo; }
            
            if (emp.Distrito != "") { empleado.Distrito = emp.Distrito; }
            
            if (emp.Nombre != "") { empleado.Nombre = emp.Nombre; }
            
            if (emp.Password != "") { empleado.Password = emp.Password; }
            
            if (emp.Provincia != "") { empleado.Provincia = emp.Provincia; }
            
            if (emp.Salario != 0) { empleado.Salario = emp.Salario; }
            
            
            con.SaveChanges();
            return empleado;
        }
    }
}