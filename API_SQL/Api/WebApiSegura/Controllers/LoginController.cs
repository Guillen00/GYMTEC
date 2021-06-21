using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Collections.Generic;
using Proyecto2.DataRequest;
using System.Data;
using EasyEncryption;
using Proyecto1;

namespace Proyecto2.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
        /*
         * Este archivo tendra el contro de todo lo relacionado con el login,peticiones de GET y POST necesarios para emplear la funcionalidad del login 
         */
    public class LoginController : ApiController
    {
        
        /*
         * Esta funcion de encarga de retornan todos los empleados registrados
         */
        [HttpGet]
        [Route("lista_Empleados")]
        public IHttpActionResult Lista_Empleados()
        {
            

            return Ok(Proyecto2.DataRequest.BDConection.lista_empleados());
        }

        /*
         * Este post agrega un nuevo empleado ,llamando a la funcion en command.cs
         */
        [HttpPost]
        [Route("Agregar_Empleados")]
        public IHttpActionResult Agregar_Empleado(Empleado emp)
        {
            emp.Password = EasyEncryption.MD5.ComputeMD5Hash(emp.Password);
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_empleado(emp);
            }
            catch { return Ok("Empleado No se pudo agregar"); }


            return Ok("Empleado Agregado");
            
        }
        /*
         * Este post elimina un  empleado ,llamando a la funcion en command.cs con la cedula del empleado
         */
        [HttpPost]
        [Route("Borrar_Empleado")]
        public IHttpActionResult Borrar_Empleado(Empleado emp)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.borrar_empleado(emp);
            }
            catch { return Ok("Empleado No encontrado"); }

            return Ok("Empleado Borrado");
        }
        /*
         * Este post comprueba la existencia de un empleado ,llamando a la funcion en command.cs login, verificando que si existe y que su password es correcta
         */
        [HttpPost]
        [Route("Login_Empleados")]
        public IHttpActionResult Login_Empleado(Empleado emp)
        {
            Empleado revisar = new Empleado();
            try{
                revisar = Proyecto2.DataRequest.BDConection.login_empleado(emp);
            }
            catch { return Ok("Empleado No encontrado"); }


           
           if (EasyEncryption.MD5.ComputeMD5Hash(emp.Password) == revisar.Password) {
                
                return Ok(revisar.Rol);
            }

            return Ok("Password incorrecta");
        }
        /*
         * Este post edita un empleado ,llamando a la funcion en command.cs relacionado a un numero de cedula unico
         */
        [HttpPost]
        [Route("Editar_Empleados")]
        public IHttpActionResult Editar_Empleado(Empleado emp)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.editar_empleado(emp);
            }
            catch { return Ok("Empleado No encontrado"); }

            return Ok("Empleado Actualizado");
            
        }

        /*
         * Este post consulta un  empleado ,llamando a la funcion en command.cs relaconado a un numero de cedula unico
         */
        [HttpPost]
        [Route("Consultar_Empleado")]
        public IHttpActionResult Consultar_Empleado(Empleado emp)
        {
            Empleado nuevo = new Empleado();
            try
            {
                nuevo = Proyecto2.DataRequest.BDConection.login_empleado(emp);
            }
            catch { return Ok("Empleado No encontrado"); }

            return Ok(nuevo);

        }
    }

}