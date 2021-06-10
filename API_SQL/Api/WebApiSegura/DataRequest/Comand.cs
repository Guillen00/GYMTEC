﻿using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using System.IO;
using System.Linq;
using Proyecto2;
using Proyecto1;
//using EntityFramework.Extension;


namespace Proyecto2.DataRequest
{
    /*
     * En esta clase se conectara con la base de datos en postgresql con todas las peticiones especificas para las tablas de la base 
     */
    public static class BDConection {
        
        
        public static GymTECEntities1 con = new GymTECEntities1();
        
        //-------------------------------------------------------------------------------Empleado---------------------------------------------------------------
        public static List<Empleado> lista_empleados() {

            List<Empleado> lista = con.Empleado.ToList<Empleado>();
            
            return lista;
        }

        public static void agregar_empleado(Empleado emp)
        {
            con.Insertar_Empleado(emp.Cedula, emp.Correo, emp.Salario, emp.Provincia, emp.Distrito, emp.Canton, emp.Nombre, emp.Apellido1, emp.Apellido2, emp.Password);
            
            //con.Empleado.Add(emp);

            con.SaveChanges();
        }
        public static void borrar_empleado(Empleado emp)
        {
            con.Borrar_Empleado(emp.Cedula);
            //var customer = con.Empleado.Single(o => o.Cedula == emp.Cedula);
            //con.Empleado.Remove(customer);
            con.SaveChanges();
        }
        public static Empleado login_empleado(Empleado emp)
        {
            var customer = con.Empleado.Single(o => o.Cedula == emp.Cedula);


            Empleado empleado = con.Empleado.Find(customer.Cedula);
            
            con.SaveChanges();
            return empleado;
        }

        public static Empleado editar_empleado(Empleado emp)
        {
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
            
            con.Actualizar_Empleado(empleado.Cedula,empleado.Correo,empleado.Salario,empleado.Provincia,empleado.Distrito,empleado.Canton,empleado.Nombre,empleado.Apellido1,empleado.Apellido2,empleado.Password);
            
            con.SaveChanges();
            return empleado;
        }

        //-------------------------------------------------------------------------------Sucursal--------------------------------------------------------------------

        public static void agregar_sucursal(Sucursal suc)
        {

            //con.Sucursal.Add(suc);
            con.Insertar_Sucursal(suc.ID, suc.Max_capacidad, suc.Nombre, suc.Provincia, suc.Distrito, suc.Canton, suc.Fecha_apertura);
            con.SaveChanges();
        }
        public static void borrar_sucursal(Sucursal suc)
        {
            con.Borrar_Sucursal(suc.ID);
            //var customer = con.Sucursal.Single(o => o.ID == suc.ID);
            //con.Sucursal.Remove(customer);
            con.SaveChanges();
        }
        public static Sucursal editar_sucursal(Sucursal suc)
        {
            var customer = con.Sucursal.Single(o => o.ID == suc.ID);


            Sucursal sucursal = con.Sucursal.Find(customer.ID);

            if (suc.Max_capacidad != 0) { sucursal.Max_capacidad = suc.Max_capacidad; }

            if (suc.Nombre != "") { sucursal.Nombre = suc.Nombre; }

            if (suc.Canton != "") { sucursal.Canton = suc.Canton; }

            if (suc.Distrito != "") { sucursal.Distrito = suc.Distrito; }

            if (suc.Provincia != "") { sucursal.Provincia = suc.Provincia; }
            con.Actualizar_Sucursal(sucursal.ID, sucursal.Max_capacidad, sucursal.Nombre, sucursal.Provincia, sucursal.Distrito, sucursal.Canton, sucursal.Fecha_apertura);


            con.SaveChanges();
            return sucursal;
        }
        public static Sucursal Consulta_sucursal(Sucursal suc)
        {
            var customer = con.Sucursal.Single(o => o.ID == suc.ID);


            Sucursal sucursal = con.Sucursal.Find(customer.ID);

            con.SaveChanges();
            return sucursal;
        }
        public static List<Sucursal> lista_sucursales()
        {

            List<Sucursal> lista = con.Sucursal.ToList<Sucursal>();

            return lista;
        }

