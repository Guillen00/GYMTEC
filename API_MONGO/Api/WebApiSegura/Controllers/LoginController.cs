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
        [HttpPost]
        [Route("Registrar")]
        public IHttpActionResult Registrar(Cliente nuevo)
        {
            Proyecto2.DataRequest.BD_Mongo_Conection.MongoDataService();

            try
            {
                Proyecto2.DataRequest.BD_Mongo_Conection.Insertar(nuevo);
            }
            catch {
                return Ok("Usuario no Registrado");
            }
            return Ok("Usuario Registrado");
        }
        [HttpGet]
        [Route("ConsultarTodos")]
        public IHttpActionResult Consultar_todos()
        {
            Proyecto2.DataRequest.BD_Mongo_Conection.MongoDataService();

            Proyecto2.DataRequest.BD_Mongo_Conection.Consultar_todos();
            return Ok(Proyecto2.DataRequest.BD_Mongo_Conection.Consultar_todos());
            
        }

        [HttpPost]
        [Route("Consultar_Correo")]
        public IHttpActionResult Consultar_correo(Cliente nuevo)
        {
            Proyecto2.DataRequest.BD_Mongo_Conection.MongoDataService();

            
            return Ok(Proyecto2.DataRequest.BD_Mongo_Conection.Consultar_correo(nuevo));

        }

        [HttpPost]
        [Route("Borrar")]
        public IHttpActionResult Borrar(Cliente nuevo)
        {
            Proyecto2.DataRequest.BD_Mongo_Conection.MongoDataService();

            
            Proyecto2.DataRequest.BD_Mongo_Conection.Borrar(nuevo);
            
            return Ok("Usuario ha sido borrado");
        }

        [HttpPost]
        [Route("Editar")]
        public IHttpActionResult Editar(Cliente nuevo)
        {
            Proyecto2.DataRequest.BD_Mongo_Conection.MongoDataService();


            Proyecto2.DataRequest.BD_Mongo_Conection.Editar(nuevo);

            return Ok("Usuario ha sido editado");
        }

    }

}