using System.Web.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;
using Proyecto2.DataRequest;
using System;
using System.Data.Entity;
using Proyecto1;

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
            try {
            Proyecto2.DataRequest.BDConection.agregar_sucursal(suc);
            
            }
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
           try {
           Proyecto2.DataRequest.BDConection.agregar_tratamiento(tra);  }
           catch { return Ok("El tratamiento no se ha agregado"); }

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
        //---------------------------------------------------------------------------Productos------------------------------------------------------
        [HttpPost]
        [Route("AgregarProducto")]
        public IHttpActionResult AgregarProducto(Producto pro)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_producto(pro);
            }
            catch
            {
                return Ok("Producto no agregado");
            }

            return Ok("Producto agregado");
        }

        [HttpPost]
        [Route("BorrarProducto")]
        public IHttpActionResult BorrarProducto(Producto pro)
        {

            try
            {
                Proyecto2.DataRequest.BDConection.borrar_producto(pro);
            }
            catch
            {
                return Ok("Producto no borrado");
            }

            return Ok("Producto borrado");
        }

        [HttpPost]
        [Route("EditarProducto")]
        public IHttpActionResult EditarProducto(Producto pro)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.editar_producto(pro);
            }
            catch
            {
                return Ok("Producto no editado");
            }

            return Ok("Producto editado");
        }

        [HttpPost]
        [Route("ConsultarProducto")]
        public IHttpActionResult ConsultarProducto(Producto pro)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.consultar_producto(pro);
            }
            catch
            {
                return Ok("Producto encontrado");
            }

            return Ok(Proyecto2.DataRequest.BDConection.consultar_producto(pro));
        }
        //-------------------------------------------------------------------------Rol-------------------------------------------------------------

        [HttpPost]
        [Route("AgregarRol")]
        public IHttpActionResult AgregarRol(Rol rol)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_Rol(rol);
            }
            catch
            {
                return Ok("Rol no agregado");
            }

            return Ok("Rol agregado");
        }

        [HttpPost]
        [Route("BorrarRol")]
        public IHttpActionResult BorrarRol(Rol rol)
        {

            try
            {
                Proyecto2.DataRequest.BDConection.borrar_Rol(rol);
            }
            catch
            {
                return Ok("Rol no borrado");
            }

            return Ok("Rol borrado");
        }

        //---------------------------------------------------------------------Numero Sucursal-----------------------------------------------------------
        [HttpPost]
        [Route("AgregarNumero_Sucursal")]
        public IHttpActionResult AgregarNumero_Sucursal(Numeros_sucursal num)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_numero_sucursal(num);
            }
            catch
            {
                return Ok("Numero de Sucursal no agregado");
            }

            return Ok("Numero de Sucursal agregado");
        }

        [HttpPost]
        [Route("BorrarNumero_Sucursal")]
        public IHttpActionResult BorrarNumero_Sucursal(Numeros_sucursal num)
        {

            try
            {
                Proyecto2.DataRequest.BDConection.borrar_numero_sucursal(num);
            }
            catch
            {
                return Ok("Numero de Sucursal no borrado");
            }

            return Ok("Numero de Sucursal borrado");
        }

        //-----------------------------------------------------------------Tipo_Planilla_Empleado-----------------------------------------------------
        [HttpPost]
        [Route("AgregarTipo_Planilla_Empleado")]
        public IHttpActionResult AgregarTipo_Planilla_Empleado(Tipos_planillas_empleados tip)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_TPE(tip);
            }
            catch
            {
                return Ok("Tipo de Planilla relacionada a un empleado no se ha agregado");
            }

            return Ok("Tipo de Planilla relacionada a un empleado agregado");
        }

        [HttpPost]
        [Route("BorrarTipo_Planilla_Empleado")]
        public IHttpActionResult BorrarTipo_Planilla_Empleado(Tipos_planillas_empleados tip)
        {

            try
            {
                Proyecto2.DataRequest.BDConection.borrar_TPE(tip);
            }
            catch
            {
                return Ok("Tipo de Planilla relacionada a un empleado no borrado");
            }

            return Ok("Tipo de Planilla relacionada a un empleado borrado");
        }

        [HttpPost]
        [Route("EditarTipo_Planilla_Empleado")]
        public IHttpActionResult EditarTipo_Planilla_Empleado(Tipos_planillas_empleados tip)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.editar_TPE(tip);
            }
            catch
            {
                return Ok("Tipo de Planilla relacionada a un empleado no editado");
            }

            return Ok("Tipo de Planilla relacionada a un empleado editado");
        }

        //-------------------------------------------------------------------------Activo---------------------------------------------------------------
        [HttpPost]
        [Route("AgregarActivo")]
        public IHttpActionResult AgregarActivo(Activo act)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_activo(act);
            }
            catch
            {
                return Ok("Activo no agregado");
            }

            return Ok("Activo agregado");
        }

        

        [HttpPost]
        [Route("EditarActivo")]
        public IHttpActionResult EditarActivo(Activo act)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.editar_activo(act);
            }
            catch
            {
                return Ok("Activo no editado");
            }

            return Ok("Activo editado");
        }

        [HttpPost]
        [Route("ConsultarActivo")]
        public IHttpActionResult ConsultarActivo(Activo act)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.consultar_Activo(act);
            }
            catch
            {
                return Ok("Activo encontrado");
            }

            return Ok(Proyecto2.DataRequest.BDConection.consultar_Activo(act));
        }

        //------------------------------------------------------------------------Clase------------------------------------------------------
        [HttpPost]
        [Route("AgregarClase")]
        public IHttpActionResult AgregarClase(Clase cla)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_Clase(cla);
            }
            catch
            {
                return Ok("Clase no agregada");
            }

            return Ok("Clase agregada");
        }

        [HttpPost]
        [Route("BorrarClase")]
        public IHttpActionResult BorrarClase(Clase cla)
        {

            try
            {
                Proyecto2.DataRequest.BDConection.borrar__Clase(cla);
            }
            catch
            {
                return Ok("Clase no borrada");
            }

            return Ok("Clase borrada");
        }

        [HttpPost]
        [Route("EditarClase")]
        public IHttpActionResult EditarClase(Clase cla)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.editar__Clase(cla);
            }
            catch
            {
                return Ok("Clase no editada");
            }

            return Ok("Clase editada");
        }

        [HttpPost]
        [Route("ConsultarClase")]
        public IHttpActionResult ConsultarClase(Clase cla)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.consultar__Clase(cla);
            }
            catch
            {
                return Ok("Clase encontrada");
            }

            return Ok(Proyecto2.DataRequest.BDConection.consultar__Clase(cla));
        }

        //--------------------------------------------------------------------------------Clase_Cliente------------------------------------------------------
        [HttpPost]
        [Route("AgregarClase_Cliente")]
        public IHttpActionResult AgregarClase_Cliente(Consultar_Clase_Cliente_Result cla)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_Clase_Cliente(cla);
            }
            catch
            {
                return Ok("Clase Cliente no agregada");
            }

            return Ok("Clase Cliente agregada");
        }

        [HttpPost]
        [Route("BorrarClase_Cliente")]
        public IHttpActionResult BorrarClase_Cliente(Consultar_Clase_Cliente_Result cla)
        {

            try
            {
                Proyecto2.DataRequest.BDConection.borrar__Clase_Cliente(cla);
            }
            catch
            {
                return Ok("Clase Cliente no borrada");
            }

            return Ok("Clase Cliente borrada");
        }


        [HttpPost]
        [Route("ConsultarClase_Cliente")]
        public IHttpActionResult ConsultarClase_Cliente(Consultar_Clase_Cliente_Result cla)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.consultar_Clase_Cliente(cla);
            }
            catch
            {
                return Ok("Clase Cliente no encontrada");
            }

            return Ok(Proyecto2.DataRequest.BDConection.consultar_Clase_Cliente(cla));
        }

        //-----------------------------------------------------------------------Cliente------------------------------------------------------------------
        [HttpPost]
        [Route("AgregarCliente")]
        public IHttpActionResult AgregarCliente(Cliente cli)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_Cliente(cli);
            }
            catch
            {
                return Ok("Cliente no agregado");
            }

            return Ok("Cliente agregado");
        }

        [HttpPost]
        [Route("BorrarCliente")]
        public IHttpActionResult BorrarCliente(Cliente cli)
        {

            try
            {
                Proyecto2.DataRequest.BDConection.borrar__Cliente(cli);
            }
            catch
            {
                return Ok("Cliente no borrado");
            }

            return Ok("Cliente borrado");
        }


        [HttpGet]
        [Route("ConsultarCliente")]
        public IHttpActionResult ConsultarCliente()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.lista_Cliente();
            }
            catch
            {
                return Ok("Cliente no encontrados");
            }

            return Ok(Proyecto2.DataRequest.BDConection.lista_Cliente());
        }

        //---------------------------------------------------------------------------Empleado_Admin----------------------------------------------

        [HttpPost]
        [Route("AgregarEmpleado_Admin")]
        public IHttpActionResult AgregarEmpleado_Admin(Empleado_Admin emp)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_Empleado_Admin(emp);
            }
            catch
            {
                return Ok("Empleado_Admin no agregado");
            }

            return Ok("Empleado_Admin agregado");
        }

        [HttpPost]
        [Route("BorrarEmpleado_Admin")]
        public IHttpActionResult BorrarEmpleado_Admin(Empleado_Admin emp)
        {

            try
            {
                Proyecto2.DataRequest.BDConection.borrar__Empleado_Admin(emp);
            }
            catch
            {
                return Ok("Empleado_Admin no borrado");
            }

            return Ok("Empleado_Admin borrado");
        }


        [HttpPost]
        [Route("ConsultarEmpleado_Admin")]
        public IHttpActionResult ConsultarEmpleado_Admin(Consultar_Empleado_Admin_Result emp)
        {
            //try{
                Proyecto2.DataRequest.BDConection.consultar_Empleado_Admin(emp);
            //}catch{
                //return Ok("Empleado_Admin no encontrados");
            //}

            return Ok(Proyecto2.DataRequest.BDConection.consultar_Empleado_Admin(emp));
        }

        //---------------------------------------------------------------------Maquina Tipo-------------------------------------------------------------
        [HttpPost]
        [Route("AgregarMaquina_Tipo")]
        public IHttpActionResult AgregarMaquina_Tipo(Maquina_Tipo tip)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_Maquina_Tipo(tip);
            }
            catch
            {
                return Ok("Maquina Tipo agregado");
            }

            return Ok("Maquina Tipo agregado");
        }

        [HttpPost]
        [Route("BorrarMaquina_Tipo")]
        public IHttpActionResult BorrarMaquina_Tipo(Maquina_Tipo tip)
        {

            try
            {
                Proyecto2.DataRequest.BDConection.borrar__Maquina_Tipo(tip);
            }
            catch
            {
                return Ok("Maquina Tipo no borrado");
            }

            return Ok("Maquina Tipo borrado");
        }

        [HttpPost]
        [Route("EditarMaquina_Tipo")]
        public IHttpActionResult EditarMaquina_Tipo(Maquina_Tipo tip)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.editar__Maquina_Tipo(tip);
            }
            catch
            {
                return Ok("Maquina Tipo no editado");
            }

            return Ok("Maquina Tipo editado");
        }

        //-----------------------------------------------------------------------------Puesto_Empleado------------------------------------------------
        [HttpPost]
        [Route("AgregarPuesto_Empleado")]
        public IHttpActionResult AgregarPuesto_Empleado(Consultar_Puestos_empleados_Result pue)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_Puestos_Empleados(pue);
            }
            catch
            {
                return Ok("Puesto Empleado no agregado");
            }

            return Ok("Puesto Empleado agregado");
        }

        [HttpPost]
        [Route("BorrarPuesto_Empleado")]
        public IHttpActionResult BorrarPuesto_Empleado(Consultar_Puestos_empleados_Result pue)
        {

            try
            {
                Proyecto2.DataRequest.BDConection.borrar__Puestos_Empleados(pue);
            }
            catch
            {
                return Ok("Puesto Empleado no borrado");
            }

            return Ok("Puesto Empleado borrado");
        }

        [HttpPost]
        [Route("EditarPuesto_Empleado")]
        public IHttpActionResult EditarPuesto_Empleado(Consultar_Puestos_empleados_Result pue)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.editar__Puestos_Empleados(pue);
            }
            catch
            {
                return Ok("Puesto Empleado no editado");
            }

            return Ok("Puesto Empleado editado");
        }

        [HttpPost]
        [Route("ConsultarPuesto_Empleado")]
        public IHttpActionResult ConsultarPuesto_Empleado(Consultar_Puestos_empleados_Result pue)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.consultar__Puestos_Empleados(pue);
            }
            catch
            {
                return Ok("Puesto Empleado encontrado");
            }

            return Ok(Proyecto2.DataRequest.BDConection.consultar__Puestos_Empleados(pue));
        }


        //-------------------------------------------------------------------------Roles_Empleado----------------------------------------------------
        [HttpPost]
        [Route("AgregarRoles_Empleado")]
        public IHttpActionResult AgregarRoles_Empleado(Consultar_Roles_empleados_Result rol)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.agregar_Roles_Empleados(rol);
            }
            catch
            {
                return Ok("Rol Empleado no agregado");
            }

            return Ok("Rol Empleado agregado");
        }

        [HttpPost]
        [Route("BorrarRoles_Empleado")]
        public IHttpActionResult BorrarRoles_Empleado(Consultar_Roles_empleados_Result rol)
        {

            try
            {
                Proyecto2.DataRequest.BDConection.borrar__Roles_Empleados(rol);
            }
            catch
            {
                return Ok("Rol Empleado no borrado");
            }

            return Ok("Rol Empleado borrado");
        }

        [HttpPost]
        [Route("EditarRoles_Empleado")]
        public IHttpActionResult EditarRoles_Empleado(Consultar_Roles_empleados_Result rol)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.editar__Roles_Empleados(rol);
            }
            catch
            {
                return Ok("Rol Empleado no editado");
            }

            return Ok("Rol Empleado editado");
        }

        [HttpPost]
        [Route("ConsultarRoles_Empleado")]
        public IHttpActionResult ConsultarRoles_Empleado(Consultar_Roles_empleados_Result rol)
        {
            try
            {
                Proyecto2.DataRequest.BDConection.consultar__Roles_Empleados(rol);
            }
            catch
            {
                return Ok("Rol Empleado encontrado");
            }

            return Ok(Proyecto2.DataRequest.BDConection.consultar__Roles_Empleados(rol));
        }


        //-----------------------------------------------------------------------------Planilla----------------------------
        [HttpGet]
        [Route("Generar_Planilla")]
        public IHttpActionResult Generar_Planilla()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.Planilla();
            }
            catch
            {
                return Ok("Error al generar Planilla");
            }

            return Ok(Proyecto2.DataRequest.BDConection.Planilla());
        }

        //----------------------------------------------------------------------------Vistas--------
        [HttpGet]
        [Route("Vista1")]
        public IHttpActionResult Vista1()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.MaquinaTipo();
            }
            catch
            {
                return Ok("Error al generar Maquina Tipo");
            }

            return Ok(Proyecto2.DataRequest.BDConection.MaquinaTipo());
        }

        [HttpGet]
        [Route("Vista2")]
        public IHttpActionResult Vista2()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.ClaseCliente();
            }
            catch
            {
                return Ok("Error al generar Clase Cliente");
            }

            return Ok(Proyecto2.DataRequest.BDConection.ClaseCliente());
        }

        //---------------------------------------------------------------------------GET ALL----------------------------------------------------
        [HttpGet]
        [Route("All_Sucursal")]
        public IHttpActionResult All_Sucursal()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.ALL_Sucursal();
            }
            catch
            {
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.ALL_Sucursal());
        }

        [HttpGet]
        [Route("All_Clase")]
        public IHttpActionResult All_Clase()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.ALL_Clases();
            }
            catch
            {
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.ALL_Clases());
        }
        [HttpGet]
        [Route("All_Empleados")]
        public IHttpActionResult All_Empleado()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.ALL_Empleados();
            }
            catch
            {
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.ALL_Empleados());
        }
        [HttpGet]
        [Route("All_Maquinas")]
        public IHttpActionResult All_Maquinas()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.ALL_Maquinas();
            }
            catch
            {
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.ALL_Maquinas());
        }
        [HttpGet]
        [Route("All_Productos")]
        public IHttpActionResult All_Productos()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.ALL_Productos();
            }
            catch
            {
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.ALL_Productos());
        }
        [HttpGet]
        [Route("All_Puestos")]
        public IHttpActionResult All_Puestos()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.ALL_Puestos();
            }
            catch
            {
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.ALL_Puestos());
        }
        [HttpGet]
        [Route("All_Servicios")]
        public IHttpActionResult All_Servicios()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.ALL_Servicios();
            }
            catch
            {
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.ALL_Servicios());
        }
        [HttpGet]
        [Route("All_Tipo_Equipo")]
        public IHttpActionResult All_Tipo_Equipo()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.ALL_Tipo_Equipo();
            }
            catch
            {
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.ALL_Tipo_Equipo());
        }
        [HttpGet]
        [Route("All_Tipo_Planilla")]
        public IHttpActionResult All_Tipo_Planilla()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.ALL_Tipo_Planilla();
            }
            catch
            {
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.ALL_Tipo_Planilla());
        }
        [HttpGet]
        [Route("All_Tratamientos")]
        public IHttpActionResult All_Tratamientos()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.ALL_Tratamiento();
            }
            catch
            {
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.ALL_Tratamiento());
        }

        //-----------------------------------------------------------------------------Extras------------------------------------------------------

        [HttpPost]
        [Route("AgregarSucursalCompleta")]
        public IHttpActionResult AgregarSucursalCompleta(Sucursal_Completa suc)
        {
            try{
                Sucursal sucursal = new Sucursal();
                Activo activo = new Activo();
                Numeros_sucursal num = new Numeros_sucursal();
                sucursal.ID = suc.ID;
                sucursal.Max_capacidad = suc.Max_capacidad;
                sucursal.Nombre = suc.Nombre;
                sucursal.Provincia = suc.Provincia;
                sucursal.Canton = suc.Canton;
                sucursal.Distrito = suc.Distrito;
                sucursal.Fecha_apertura = suc.Fecha_apertura;
                Proyecto2.DataRequest.BDConection.agregar_sucursal(sucursal);

                //Empleado_Admin empad = new Empleado_Admin();
                //empad.Cedula = Int32.Parse(suc.EmpleadoAdmin);
                //Proyecto2.DataRequest.BDConection.agregar_Empleado_Admin();

                activo.ID = suc.ID;
                activo.Spa = "F";
                activo.Tienda = "F";
                Proyecto2.DataRequest.BDConection.editar_activo(activo);

                num.ID_sucursal = suc.ID;
                num.Numero = suc.Numero;
                Proyecto2.DataRequest.BDConection.agregar_numero_sucursal(num);

            }catch { return Ok("La sucursal no ha sido agregada"); }

            return Ok("La sucursal se ha agregado exitosamente");
        }

        [HttpPost]
        [Route("ConsultaEmpeadoCompleto")]
        public IHttpActionResult ConsultaEmpeadoCompleto(Sucursal_Completa suc)
        {
            try
            {
                Sucursal sucursal = new Sucursal();
                Activo activo = new Activo();
                Numeros_sucursal num = new Numeros_sucursal();
                sucursal.ID = suc.ID;
                sucursal.Max_capacidad = suc.Max_capacidad;
                sucursal.Nombre = suc.Nombre;
                sucursal.Provincia = suc.Provincia;
                sucursal.Canton = suc.Canton;
                sucursal.Distrito = suc.Distrito;
                sucursal.Fecha_apertura = suc.Fecha_apertura;
                Proyecto2.DataRequest.BDConection.agregar_sucursal(sucursal);

                activo.ID = suc.ID;
                activo.Spa = suc.Spa;
                activo.Tienda = suc.Tienda;
                Proyecto2.DataRequest.BDConection.editar_activo(activo);

                num.ID_sucursal = suc.ID;
                num.Numero = suc.Numero;
                Proyecto2.DataRequest.BDConection.agregar_numero_sucursal(num);

            }
            catch { return Ok("La sucursal no ha sido agregada"); }

            return Ok("La sucursal se ha agregado exitosamente");
        }

        [HttpGet]
        [Route("All_Empleados_Total")]
        public IHttpActionResult All_Empleados_Total()
        {
            try{
                Proyecto2.DataRequest.BDConection.ALL_Empleado_Total();
            }catch{
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.ALL_Empleado_Total());
        }
    }
}
