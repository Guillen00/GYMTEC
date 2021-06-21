using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Collections.Generic;
using Proyecto2.DataRequest;
using System.Data;
using EasyEncryption;
using System.Security.Cryptography;
using System.Text.Encodings;
namespace Proyecto2.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
        /*
         * Este archivo tendra el contro de todo lo relacionado con el login,peticiones de GET y POST necesarios para emplear la funcionalidad del login de los Clientes
         */
    public class LoginController : ApiController
    {
        /*
         * Este post registra un nuevo cliente a la base de datos en mongo db
         */
        [HttpPost]
        [Route("Registrar")]
        public IHttpActionResult Registrar(Cliente nuevo)
        {
            Proyecto2.DataRequest.BD_Mongo_Conection.MongoDataService();
            nuevo.Password = EasyEncryption.MD5.ComputeMD5Hash(nuevo.Password);
            try
            {
                Proyecto2.DataRequest.BD_Mongo_Conection.Insertar(nuevo);
            }
            catch {
                return Ok("Usuario no Registrado, algun dato Correo o cedula ya ha sido ingresado");
            }
            return Ok("Usuario Registrado");
        }
        /*
         * Esta peticion verifica si los datos ingresados son correctos y se relacionan con algun cliente almacenado en la base de datos
         */
        [HttpPost]
        [Route("Verificar")]
        public IHttpActionResult Verificar(Cliente nuevo)
        {
            Proyecto2.DataRequest.BD_Mongo_Conection.MongoDataService();
            nuevo.Password = EasyEncryption.MD5.ComputeMD5Hash(nuevo.Password);
            try
            {
                Proyecto2.DataRequest.BD_Mongo_Conection.Consultar_correo(nuevo);

            }
            catch
            {
                return Ok("Usuario no encontrado");
            }
            List < Cliente > datos = Proyecto2.DataRequest.BD_Mongo_Conection.Consultar_correo(nuevo);
            if (datos.Count == 0)
            {
                return Ok("El Correo no ha sido emcontrado");
            }
            else {
                if (nuevo.Password == datos[0].Password)
                {
                    return Ok("Usuario Encontrado");
                }
                else {
                    return Ok("Password incorrecta");
                }
            }

            
        }
        /*
         * Este get retorna todos los empleados, que tiene almacenados la base de datos en mongo db
         */
        [HttpGet]
        [Route("ConsultarTodos")]
        public IHttpActionResult Consultar_todos()
        {
            Proyecto2.DataRequest.BD_Mongo_Conection.MongoDataService();

            Proyecto2.DataRequest.BD_Mongo_Conection.Consultar_todos();
            return Ok(Proyecto2.DataRequest.BD_Mongo_Conection.Consultar_todos());
            
        }
        /*
         * Por medio del correo del cliente se puede pedir toda la informacion de un cliente
         */
        [HttpPost]
        [Route("Consultar_Correo")]
        public IHttpActionResult Consultar_correo(Cliente nuevo)
        {
            Proyecto2.DataRequest.BD_Mongo_Conection.MongoDataService();

            try {
                Proyecto2.DataRequest.BD_Mongo_Conection.Consultar_correo(nuevo);
                
            }
            catch {
                return Ok("Usuario no encontrado");
            }
            return Ok(Proyecto2.DataRequest.BD_Mongo_Conection.Consultar_correo(nuevo));

        }


        /*
         * Este post recibe un numero de cedula el cual utiliza par borra al cliente en la base de datos
         */
        [HttpPost]
        [Route("Borrar")]
        public IHttpActionResult Borrar(Cliente nuevo)
        {
            Proyecto2.DataRequest.BD_Mongo_Conection.MongoDataService();

            try { Proyecto2.DataRequest.BD_Mongo_Conection.Borrar(nuevo); }
            catch { return Ok("Usuario no encontrado"); }
            Proyecto2.DataRequest.BD_Mongo_Conection.Borrar(nuevo);
            
            return Ok("Usuario ha sido borrado");
        }
        /*
         * De igual manera recibe un numero de cedula, la cual utiliza como parametro fijo o llave para poder editar los demas atributos
         */
        [HttpPost]
        [Route("Editar")]
        public IHttpActionResult Editar(Cliente nuevo)
        {
            Proyecto2.DataRequest.BD_Mongo_Conection.MongoDataService();

            try { Proyecto2.DataRequest.BD_Mongo_Conection.Editar(nuevo); }
            catch { return Ok("Usuario no encontrado"); }
            

            return Ok("Usuario ha sido editado");
        }

    }

}