﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GymTECEntities : DbContext
    {
        public GymTECEntities()
            : base("name=GymTECEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clase> Clase { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Maquina> Maquina { get; set; }
        public virtual DbSet<Numeros_sucursal> Numeros_sucursal { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Puesto> Puesto { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<Tipo_equipo> Tipo_equipo { get; set; }
        public virtual DbSet<Tipo_planilla> Tipo_planilla { get; set; }
        public virtual DbSet<Tipos_planillas_empleados> Tipos_planillas_empleados { get; set; }
        public virtual DbSet<Tratamiento> Tratamiento { get; set; }
    }
}