        //---------------------------------------------------------------Tratamiento------------------------------------------------------------------
        public static void agregar_tratamiento(Tratamiento tra)
        {

            //con.Tratamiento.Add(tra);
            con.Insertar_Tratamiento(tra.ID, tra.ID_servicio, tra.Nombre);
            con.SaveChanges();
        }
        public static void borrar_tratamiento(Tratamiento tra)
        {
            con.Borrar_Tratamiento(tra.ID);
            //var customer = con.Tratamiento.Single(o => o.ID == tra.ID);
            //con.Tratamiento.Remove(customer);
            con.SaveChanges();
        }
        public static Tratamiento editar_tratamiento(Tratamiento tra)
        {
            var customer = con.Tratamiento.Single(o => o.ID == tra.ID);


            Tratamiento tratamiento = con.Tratamiento.Find(customer.ID);

            if (tra.ID_servicio != "") { tratamiento.ID_servicio = tra.ID_servicio; }

            if (tra.Nombre != "") { tratamiento.Nombre = tra.Nombre; }
            con.Actualizar_Tratamiento(tratamiento.ID, tratamiento.ID_servicio, tratamiento.Nombre);

            con.SaveChanges();
            return tratamiento;
        }
        public static Tratamiento Consulta_tratamiento(Tratamiento tra)
        {
            var customer = con.Tratamiento.Single(o => o.ID == tra.ID);


            Tratamiento tratamiento = con.Tratamiento.Find(customer.ID);

            con.SaveChanges();
            return tratamiento;
        }

        public static List<Tratamiento> lista_tratamientos()
        {

            List<Tratamiento> lista = con.Tratamiento.ToList<Tratamiento>();

            return lista;
        }

        //-------------------------------------------------------------------------Puestos--------------------------------------------------------------------
        public static void agregar_Puesto(Puesto pue)
        {

            //con.Puesto.Add(pue);
            con.Insertar_Puesto(pue.ID, pue.Descripcion);
            con.SaveChanges();
        }
        public static void borrar_Puesto(Puesto pue)
        {
            con.Borrar_Puesto(pue.ID);
            //var customer = con.Puesto.Single(o => o.ID == pue.ID);
            //con.Puesto.Remove(customer);
            con.SaveChanges();
        }
        public static Puesto editar_Puesto(Puesto pue)
        {
            var customer = con.Puesto.Single(o => o.ID == pue.ID);


            Puesto puesto = con.Puesto.Find(customer.ID);

            if (pue.Descripcion != "") { puesto.Descripcion = pue.Descripcion; }
            con.Actualizar_Puesto(pue.ID, pue.Descripcion);
            con.SaveChanges();
            return puesto;
        }
        public static Puesto Consulta_Puesto(Puesto pue)
        {
            var customer = con.Puesto.Single(o => o.ID == pue.ID);


            Puesto puesto = con.Puesto.Find(customer.ID);

            con.SaveChanges();
            return puesto;
        }

