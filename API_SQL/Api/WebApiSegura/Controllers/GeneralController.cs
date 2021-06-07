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
        //---------------------------------------------------------------------------Sucursal-----------------------------------------------------
        [HttpPost]
        [Route("AgregarSucursal")]
        public IHttpActionResult AgregarSucursal(Sucursal suc)
        {
            try { Proyecto2.DataRequest.BDConection.agregar_sucursal(suc); }
            catch { return Ok("La sucursal no ha sido agregada"); }
            
            return Ok("La sucursal se ha agregado exitosamente");
        }
        [HttpPost]
        [Route("EditarSucursal")]
        public IHttpActionResult EditarSucursal(Sucursal suc)
        {
            try { Proyecto2.DataRequest.BDConection.editar_sucursal(suc); }
            catch { return Ok("La sucursal no ha sido Editada"); }

            return Ok("La sucursal se ha editado exitosamente");
        }
        [HttpPost]
        [Route("BorrarSucursal")]
        public IHttpActionResult BorrarSucursal(Sucursal suc)
        {
            try { Proyecto2.DataRequest.BDConection.borrar_sucursal(suc); }
            catch { return Ok("La sucursal no ha sido Borrada"); }

            return Ok("La sucursal se ha Borrada exitosamente");
        }
        [HttpPost]
        [Route("ConsultarSucursal")]
        public IHttpActionResult ConsultarSucursal(Sucursal suc)
        {
            try { Proyecto2.DataRequest.BDConection.Consulta_sucursal(suc); }
            catch { return Ok("La sucursal no se ha encontrado"); }

            return Ok(Proyecto2.DataRequest.BDConection.Consulta_sucursal(suc));
        }

        //----------------------------------------------------------------------Tratamiento-----------------------------------------------------------

        [HttpPost]
        [Route("AgregarTratamiento")]
        public IHttpActionResult AgregarTratamiento(Tratamiento tra)
        {
           //try {
           Proyecto2.DataRequest.BDConection.agregar_tratamiento(tra); // }
           //catch { return Ok("El tratamiento no se ha agregado"); }

            return Ok("El tratamiento se ha agregado exitosamente");
        }
        [HttpPost]
        [Route("EditarTratamiento")]
        public IHttpActionResult EditarTratamiento(Tratamiento tra)
        {
            try { Proyecto2.DataRequest.BDConection.editar_tratamiento(tra); }
            catch { return Ok("El tratamiento no se ha editado"); }

            return Ok("El tratamiento se ha editado exitosamente");
        }
        [HttpPost]
        [Route("BorrarTratamiento")]
        public IHttpActionResult BorrarTratamiento(Tratamiento tra)
        {

            try { Proyecto2.DataRequest.BDConection.borrar_tratamiento(tra); }
            catch { return Ok("El tratamiento no se ha encontrado"); }

            return Ok("El tratamiento se ha Borrado exitosamente");
        }
        [HttpPost]
        [Route("ConsultarTratamiento")]
        public IHttpActionResult ConsultarTratamiento(Tratamiento tra)
        {

            try { Proyecto2.DataRequest.BDConection.Consulta_tratamiento(tra); }
            catch { return Ok("El tratamiento no se ha encontrado"); }

            return Ok(Proyecto2.DataRequest.BDConection.Consulta_tratamiento(tra));
        }

        //--------------------------------------------------------------------Puesto------------------------------------------------------------------

        [HttpPost]
        [Route("AgregarPuesto")]
        public IHttpActionResult AgregarPuesto(Puesto pue)
        {
            try { Proyecto2.DataRequest.BDConection.agregar_Puesto(pue); }
            catch { return Ok("El Puesto no se ha agregado"); }

            return Ok("El Puesto se ha Agregado exitosamente");
        }
        [HttpPost]
        [Route("EditarPuesto")]
        public IHttpActionResult EditarPuesto(Puesto pue)
        {
            try { Proyecto2.DataRequest.BDConection.editar_Puesto(pue); }
            catch { return Ok("El Puesto no se ha editado"); }

            return Ok("El Puesto se ha Actualizado exitosamente");
        }
        [HttpPost]
        [Route("BorrarPuesto")]
        public IHttpActionResult BorrarPuesto(Puesto pue)
        {
            try { Proyecto2.DataRequest.BDConection.borrar_Puesto(pue); }
            catch { return Ok("El Puesto no se ha Borrado"); }

            return Ok("El Puesto se ha Borrado exitosamente");
        }
        [HttpPost]
        [Route("ConsultarPuesto")]
        public IHttpActionResult ConsultarPuesto(Puesto pue)
        {
            try { Proyecto2.DataRequest.BDConection.Consulta_Puesto(pue); }
            catch { return Ok("El Puesto no se ha Encontrado"); }

            return Ok(Proyecto2.DataRequest.BDConection.Consulta_Puesto(pue));
        }

        //---------------------------------------------------------------Tipo de Plantilla------------------------------------------------------------

        [HttpPost]
        [Route("AgregarTipo_Planilla")]
        public IHttpActionResult AgregarTipo_Planilla(Tipo_planilla Tp)
        {
            try { Proyecto2.DataRequest.BDConection.agregar_Tplanilla(Tp); }
            catch { return Ok("El Tipo de Planilla no se ha agregado"); }

            return Ok("El Tipo de Planilla se ha agregado exitosamente");
        }
        [HttpPost]
        [Route("EditarTipo_Planilla")]
        public IHttpActionResult EditarTipo_Planilla(Tipo_planilla Tp)
        {
            try { Proyecto2.DataRequest.BDConection.editar_Tplanilla(Tp); }
            catch { return Ok("El Tipo de Planilla no se ha editado"); }

            return Ok("El Tipo de Planilla se ha Actualizado exitosamente");
        }
        [HttpPost]
        [Route("BorrarTipo_Planilla")]
        public IHttpActionResult BorrarTipo_Planilla(Tipo_planilla Tp)
        {
            try { Proyecto2.DataRequest.BDConection.borrar_Tplanilla(Tp); }
            catch { return Ok("El Tipo de Planilla no se ha Borrado"); }

            return Ok("El Tipo de Planilla se ha Borrado exitosamente");
        }
        [HttpPost]
        [Route("ConsultarTipo_Planilla")]
        public IHttpActionResult ConsultarTipo_Planilla(Tipo_planilla Tp)
        {
            try { Proyecto2.DataRequest.BDConection.Consulta_Tplanilla(Tp); }
            catch { return Ok("El Tipo de Planilla no se ha encontrado"); }

            return Ok(Proyecto2.DataRequest.BDConection.Consulta_Tplanilla(Tp));
        }

        //------------------------------------------------------------------Servicio------------------------------------------------------------------
        [HttpPost]
        [Route("AgregarServicio")]
        public IHttpActionResult AgregarServicio(Servicio ser)
        {
            try {
            Proyecto2.DataRequest.BDConection.agregar_Servicio(ser); }
            catch { return Ok("El Servicio no se ha agregado"); }

            return Ok("El Servicio se ha Agregado exitosamente");
        }
        [HttpPost]
        [Route("EditarServicio")]
        public IHttpActionResult EditarServicio(Servicio ser)
        {
            try { Proyecto2.DataRequest.BDConection.editar_Servicio(ser); }
            catch { return Ok("El Servicio no se ha editado"); }

            return Ok("El Servicio se ha Actualizado exitosamente");
        }
        [HttpPost]
        [Route("BorrarServicio")]
        public IHttpActionResult BorrarServicio(Servicio ser)
        {
            try { Proyecto2.DataRequest.BDConection.borrar_Servicio(ser); }
            catch { return Ok("El Servicio no se ha Borrado"); }

            return Ok("El Servicio se ha Borrado exitosamente");
        }
        [HttpPost]
        [Route("ConsultarServicio")]
        public IHttpActionResult ConsultarServicio(Servicio ser)
        {
            try { Proyecto2.DataRequest.BDConection.Consulta_Servicio(ser); }
            catch { return Ok("El Servicio no se ha encontrado"); }

            return Ok(Proyecto2.DataRequest.BDConection.Consulta_Servicio(ser));
        }

        //-------------------------------------------------------------Tipo de Equipo------------------------------------------------------------------

        [HttpPost]
        [Route("AgregarTipo_Equipo")]
        public IHttpActionResult AgregarTipo_Equipo(Tipo_equipo TE)
        {
            try {
            Proyecto2.DataRequest.BDConection.agregar_TEquipo(TE); }
            catch { return Ok("El Tipo de Equipo no se ha Agregado"); }

            return Ok("El Tipo de Equipo se ha Agregado exitosamente");
        }
        [HttpPost]
        [Route("EditarTipo_Equipo")]
        public IHttpActionResult EditarTipo_Equipo(Tipo_equipo TE)
        {
            try { Proyecto2.DataRequest.BDConection.editar_TEquipo(TE); }
            catch { return Ok("El Tipo de Equipo no se ha Editado"); }

            return Ok("El Tipo de Equipo se ha Actualizado exitosamente");
        }
        [HttpPost]
        [Route("BorrarTipo_Equipo")]
        public IHttpActionResult BorrarTipo_Equipo(Tipo_equipo TE)
        {
            try { Proyecto2.DataRequest.BDConection.borrar_TEquipo(TE); }
            catch { return Ok("El Tipo de Equipo no se ha Borrado"); }

            return Ok("El Tipo de Equipo se ha Borrado exitosamente");
        }
        [HttpPost]
        [Route("ConsultarTipo_Equipo")]
        public IHttpActionResult ConsultarTipo_Equipo(Tipo_equipo TE)
        {
            try { Proyecto2.DataRequest.BDConection.Consulta_TEquipo(TE); }
            catch { return Ok("El Tipo de Equipo no se ha Encontrado"); }

            return Ok(Proyecto2.DataRequest.BDConection.Consulta_TEquipo(TE));
        }

        //-----------------------------------------------------------------------------Maquina-------------------------------------------------------

        [HttpPost]
        [Route("AgregarMaquina")]
        public IHttpActionResult AgregarMaquina(Maquina maq)
        {
            //try {
            Proyecto2.DataRequest.BDConection.agregar_Maquina(maq); //}
            //catch { return Ok("La Maquina no se ha Agregado"); }

            return Ok("La Maquina se ha Agregado exitosamente");
        }
        [HttpPost]
        [Route("EditarMaquina")]
        public IHttpActionResult EditarMaquina(Maquina maq)
        {
            try { Proyecto2.DataRequest.BDConection.editar_Maquina(maq); }
            catch { return Ok("La Maquina no se ha Editado"); }

            return Ok("La Maquina se ha Actualizado exitosamente");
        }
        [HttpPost]
        [Route("BorrarMaquina")]
        public IHttpActionResult BorrarMaquina(Maquina maq)
        {
            try { Proyecto2.DataRequest.BDConection.borrar_Maquina(maq); }
            catch { return Ok("La Maquina no se ha Borrado"); }

            return Ok("La Maquina se ha Borrado exitosamente");
        }
        [HttpPost]
        [Route("ConsultarMaquina")]
        public IHttpActionResult ConsultarMaquina(Maquina maq)
        {
            try { Proyecto2.DataRequest.BDConection.Consulta_Maquina(maq); }
            catch { return Ok("La Maquina no se ha Encontrado"); }

            return Ok(Proyecto2.DataRequest.BDConection.Consulta_Maquina(maq));
        }
    }
}
