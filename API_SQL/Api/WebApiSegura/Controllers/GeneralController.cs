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
    /*
     * Es esta Clase GeneralController se controlaran y crearan todas las peticiones disponibles para el API donde se editaran las diferentes tablas creadas en 
     * la base de datos de SQL Server, agrupa la informacion retornante para el dominio de la pagina web la cual es la que realuza peticiones a este servicio web
     */
    [AllowAnonymous]
    //[Authorize]
    [RoutePrefix("api/general")]
    public class GeneralController : ApiController
    {
        /*
         * Para el apartado se sucursal, recibe los tipos de datos especificados en su clase, la cual tiene la funcion de agregar una sucursal nueva ,edita todos los 
         * datos de esta la cual no vayan en nulo, referenciados de su llave primaria ID, de igual forma borra y consulta de manera especifica para un solo elemento y 
         * una consuta de manera general la cual trae todas las sucursales y todos los servicios, tratamiento, productos clases relacionados a las sucursales.
         */
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

        [HttpGet]
        [Route("ConsultarSucursales")]
        public IHttpActionResult ConsultarSucursales()
        {
            try { Proyecto2.DataRequest.BDConection.lista_sucursales(); }
            catch { return Ok("La sucursal no se ha encontrado"); }

            return Ok(Proyecto2.DataRequest.BDConection.lista_sucursales());
        }

        /*
         *Para el apartado de los tatamientos, la cual se maneja el tipo de informacion y se realizan peticiones como agregar tratamientos ,editar , borra y consulta
         *personalizada dependiedo de su llave primaria Id y una consulta la cual retorna toda la informacion de los tratamientos para el manejo de la pagina web.
         *
         */
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

        /*
         * Para el apartado de puesto, se contienen las cuatro funciones basicas personalizadas, agregar, editar, borra y consultar ubicando por la llave primaria
         * con la cual es un listado de puestos, donde tiene un id y el nombre del puesto,y una consulta general donde retorna todos los puestos .
         */
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

        /*
         * En el apatado de Tipo de planilla , se agregan , borran , editan y se consulta de manera personalizada , retornando una tupla especifica,manejada por in ID 
         * el cual es su llave primaria , de igaul manera es una tabla la cual contiene un Id y una descripcion del tipo de planilla.
         */
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

        /*
         * En el siguiente apartado de servicios, se aplican las peticiones de agregar , editar, borrar ,controlado por un ID el cual es su llave primaria, y debe estar conectado
         * a una sucursal por su ID , ya que es su llave foranea , tambien una consulta personalizada por el id del servicio.
         */
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

        /*
         * En el apartado Tipo de equipo,contiene las peticiones de Agregar, editar, borra y consultar de una manera especifica identificado por el tipo de planilla
         * identificado por un id y una descripcion del tipo de equipo
         */
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

        /*
         * En el apartado Maquina, contiene las maquinas de las sucursales , con las peticiones de Agregar, editar, borrar y una consulta sobre un numero de serie 
         * retornando todos los datos de la maquina.
         */
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

        /*
         * En este apartado, de manejan los tipos de Productos, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos en command.cs
         */
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

        /*
         * En este apartado, de manejan los tipos de Rol, cuando tiene las peticiones de agregar, borrar  por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos en command.cs
         */
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

        /*
         * En este apartado, de manejan los tipos de Numeros de sucursal, cuando tiene las peticiones de agregar , borrar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos en command.cs
         */
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

        /*
         * En este apartado, de manejan los tipos de Tipo Planilla Empleado, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos en command.cs
         */
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

        /*
         * En este apartado, de manejan los tipos de Activo, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos en command.cs
         */
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

        /*
         * En este apartado, de manejan los tipos de Clase, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos en command.cs
         */

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

        /*
         * En este apartado, de manejan los tipos de Clase Cliente, cuando tiene las peticiones de agregar, borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos en command.cs
         */
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

        /*
         * En este apartado, de manejan los tipos de Cliente, cuando tiene las peticiones de agregar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos en command.cs
         */
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

        /*
         * En este apartado, de manejan los tipos de Empleado Admin, cuando tiene las peticiones de agregar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos en command.cs
         */
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
            try{
                Proyecto2.DataRequest.BDConection.consultar_Empleado_Admin(emp);
            }catch{
                return Ok("Empleado_Admin no encontrados");
            }

            return Ok(Proyecto2.DataRequest.BDConection.consultar_Empleado_Admin(emp));
        }

        /*
         * En este apartado, de manejan los tipos de Maquina Tipo, cuando tiene las peticiones de agregar, editar , borra  por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos en command.cs
         */
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
        /*
         * En este apartado, de manejan los tipos de Puesto Empleado, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos en command.cs
         */
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

        /*
         * En este apartado, de manejan los tipos de Roles Empleados, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos en command.cs
         */
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

        /*
         * En este apartado, de manejan los tipos de Plantilla, llama la funcion de generar planilla la cual como su nombre lo dice retorna una planilla conformada
         * por los empleados registrados y con el saldo a pagar por sus servicios 
         */
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
        /*
         * En este apartado, de manejan los tipos de Vistas, las cuales son funciones de select predeterminadas para visualizar informacion sobre la base de datos de
         * ciertas tablas 
         */
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
        }/*
         * En este apartado, de manejan los tipos de todas las tablas, se tiene un get el cual retorna en su totalidad todos los elementos de cada tabla
         */
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
        /*
         * Esta funcion agrega una sucursal de manera completa donde se descompone agregando la sucursal, luego edita la tabla de activo, agrega a la tabla numero de sucursal
         * su respectivo numero y por ultimo enlaza en la tabla empleado admin, la cedula de un empleado con el id de la sucursal
         */
        [HttpPost]
        [Route("AgregarSucursalCompleta")]
        public IHttpActionResult AgregarSucursalCompleta(Sucursal_Completa suc)
        {
            try{
                Sucursal sucursal = new Sucursal();
                Activo activo = new Activo();
                Numeros_sucursal num = new Numeros_sucursal();
                Empleado_Admin adm = new Empleado_Admin();
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

                adm.Cedula = suc.Administrador;
                adm.ID_sucursal = suc.ID;
                Proyecto2.DataRequest.BDConection.agregar_Empleado_Admin(adm);


            }
            catch { return Ok("La sucursal no ha sido agregada"); }

            return Ok("La sucursal se ha agregado exitosamente");
        }
        /*
         * Edita de manera completa la sucursal, editando en la tabla se sucursal, de acyivo, numero de sucursal y empleado admin, las cuales se relacionan para mantener
         * un conjunto de datos general se las sucursales
         */
        [HttpPost]
        [Route("EditarSucursalCompleta")]
        public IHttpActionResult EditarSucursalCompleta(Sucursal_Completa suc)
        {
            try
            {
                Sucursal sucursal = new Sucursal();
                Activo activo = new Activo();
                Numeros_sucursal num = new Numeros_sucursal();
                Empleado_Admin adm = new Empleado_Admin();
                sucursal.ID = suc.ID;
                sucursal.Max_capacidad = suc.Max_capacidad;
                sucursal.Nombre = suc.Nombre;
                sucursal.Provincia = suc.Provincia;
                sucursal.Canton = suc.Canton;
                sucursal.Distrito = suc.Distrito;
                sucursal.Fecha_apertura = suc.Fecha_apertura;
                Proyecto2.DataRequest.BDConection.editar_sucursal(sucursal);

                activo.ID = suc.ID;
                activo.Spa = suc.Spa;
                activo.Tienda = suc.Tienda;
                Proyecto2.DataRequest.BDConection.editar_activo(activo);

                num.ID_sucursal = suc.ID;
                num.Numero = suc.Numero;
                Proyecto2.DataRequest.BDConection.editar_numero_sucursal(num);

                adm.Cedula = suc.Administrador;
                adm.ID_sucursal = suc.ID;
                Proyecto2.DataRequest.BDConection.editar_Empleado_Admin(adm);

            }
            catch { return Ok("La sucursal no ha sido editada"); }

            return Ok("La sucursal se ha editado exitosamente");
        }
        /*
         * Un get el cual retorna toda la informacion relacionada con la sucursal, desde la informacion basica de la sucursal hasta su numero de telefono , su estado en la tabla activo
         * y su empleado administrador
         */
        [HttpGet]
        [Route("ConsultarSucursalCompleta")]
        public IHttpActionResult ConsultarSucursalCompleta()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.Consultar_Sucursal_Completo();
            }
            catch
            {
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.Consultar_Sucursal_Completo());
        }
        /*
         * Un get el cual retorna un json con todos los empleados , teniendo los atributos de puesto y tipo de planilla para un ,mejor control de la 
         * informacion del cliente
         */
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
        /*
         * Agrega un empleado completo desde la tabla empeado, agrega a la tabla puesto , el puetos ingresado y de la misma manera en la tabla tipo de planilla por empleado
         * donde relaciona el tipo de planilla con la cedula del empleado
         */
        [HttpPost]
        [Route("AgregarEmpleadoCompleto")]
        public IHttpActionResult AgregarEmpleadoCompleto(EmpleadoCompleto emp)
        {
            try{
                Empleado em = new Empleado();
                Consultar_Puestos_empleados_Result pue = new Consultar_Puestos_empleados_Result();
                Tipos_planillas_empleados tip = new Tipos_planillas_empleados();
                em.Cedula = emp.Cedula;
                em.Nombre = emp.Nombre;
                em.Apellido1 = emp.Apellido1;
                em.Apellido2 = emp.Apellido2;
                em.Canton = emp.Canton;
                em.Correo = emp.Correo;
                em.Distrito = emp.Distrito;
                em.Password = emp.Password;
                em.Provincia = emp.Provincia;
                em.Salario = emp.Salario;
                Proyecto2.DataRequest.BDConection.agregar_empleado(em);

                pue.Cedula = emp.Cedula;
                pue.ID_puesto = emp.ID_Puesto;
                Proyecto2.DataRequest.BDConection.agregar_Puestos_Empleados(pue);

                tip.Cedula = emp.Cedula;
                tip.ID_tipo_planilla = emp.ID;
                tip.Clases = 0;
                tip.Horas = 0;
                Proyecto2.DataRequest.BDConection.agregar_TPE(tip);
            }catch{
                return Ok("Error");
            }

            return Ok("Se agrego correctamente");
        }

        /*
         * Edita el empleado de una manera completa donde edita datos principales de los empleados, su puesto y tipo de planilla relacionado a el
         */
        [HttpPost]
        [Route("EditarEmpleadoCompleto")]
        public IHttpActionResult EditarEmpleadoCompleto(EmpleadoCompleto emp)
        {
            try{
                Empleado em = new Empleado();
                Consultar_Puestos_empleados_Result pue = new Consultar_Puestos_empleados_Result();
                Tipos_planillas_empleados tip = new Tipos_planillas_empleados();
                em.Cedula = emp.Cedula;
                em.Nombre = emp.Nombre;
                em.Apellido1 = emp.Apellido1;
                em.Apellido2 = emp.Apellido2;
                em.Canton = emp.Canton;
                em.Correo = emp.Correo;
                em.Distrito = emp.Distrito;
                em.Password = emp.Password;
                em.Provincia = emp.Provincia;
                em.Salario = emp.Salario;
                Proyecto2.DataRequest.BDConection.editar_empleado(em);

                pue.Cedula = emp.Cedula;
                pue.ID_puesto = emp.ID_Puesto;
                Proyecto2.DataRequest.BDConection.editar__Puestos_Empleados(pue);

                tip.Cedula = emp.Cedula;
                tip.ID_tipo_planilla = emp.ID;
                tip.Clases = 0;
                tip.Horas = 0;
                Proyecto2.DataRequest.BDConection.editar_TPE(tip);
            }catch{
                return Ok("Error");
            }

            return Ok("Se edito correctamente");
        }
        /*
         * Consultala infomacion completa de un Empleado desde su informacion basica hasta su puesto y tipo de planilla relacionada
         */
        [HttpGet]
        [Route("ConsultarEmpleadoCompleto")]
        public IHttpActionResult ConsultarEmpleadoCompleto()
        {
            try
            {
                Proyecto2.DataRequest.BDConection.Consultar_empleadoCompleto();
            }
            catch
            {
                return Ok("Error");
            }

            return Ok(Proyecto2.DataRequest.BDConection.Consultar_empleadoCompleto());
        }
    }
}
