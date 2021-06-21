using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using Proyecto2;
using Proyecto1;
//using EntityFramework.Extension;


namespace Proyecto2.DataRequest
{
    /*
     * En esta clase se encargara de realizar las peticiones al modelo de entity framework para poder alterar las tablas de la base de datos de sql server  
     */
    public static class BDConection
    {


        public static GymTECEntities4 con;

        /*
         * En este apartado, de manejan los tipos de Empleados, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //-------------------------------------------------------------------------------Empleado---------------------------------------------------------------
        public static List<Empleado> lista_empleados()
        {

            con = new GymTECEntities4();

            List<Empleado> lista = con.Empleado.ToList<Empleado>();

            return lista;
        }

        public static void agregar_empleado(Empleado emp)
        {
            con = new GymTECEntities4();
            con.Insertar_Empleado(emp.Cedula, emp.Correo, emp.Salario, emp.Provincia, emp.Distrito, emp.Canton, emp.Nombre, emp.Apellido1, emp.Apellido2, emp.Password);

            


        }
        public static void borrar_empleado(Empleado emp)
        {
            con = new GymTECEntities4();
            con.Borrar_Empleado(emp.Cedula);
            

        }
        public static Empleado login_empleado(Empleado emp)
        {
            con = new GymTECEntities4();
            var customer = con.Empleado.Single(o => o.Cedula == emp.Cedula);


            Empleado empleado = con.Empleado.Find(customer.Cedula);


            return empleado;
        }

        public static Empleado editar_empleado(Empleado emp)
        {
            con = new GymTECEntities4();
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

            con.Actualizar_Empleado(empleado.Cedula, empleado.Correo, empleado.Salario, empleado.Provincia, empleado.Distrito, empleado.Canton, empleado.Nombre, empleado.Apellido1, empleado.Apellido2, empleado.Password);


            return empleado;
        }

        public static ObjectResult<Consultar_Empleados_Completos_Result> Consultar_empleadoCompleto()
        {
            con = new GymTECEntities4();


            return con.Consultar_Empleados_Completos();
        }
        /*
         * En este apartado, de manejan los tipos de Sucursal, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //-------------------------------------------------------------------------------Sucursal--------------------------------------------------------------------

        public static void agregar_sucursal(Sucursal suc)
        {
            con = new GymTECEntities4();

            
            con.Insertar_Sucursal(suc.ID, suc.Max_capacidad, suc.Nombre, suc.Provincia, suc.Distrito, suc.Canton, suc.Fecha_apertura);

        }
        public static void borrar_sucursal(Sucursal suc)
        {
            con = new GymTECEntities4();
            con.Borrar_Sucursal(suc.ID);
            

        }
        public static Sucursal editar_sucursal(Sucursal suc)
        {
            con = new GymTECEntities4();
            var customer = con.Sucursal.Single(o => o.ID == suc.ID);


            Sucursal sucursal = con.Sucursal.Find(customer.ID);

            if (suc.Max_capacidad != 0) { sucursal.Max_capacidad = suc.Max_capacidad; }

            if (suc.Nombre != "") { sucursal.Nombre = suc.Nombre; }

            if (suc.Canton != "") { sucursal.Canton = suc.Canton; }

            if (suc.Distrito != "") { sucursal.Distrito = suc.Distrito; }

            if (suc.Provincia != "") { sucursal.Provincia = suc.Provincia; }
            con.Actualizar_Sucursal(sucursal.ID, sucursal.Max_capacidad, sucursal.Nombre, sucursal.Provincia, sucursal.Distrito, sucursal.Canton, sucursal.Fecha_apertura);



            return sucursal;
        }
        public static Sucursal Consulta_sucursal(Sucursal suc)
        {
            con = new GymTECEntities4();
            var customer = con.Sucursal.Single(o => o.ID == suc.ID);


            Sucursal sucursal = con.Sucursal.Find(customer.ID);


            return sucursal;
        }
        public static List<Sucursal> lista_sucursales()
        {
            con = new GymTECEntities4();

            List<Sucursal> lista = con.Sucursal.ToList<Sucursal>();

            return lista;
        }

        public static ObjectResult<Sucursal_Completo_Result> Consultar_Sucursal_Completo()
        {
            con = new GymTECEntities4();
            con.Sucursal_Completo();
            
            return con.Sucursal_Completo();
        }
        /*
         * En este apartado, de manejan los tipos de Tratamientos, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //---------------------------------------------------------------Tratamiento------------------------------------------------------------------
        public static void agregar_tratamiento(Tratamiento tra)
        {
            con = new GymTECEntities4();

            
            con.Insertar_Tratamiento(tra.ID, tra.ID_servicio, tra.Nombre);

        }
        public static void borrar_tratamiento(Tratamiento tra)
        {
            con = new GymTECEntities4();
            con.Borrar_Tratamiento(tra.ID);
            

        }
        public static Tratamiento editar_tratamiento(Tratamiento tra)
        {
            con = new GymTECEntities4();
            var customer = con.Tratamiento.Single(o => o.ID == tra.ID);


            Tratamiento tratamiento = con.Tratamiento.Find(customer.ID);

            if (tra.ID_servicio != "") { tratamiento.ID_servicio = tra.ID_servicio; }

            if (tra.Nombre != "") { tratamiento.Nombre = tra.Nombre; }
            con.Actualizar_Tratamiento(tratamiento.ID, tratamiento.ID_servicio, tratamiento.Nombre);


            return tratamiento;
        }
        public static Tratamiento Consulta_tratamiento(Tratamiento tra)
        {
            con = new GymTECEntities4();
            var customer = con.Tratamiento.Single(o => o.ID == tra.ID);


            Tratamiento tratamiento = con.Tratamiento.Find(customer.ID);


            return tratamiento;
        }

        public static List<Tratamiento> lista_tratamientos()
        {
            con = new GymTECEntities4();
            List<Tratamiento> lista = con.Tratamiento.ToList<Tratamiento>();

            return lista;
        }

        /*
         * En este apartado, de manejan los tipos de Puestos, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //-------------------------------------------------------------------------Puestos--------------------------------------------------------------------
        public static void agregar_Puesto(Puesto pue)
        {
            con = new GymTECEntities4();

            
            con.Insertar_Puesto(pue.ID, pue.Descripcion);

        }
        public static void borrar_Puesto(Puesto pue)
        {
            con = new GymTECEntities4();
            con.Borrar_Puesto(pue.ID);
            

        }
        public static Puesto editar_Puesto(Puesto pue)
        {
            con = new GymTECEntities4();
            var customer = con.Puesto.Single(o => o.ID == pue.ID);


            Puesto puesto = con.Puesto.Find(customer.ID);

            if (pue.Descripcion != "") { puesto.Descripcion = pue.Descripcion; }
            con.Actualizar_Puesto(pue.ID, pue.Descripcion);

            return puesto;
        }
        public static Puesto Consulta_Puesto(Puesto pue)
        {
            con = new GymTECEntities4();
            var customer = con.Puesto.Single(o => o.ID == pue.ID);


            Puesto puesto = con.Puesto.Find(customer.ID);


            return puesto;
        }

        public static List<Puesto> lista_puestos()
        {
            con = new GymTECEntities4();

            List<Puesto> lista = con.Puesto.ToList<Puesto>();

            return lista;
        }

        /*
         * En este apartado, de manejan los tipos de Tipo De Planilla, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //--------------------------------------------------------------------------Tipo de Planilla-----------------------------------------------------
        public static void agregar_Tplanilla(Tipo_planilla Tpla)
        {
            con = new GymTECEntities4();
            
            con.Insertar_Tipo_Planilla(Tpla.ID, Tpla.Descripcion);

        }
        public static void borrar_Tplanilla(Tipo_planilla Tpla)
        {
            con = new GymTECEntities4();
            con.Borrar_Tipo_Planilla(Tpla.ID);
            

        }
        public static Tipo_planilla editar_Tplanilla(Tipo_planilla Tpla)
        {
            con = new GymTECEntities4();
            var customer = con.Tipo_planilla.Single(o => o.ID == Tpla.ID);


            Tipo_planilla tplanilla = con.Tipo_planilla.Find(customer.ID);

            if (Tpla.Descripcion != "") { tplanilla.Descripcion = Tpla.Descripcion; }
            con.Actualizar_Tipo_Planilla(tplanilla.ID, tplanilla.Descripcion);

            return tplanilla;
        }
        public static Tipo_planilla Consulta_Tplanilla(Tipo_planilla Tpla)
        {
            con = new GymTECEntities4();
            var customer = con.Tipo_planilla.Single(o => o.ID == Tpla.ID);


            Tipo_planilla tplanilla = con.Tipo_planilla.Find(customer.ID);


            return tplanilla;
        }
        public static List<Tipo_planilla> lista_tipo_planilla()
        {
            con = new GymTECEntities4();

            List<Tipo_planilla> lista = con.Tipo_planilla.ToList<Tipo_planilla>();

            return lista;
        }

        /*
         * En este apartado, de manejan los tipos de Servicios, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //-------------------------------------------------------------Servicios-----------------------------------------------------------------
        public static void agregar_Servicio(Servicio ser)
        {
            con = new GymTECEntities4();
            
            con.Insertar_Servicio(ser.ID, ser.ID_sucursal, ser.Descripcion);

        }
        public static void borrar_Servicio(Servicio ser)
        {
            con = new GymTECEntities4();
            con.Borrar_Servicio(ser.ID);
            

        }
        public static Servicio editar_Servicio(Servicio ser)
        {
            con = new GymTECEntities4();
            var customer = con.Servicio.Single(o => o.ID == ser.ID);


            Servicio servicio = con.Servicio.Find(customer.ID);

            if (ser.ID_sucursal != "") { servicio.ID_sucursal = ser.ID_sucursal; }
            if (ser.Descripcion != "") { servicio.Descripcion = ser.Descripcion; }
            con.Actualizar_Servicio(servicio.ID, servicio.ID_sucursal, ser.Descripcion);

            return servicio;
        }
        public static Servicio Consulta_Servicio(Servicio ser)
        {
            con = new GymTECEntities4();
            var customer = con.Servicio.Single(o => o.ID == ser.ID);


            Servicio servicio = con.Servicio.Find(customer.ID);


            return servicio;
        }
        public static List<Servicio> lista_Servicio()
        {
            con = new GymTECEntities4();

            List<Servicio> lista = con.Servicio.ToList<Servicio>();

            return lista;
        }
        /*
         * En este apartado, de manejan los tipos de Tipo de Equipo, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //-------------------------------------------------------------------------Tipo de Equipo---------------------------------------------------------
        public static void agregar_TEquipo(Tipo_equipo Tequi)
        {
            con = new GymTECEntities4();
            con.Insertar_Tipo_equipo(Tequi.ID, Tequi.Nombre);
            


        }
        public static void borrar_TEquipo(Tipo_equipo Tequi)
        {
            con = new GymTECEntities4();
            con.Borrar_Tipo_equipo(Tequi.ID);
            

        }
        public static Tipo_equipo editar_TEquipo(Tipo_equipo Tequi)
        {
            con = new GymTECEntities4();
            var customer = con.Tipo_equipo.Single(o => o.ID == Tequi.ID);


            Tipo_equipo tequipo = con.Tipo_equipo.Find(customer.ID);

            if (Tequi.Nombre != "") { tequipo.Nombre = Tequi.Nombre; }

            con.Actualizar_Tipo_equipo(tequipo.ID, tequipo.Nombre);

            return tequipo;
        }
        public static Tipo_equipo Consulta_TEquipo(Tipo_equipo Tequi)
        {
            con = new GymTECEntities4();
            var customer = con.Tipo_equipo.Single(o => o.ID == Tequi.ID);


            Tipo_equipo tequipo = con.Tipo_equipo.Find(customer.ID);


            return tequipo;
        }

        public static List<Tipo_equipo> lista_Tipo_equipo()

        {
            con = new GymTECEntities4();

            List<Tipo_equipo> lista = con.Tipo_equipo.ToList<Tipo_equipo>();

            return lista;
        }

        /*
         * En este apartado, de manejan los tipos de Maquinas, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //-------------------------------------------------------------------------Maquinas---------------------------------------------------------------
        public static void agregar_Maquina(Maquina maq)
        {
            con = new GymTECEntities4();

            
            con.Insertar_Maquina(maq.Serie, maq.ID_sucursal, maq.Costo, maq.Marca);

        }
        public static void borrar_Maquina(Maquina maq)
        {
            con = new GymTECEntities4();
            con.Borrar_Maquina(maq.Serie);
            

        }
        public static Maquina editar_Maquina(Maquina maq)

        {
            con = new GymTECEntities4();
            var customer = con.Maquina.Single(o => o.Serie == maq.Serie);


            Maquina maquina = con.Maquina.Find(customer.Serie);

            if (maq.ID_sucursal != "") { maquina.ID_sucursal = maq.ID_sucursal; }
            if (maq.Marca != "") { maquina.Marca = maq.Marca; }
            if (maq.Costo != 0) { maquina.Costo = maq.Costo; }
            con.Actualizar_Maquina(maquina.Serie, maquina.ID_sucursal, maquina.Costo, maquina.Marca);

            return maquina;
        }
        public static Maquina Consulta_Maquina(Maquina maq)

        {
            con = new GymTECEntities4();
            var customer = con.Maquina.Single(o => o.Serie == maq.Serie);


            Maquina maquina = con.Maquina.Find(customer.Serie);


            return maquina;
        }
        public static List<Maquina> lista_Maquina()
        {
            con = new GymTECEntities4();

            List<Maquina> lista = con.Maquina.ToList<Maquina>();

            return lista;
        }

        /*
         * En este apartado, de manejan los tipos de Rol, cuando tiene las peticiones de agregar, borrar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //----------------------------------------------------------------------------Rol-------------------------------------------------------------
        public static void agregar_Rol(Rol rol)
        {
            con = new GymTECEntities4();
            con.Insertar_Rol(rol.ID, rol.Descripcion);
            


        }
        public static void borrar_Rol(Rol rol)
        {
            con = new GymTECEntities4();
            con.Borrar_Rol(rol.ID);
            

        }
        /*
         * En este apartado, de manejan Numero de Sucursal, cuando tiene las peticiones de agregar, editar , borra  por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //--------------------------------------------------------------------------Numeros de Sucursal----------------------------------------------------
        public static void agregar_numero_sucursal(Numeros_sucursal num)
        {
            con = new GymTECEntities4();
            con.Insertar_Numeros_sucursal(num.ID_sucursal, num.Numero);
            


        }
        public static void borrar_numero_sucursal(Numeros_sucursal num)
        {
            con = new GymTECEntities4();
            con.Borrar_Numeros_sucursal(num.ID_sucursal);
            

        }
        public static void editar_numero_sucursal(Numeros_sucursal num)
        {
            con = new GymTECEntities4();
            con.Actualizar_Numero_Sucursal(num.ID_sucursal, num.Numero);
            

        }

        /*
         * En este apartado, de manejan Tipo de planilla de Empleados, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //------------------------------------------------------------------------Tipo de planilla de empleados----------------------------------------------
        public static void agregar_TPE(Tipos_planillas_empleados tpe)
        {
            con = new GymTECEntities4();
            con.Insertar_Tipos_planillas_empleados(tpe.Cedula, tpe.ID_tipo_planilla, tpe.Clases, tpe.Horas);
            


        }
        public static void borrar_TPE(Tipos_planillas_empleados tpe)
        {
            con = new GymTECEntities4();
            con.Borrar_Tipos_planillas_empleados(tpe.Cedula);
            

        }
        public static void editar_TPE(Tipos_planillas_empleados tpe)
        {
            con = new GymTECEntities4();

            con.Actualizar_Tipos_planillas_empleados(tpe.Cedula, tpe.ID_tipo_planilla, tpe.Clases, tpe.Horas);


        }

        /*
         * En este apartado, de manejan Productos, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //----------------------------------------------------------------------Producto-------------------------------------------------------------
        public static void agregar_producto(Producto pro)
        {
            con = new GymTECEntities4();
            con.Insertar_Producto(pro.Bar_code, pro.ID_servicio, pro.Nombre, pro.Costo, pro.Descripcion);
            

        }
        public static void borrar_producto(Producto pro)
        {
            con = new GymTECEntities4();
            con.Borrar_Producto(pro.Bar_code);
            

        }

        public static Producto editar_producto(Producto pro)
        {
            con = new GymTECEntities4();
            var customer = con.Producto.Single(o => o.Bar_code == pro.Bar_code);

            Producto producto = con.Producto.Find(customer.Bar_code);

            if (pro.Nombre != "") { producto.Nombre = pro.Nombre; }

            if (pro.Costo != 0) { producto.Costo = pro.Costo; }

            if (pro.Descripcion != "") { producto.Descripcion = pro.Descripcion; }
            con.Actualizar_Producto(pro.Bar_code, pro.ID_servicio, pro.Nombre, pro.Costo, pro.Descripcion);

            return producto;
        }

        public static Producto consultar_producto(Producto pro)
        {
            con = new GymTECEntities4();
            var customer = con.Producto.Single(o => o.Bar_code == pro.Bar_code);
            Producto producto = con.Producto.Find(customer.Bar_code);
            return producto;
        }
        /*
         * En este apartado, de manejan Activo, cuando tiene las peticiones de agregar, editar  y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //------------------------------------------------------------------------Activo----------------------------------------------------------------------
        public static void agregar_activo(Activo act)
        {
            con = new GymTECEntities4();
            con.Insertar_Activo(act.ID, act.Spa, act.Tienda);


        }
        public static void editar_activo(Activo act)
        {
            con = new GymTECEntities4();
            var customer = con.Activo.Single(o => o.ID == act.ID);

            Activo activo = con.Activo.Find(customer.ID);

            if (act.Spa != "") { activo.Spa = act.Spa; }

            if (act.Tienda != "") { activo.Tienda = act.Tienda; }


            con.Actualizar_Activo(act.ID, act.Spa, act.Tienda);

        }
        public static Activo consultar_Activo(Activo act)
        {
            con = new GymTECEntities4();
            var customer = con.Activo.Single(o => o.ID == act.ID);
            Activo activo = con.Activo.Find(customer.ID);
            return activo;
        }

        /*
         * En este apartado, de manejan Clase, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //---------------------------------------------------------------------------Clase-------------------------------------------------------------
        public static void agregar_Clase(Clase cla)
        {
            con = new GymTECEntities4();
            con.Insertar_Clase(cla.ID, cla.ID_sucursal, cla.Tipo, cla.Modalidad, cla.Instructor, cla.Hora_inicio, cla.Hora_fin, cla.Fecha);


        }
        public static void borrar__Clase(Clase cla)
        {
            con = new GymTECEntities4();
            con.Borrar_Clase(cla.ID);

        }

        public static Clase editar__Clase(Clase cla)
        {
            con = new GymTECEntities4();
            var customer = con.Clase.Single(o => o.ID == cla.ID);

            Clase clase = con.Clase.Find(customer.ID);
            con.Actualizar_Clase(cla.ID, cla.ID_sucursal, cla.Tipo, cla.Modalidad, cla.Instructor, cla.Hora_inicio, cla.Hora_fin, cla.Fecha);

            return clase;
        }

        public static Clase consultar__Clase(Clase cla)
        {
            con = new GymTECEntities4();
            var customer = con.Clase.Single(o => o.ID == cla.ID);

            Clase clase = con.Clase.Find(customer.ID);
            return clase;
        }

        /*
         * En este apartado, de manejan Cliente, cuando tiene las peticiones de agregar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //---------------------------------------------------------------------------------Cliente------------------------------------------------

        public static void agregar_Cliente(Cliente cli)
        {
            con = new GymTECEntities4();
            con.Insertar_Cliente(cli.Cedula);


        }
        public static void borrar__Cliente(Cliente cli)
        {
            con = new GymTECEntities4();
            con.Borrar_Cliente(cli.Cedula);

        }

        public static List<Cliente> lista_Cliente()
        {
            con = new GymTECEntities4();

            List<Cliente> lista = con.Cliente.ToList<Cliente>();
            return lista;
        }

        /*
         * En este apartado, de manejan Roles Empleados, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //--------------------------------------------------------------Roles Empleados-----------------------------------------------------------
        public static void agregar_Roles_Empleados(Consultar_Roles_empleados_Result rol)
        {
            con = new GymTECEntities4();
            con.Insertar_Roles_empleados(rol.Cedula, rol.ID_rol);


        }
        public static void borrar__Roles_Empleados(Consultar_Roles_empleados_Result rol)
        {
            con = new GymTECEntities4();
            con.Borrar_Roles_empleados(rol.Cedula);

        }

        public static void editar__Roles_Empleados(Consultar_Roles_empleados_Result rol)
        {
            con = new GymTECEntities4();
            con.Actualizar_Roles_empleados(rol.Cedula, rol.ID_rol);


        }

        public static List<Consultar_Roles_empleados_Result> consultar__Roles_Empleados(Consultar_Roles_empleados_Result rol)
        {

            con = new GymTECEntities4();
            List<Consultar_Roles_empleados_Result> clase = con.Consultar_Roles_empleados(rol.Cedula).ToList<Consultar_Roles_empleados_Result>();
            return clase;
        }

        /*
         * En este apartado, de manejan Puestos Empleados, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //------------------------------------------------------------------Puestos_Empleados------------------------------------------------------------

        public static void agregar_Puestos_Empleados(Consultar_Puestos_empleados_Result pue)
        {
            con = new GymTECEntities4();
            con.Insertar_Puestos_empleados(pue.Cedula, pue.ID_puesto);


        }
        public static void borrar__Puestos_Empleados(Consultar_Puestos_empleados_Result pue)
        {
            con = new GymTECEntities4();
            con.Borrar_Roles_empleados(pue.Cedula);

        }

        public static void editar__Puestos_Empleados(Consultar_Puestos_empleados_Result pue)
        {
            con = new GymTECEntities4();
            con.Actualizar_Puestos_empleados(pue.Cedula, pue.ID_puesto);


        }

        public static List<Consultar_Puestos_empleados_Result> consultar__Puestos_Empleados(Consultar_Puestos_empleados_Result pue)
        {

            con = new GymTECEntities4();
            List<Consultar_Puestos_empleados_Result> result = con.Consultar_Puestos_empleados(pue.Cedula).ToList<Consultar_Puestos_empleados_Result>();
            return result;
        }
        /*
         * En este apartado, de manejan Empleado Admin, cuando tiene las peticiones de agregar, editar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //---------------------------------------------------------------------Empleado_Admin----------------------------------------------------------
        public static void agregar_Empleado_Admin(Empleado_Admin emp)
        {
            con = new GymTECEntities4();
            con.Insertar_Empleado_Admin(emp.Cedula, emp.ID_sucursal);


        }
        public static void borrar__Empleado_Admin(Empleado_Admin emp)
        {
            con = new GymTECEntities4();
            con.Borrar_Empleado_Admin(emp.Cedula);

        }

        public static List<Consultar_Empleado_Admin_Result> consultar_Empleado_Admin(Consultar_Empleado_Admin_Result emp)
        {
            con = new GymTECEntities4();
            List<Consultar_Empleado_Admin_Result> lista = con.Consultar_Empleado_Admin(emp.Cedula).ToList<Consultar_Empleado_Admin_Result>();
            return lista;
        }

        public static void editar_Empleado_Admin(Empleado_Admin emp)
        {
            con = new GymTECEntities4();
            con.Actualizar_Empleado_Admin(emp.Cedula, emp.ID_sucursal);

        }

        /*
         * En este apartado, de manejan Clase Cliente, cuando tiene las peticiones de agregar , borra y consultar por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //---------------------------------------------------------------------Clase Cliente----------------------------------------------------

        public static void agregar_Clase_Cliente(Consultar_Clase_Cliente_Result cli)
        {
            con = new GymTECEntities4();
            con.Insertar_Clase_Cliente(cli.Cedula, cli.ID_clase);


        }
        public static void borrar__Clase_Cliente(Consultar_Clase_Cliente_Result cli)
        {
            con = new GymTECEntities4();
            con.Borrar_Clase_Cliente(cli.Cedula);

        }

        public static List<Consultar_Clase_Cliente_Result> consultar_Clase_Cliente(Consultar_Clase_Cliente_Result cli)
        {
            con = new GymTECEntities4();
            List<Consultar_Clase_Cliente_Result> lista = con.Consultar_Clase_Cliente(cli.Cedula).ToList<Consultar_Clase_Cliente_Result>();
            return lista;
        }
        /*
         * En este apartado, de manejan Maquina Tipo, cuando tiene las peticiones de agregar, editar , borra por medio de la llave foranea 
         * respectiva de la tabla,llamando funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //-------------------------------------------------------------------Maquina_Tipo-------------------------------------------------------------
        public static void agregar_Maquina_Tipo(Maquina_Tipo maq)
        {
            con = new GymTECEntities4();
            con.Insertar_Maquinas_Tipos(maq.Serie, maq.ID);


        }
        public static void borrar__Maquina_Tipo(Maquina_Tipo maq)
        {
            con = new GymTECEntities4();
            con.Borrar_Maquinas_Tipos(maq.Serie);

        }

        public static void editar__Maquina_Tipo(Maquina_Tipo maq)
        {
            con = new GymTECEntities4();
            con.Actualizar_Maquinas_Tipos(maq.Serie, maq.ID);


        }
        /*
         * En este apartado, de manejan Planilla,y las dos vistas , cuando tiene las peticiones las cuales hacen su funcion llamando a las funciones respectivas al tipo de datos respectivo y hace el llamado al modelo de la base de datos con la relacion 
         * de entity framework
         */
        //-----------------------------------------------------------------------------Planilla------------------------------------------

