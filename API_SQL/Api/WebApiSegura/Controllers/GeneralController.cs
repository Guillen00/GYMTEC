using System.Web.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;
using Proyecto2.DataRequest;
using System;

namespace Proyecto2.Controllers
{
    /// <summary>
    /// customer controller class for testing security token 
    /// </summary>

    [AllowAnonymous]
    //[Authorize]
    [RoutePrefix("api/general")]
    public class GeneralController : ApiController
    {
        //-------------------------------------------------Dispositivo-----------------------------------------
        // Agrega un nuevo dispositivo a la base de datos revisando que no se repita el numero de serie 
        [HttpPost]
        [Route("AgregarDispositivo")]
        public IHttpActionResult Agregar(Dispositivo disp)
        {
            
            return Ok("El dispositivo se ha agregado exitosamente");
        }

        
        ///----------------------------------------------------------Tienda en linea-----------------------------------
        
    }
}