        public static List<Puesto> lista_puestos()
        {

            List<Puesto> lista = con.Puesto.ToList<Puesto>();

            return lista;
        }
        //--------------------------------------------------------------------------Tipo de Planilla-----------------------------------------------------
        public static void agregar_Tplanilla(Tipo_planilla Tpla)
        {

            //con.Tipo_planilla.Add(Tpla);
            con.Insertar_Tipo_Planilla(Tpla.ID, Tpla.Descripcion);
            con.SaveChanges();
        }
        public static void borrar_Tplanilla(Tipo_planilla Tpla)
        {
            con.Borrar_Tipo_Planilla(Tpla.ID);
            //var customer = con.Tipo_planilla.Single(o => o.ID == Tpla.ID);
            //con.Tipo_planilla.Remove(customer);
            con.SaveChanges();
        }
        public static Tipo_planilla editar_Tplanilla(Tipo_planilla Tpla)
        {
            var customer = con.Tipo_planilla.Single(o => o.ID == Tpla.ID);


            Tipo_planilla tplanilla = con.Tipo_planilla.Find(customer.ID);

            if (Tpla.Descripcion != "") { tplanilla.Descripcion = Tpla.Descripcion; }
            con.Actualizar_Tipo_Planilla(tplanilla.ID, tplanilla.Descripcion);
            con.SaveChanges();
            return tplanilla;
        }
        public static Tipo_planilla Consulta_Tplanilla(Tipo_planilla Tpla)
        {
            var customer = con.Tipo_planilla.Single(o => o.ID == Tpla.ID);


            Tipo_planilla tplanilla = con.Tipo_planilla.Find(customer.ID);

            con.SaveChanges();
            return tplanilla;
        }
        public static List<Tipo_planilla> lista_tipo_planilla()
        {

            List<Tipo_planilla> lista = con.Tipo_planilla.ToList<Tipo_planilla>();

            return lista;
        }
        //-------------------------------------------------------------Servicios-----------------------------------------------------------------
        public static void agregar_Servicio(Servicio ser)
        {

            //con.Servicio.Add(ser);
            con.Insertar_Servicio(ser.ID, ser.ID_sucursal, ser.Spa, ser.Tienda);
            con.SaveChanges();
        }
        public static void borrar_Servicio(Servicio ser)
        {
            con.Borrar_Servicio(ser.ID);
            //var customer = con.Servicio.Single(o => o.ID == ser.ID);
            //con.Servicio.Remove(customer);
            con.SaveChanges();
        }
        public static Servicio editar_Servicio(Servicio ser)
        {
            var customer = con.Servicio.Single(o => o.ID == ser.ID);


            Servicio servicio = con.Servicio.Find(customer.ID);

            if (ser.ID_sucursal != "") { servicio.ID_sucursal = ser.ID_sucursal; }
            if (ser.Spa != "") { servicio.Spa = ser.Spa; }
            if (ser.Tienda != "") { servicio.Tienda = ser.Tienda; }
            con.Actualizar_Servicio(servicio.ID, servicio.ID_sucursal, servicio.Spa, servicio.Tienda);
            con.SaveChanges();
            return servicio;
        }
        public static Servicio Consulta_Servicio(Servicio ser)
        {
            var customer = con.Servicio.Single(o => o.ID == ser.ID);


            Servicio servicio = con.Servicio.Find(customer.ID);

            con.SaveChanges();
            return servicio;
        }
        public static List<Servicio> lista_Servicio()
        {

            List<Servicio> lista = con.Servicio.ToList<Servicio>();

            return lista;
        }
        //-------------------------------------------------------------------------Tipo de Equipo---------------------------------------------------------
        public static void agregar_TEquipo(Tipo_equipo Tequi)
        {
            con.Insertar_Tipo_equipo(Tequi.ID, Tequi.Nombre);
            //con.Tipo_equipo.Add(Tequi);

            con.SaveChanges();
        }
        public static void borrar_TEquipo(Tipo_equipo Tequi)
        {
            con.Borrar_Tipo_equipo(Tequi.ID);
            //var customer = con.Tipo_equipo.Single(o => o.ID == Tequi.ID);
            //con.Tipo_equipo.Remove(customer);
            con.SaveChanges();
        }
        public static Tipo_equipo editar_TEquipo(Tipo_equipo Tequi)
        {
            var customer = con.Tipo_equipo.Single(o => o.ID == Tequi.ID);


            Tipo_equipo tequipo = con.Tipo_equipo.Find(customer.ID);

            if (Tequi.Nombre != "") { tequipo.Nombre = Tequi.Nombre; }

            con.Actualizar_Tipo_equipo(tequipo.ID, tequipo.Nombre);
            con.SaveChanges();
            return tequipo;
        }
        public static Tipo_equipo Consulta_TEquipo(Tipo_equipo Tequi)
        {
            var customer = con.Tipo_equipo.Single(o => o.ID == Tequi.ID);


            Tipo_equipo tequipo = con.Tipo_equipo.Find(customer.ID);

            con.SaveChanges();
            return tequipo;
        }

        public static List<Tipo_equipo> lista_Tipo_equipo()
        {

            List<Tipo_equipo> lista = con.Tipo_equipo.ToList<Tipo_equipo>();

            return lista;
        }
        //-------------------------------------------------------------------------Maquinas---------------------------------------------------------------
        public static void agregar_Maquina(Maquina maq)
        {

            //con.Maquina.Add(maq);
            con.Insertar_Maquina(maq.Serie, maq.ID_sucursal, maq.Costo, maq.Marca);
            con.SaveChanges();
        }
        public static void borrar_Maquina(Maquina maq)
        {
            con.Borrar_Maquina(maq.Serie);
            //var customer = con.Maquina.Single(o => o.Serie == maq.Serie);
            //con.Maquina.Remove(customer);
            con.SaveChanges();
        }
        public static Maquina editar_Maquina(Maquina maq)
        {
            var customer = con.Maquina.Single(o => o.Serie == maq.Serie);


            Maquina maquina = con.Maquina.Find(customer.Serie);

            if (maq.ID_sucursal != "") { maquina.ID_sucursal = maq.ID_sucursal; }
            if (maq.Marca != "") { maquina.Marca = maq.Marca; }
            if (maq.Costo != 0) { maquina.Costo = maq.Costo; }
            con.Actualizar_Maquina(maquina.Serie, maquina.ID_sucursal, maquina.Costo, maquina.Marca);
            con.SaveChanges();
            return maquina;
        }
        public static Maquina Consulta_Maquina(Maquina maq)
        {
            var customer = con.Maquina.Single(o => o.Serie == maq.Serie);


            Maquina maquina = con.Maquina.Find(customer.Serie);

            con.SaveChanges();
            return maquina;
        }
        public static List<Maquina> lista_Maquina()
        {

            List<Maquina> lista = con.Maquina.ToList<Maquina>();

            return lista;
        }