        public static System.Data.Entity.Core.Objects.ObjectResult<Generar_Plantilla_Result> Planilla()
        {
            con = new GymTECEntities4();
            con.Generar_Plantilla();

            return con.Generar_Plantilla();
        }

        public static DbSet<Maquina_R_Tipo> MaquinaTipo()
        {
            con = new GymTECEntities4();
            return con.Maquina_R_Tipo;
        }

        public static DbSet<Clase_R_Cliente> ClaseCliente()
        {
            con = new GymTECEntities4();
            return con.Clase_R_Cliente;
        }
        /*
         * Se manejan todos los get All de todas las tablas principales, para un mejor manejo de la informacion , retornando todas las tuplas existentes 
         * con todos los atributos despinados para cada entidad
         */
        //-------------------------------------------------------------------------GET ALL--------------------------------------------------------
        public static ObjectResult<Consultar_All_Sucursales_Result> ALL_Sucursal()
        {
            con = new GymTECEntities4();
            return con.Consultar_All_Sucursales();
        }

        public static ObjectResult<Consultar_All_Clase_Result> ALL_Clases()
        {
            con = new GymTECEntities4();
            return con.Consultar_All_Clase();
        }

        public static ObjectResult<Consultar_All_Empleados_Result> ALL_Empleados()
        {
            con = new GymTECEntities4();
            return con.Consultar_All_Empleados();
        }

