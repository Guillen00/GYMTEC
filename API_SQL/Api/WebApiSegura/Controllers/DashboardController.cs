using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Proyecto2.DataRequest;

namespace Proyecto2.Controllers
{
    /// <summary>
    /// admin controller class for testing security token with role admin
    /// </summary>
    /// 

    [AllowAnonymous]
    [RoutePrefix("api/Dashboard")]
        /*
         * En este archivo se manejaran los datos de promedios, regionales, correo y pdf
         */
    public class DashboardController : ApiController
    {
        
        //Devuelve cantidad de dispositvos gestionados, el nuemro de dispositvios promedio por usuario,el numero de dispositivos ubicados por continente y una lsita de todos los 
        //dispositivos en el sistema
        [HttpGet]
        [Route("All")]
        public IHttpActionResult DispositivosGestionados()
        {
           
            return Ok("GG");
        }
        

    }
}