        //----------------------------------------------------------------------------Rol-------------------------------------------------------------
        public static void agregar_Rol(Rol rol)
        {
            con.Insertar_Rol(rol.ID,rol.Descripcion);
            //con.Rol.Add(rol);

            con.SaveChanges();
        }
        public static void borrar_Rol(Rol rol)
        {
            con.Borrar_Rol(rol.ID);
           // var customer = con.Rol.Single(o => o.ID == rol.ID);
            //con.Rol.Remove(customer);
            con.SaveChanges();
        }

        //--------------------------------------------------------------------------Numeros de Sucursal----------------------------------------------------
        public static void agregar_numero_sucursal(Numeros_sucursal num)
        {
            con.Insertar_Numeros_sucursal(num.ID_sucursal, num.Numero);
            //con.Numeros_sucursal.Add(num);

            con.SaveChanges();
        }
        public static void borrar_numero_sucursal(Numeros_sucursal num)
        {
            con.Borrar_Numeros_sucursal(num.ID_sucursal);
            //var customer = con.Numeros_sucursal.Single(o => o.ID_sucursal == num.ID_sucursal);
            //con.Numeros_sucursal.Remove(customer);
            con.SaveChanges();
        }

        //------------------------------------------------------------------------Tipo de planilla de empleados----------------------------------------------
        public static void agregar_TPE(Tipos_planillas_empleados tpe)
        {
            con.Insertar_Tipos_planillas_empleados(tpe.Cedula, tpe.ID_tipo_planilla, tpe.Clases, tpe.Horas);
            //con.Tipos_planillas_empleados.Add(tpe);

            con.SaveChanges();
        }
        public static void borrar_TPE(Tipos_planillas_empleados tpe)
        {
            con.Borrar_Tipos_planillas_empleados(tpe.Cedula);
            //var customer = con.Tipos_planillas_empleados.Single(o => o.ID_tipo_planilla == tpe.ID_tipo_planilla);
            //con.Tipos_planillas_empleados.Remove(customer);
            con.SaveChanges();
        }
        public static Tipos_planillas_empleados editar_TPE(Tipos_planillas_empleados tpe)
        {
            var customer = con.Tipos_planillas_empleados.Single(o => o.Cedula == tpe.Cedula);


            Tipos_planillas_empleados TPE = con.Tipos_planillas_empleados.Find(customer.Cedula);

            if (tpe.ID_tipo_planilla != "") { TPE.ID_tipo_planilla = tpe.ID_tipo_planilla; }
            if (tpe.Horas != "") { TPE.Horas = tpe.Horas; }
            if (tpe.Clases != "") { TPE.Clases = tpe.Clases; }
            con.Actualizar_Tipos_planillas_empleados(TPE.Cedula,TPE.ID_tipo_planilla,TPE.Clases,TPE.Horas);
            con.SaveChanges();
            return TPE;
        }
        //----------------------------------------------------------------------Producto-------------------------------------------------------------
        public static void agregar_producto(Producto pro)
        {
            con.Insertar_Producto(pro.Bar_code, pro.ID_servicio, pro.Nombre, pro.Costo, pro.Descripcion);
            //con.Producto.Add(pro);
            con.SaveChanges();
        }
        public static void borrar_producto(Producto pro)
        {
            con.Borrar_Producto(pro.Bar_code);
            //var customer = con.Producto.Single(o => o.Bar_code == pro.Bar_code);
            //con.Producto.Remove(customer);
            con.SaveChanges();
        }

        public static Producto editar_producto(Producto pro)
        {
            var customer = con.Producto.Single(o => o.Bar_code == pro.Bar_code);

            Producto producto = con.Producto.Find(customer.Bar_code);

            if (pro.Nombre != "") { producto.Nombre = pro.Nombre; }

            if (pro.Costo != 0) { producto.Costo = pro.Costo; }

            if (pro.Descripcion != "") { producto.Descripcion = pro.Descripcion; }
            con.Actualizar_Producto(pro.Bar_code, pro.ID_servicio, pro.Nombre, pro.Costo, pro.Descripcion);
            con.SaveChanges();
            return producto;
        }

        public static Producto consultar_producto(Producto pro)
        {
            var customer = con.Producto.Single(o => o.Bar_code == pro.Bar_code);
            Producto producto = con.Producto.Find(customer.Bar_code);
            return producto;
        }
    }
}