        public static ObjectResult<Consultar_All_Maquinas_Result> ALL_Maquinas()
        {
            con = new GymTECEntities4();

            return con.Consultar_All_Maquinas();
        }
        public static ObjectResult<Consultar_All_Productos_Result> ALL_Productos()
        {
            con = new GymTECEntities4();
            return con.Consultar_All_Productos();
        }
        public static ObjectResult<Consultar_All_Puestos_Result> ALL_Puestos()
        {
            con = new GymTECEntities4();
            return con.Consultar_All_Puestos();
        }
        public static ObjectResult<Consultar_All_Servicios_Result> ALL_Servicios()
        {
            con = new GymTECEntities4();

            return con.Consultar_All_Servicios();
        }

        public static ObjectResult<Consultar_All_Tipo_equipos_Result> ALL_Tipo_Equipo()
        {
            con = new GymTECEntities4();

            return con.Consultar_All_Tipo_equipos();
        }
        public static ObjectResult<Consultar_All_Tipo_Planillas_Result> ALL_Tipo_Planilla()
        {
            con = new GymTECEntities4();

            return con.Consultar_All_Tipo_Planillas();
        }
        public static ObjectResult<Consultar_All_Tratamientos_Result> ALL_Tratamiento()
        {
            con = new GymTECEntities4();

            return con.Consultar_All_Tratamientos();
        }

        public static ObjectResult<Consultar_Empleado_Total_Result> ALL_Empleado_Total()
        {
            con = new GymTECEntities4();
            return con.Consultar_Empleado_Total();
        }

    }
}
