using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Collections.Generic;
using Proyecto2.DataRequest;
using System.Data;

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
        
        //Verifica si el usuario ingresado, correo y Contraseña coinciden con alguno guardado en la base de datos 
        [HttpGet]
        [Route("lista_Empleados")]
        public IHttpActionResult Verificar()
        {
            

            return Ok(Proyecto2.DataRequest.BDConection.lista_empleados());
        }
        [HttpPost]
        [Route("Agregar_Empleados")]
        public IHttpActionResult Agregar(Empleado emp)
        {
            Proyecto2.DataRequest.BDConection.agregar_empleado(emp);

            return Ok("Empleado Agregado");
        }
    }

}