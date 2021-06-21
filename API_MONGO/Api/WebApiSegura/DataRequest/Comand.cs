using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Builders;

namespace Proyecto2.DataRequest
{
    /*
     *  En esta clase se creara la conexion a la base de datos den mongodb y ademas se crearan las diferentes peticoiones a la base, relacionados a la variable 
     *  que contiene la infromacion de la base de datos
     */
    public static class BD_Mongo_Conection
    {


        /*
         * Se crean las variables necesarias para la coneccion de la base de datos y en la funcion contructora inicializa la variable con una ruta a la cual se le 
         * realizaran las peticiones 
         */
        private static MongoServer server;
        private static string database { get; set; }
        public static void MongoDataService()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");

            server = client.GetServer();

        }
        /*
         * Esta funcion realiza una insercion a la collecion cliente 
         */
        public static string Insertar(Cliente cliente)
        {
            var db = server.GetDatabase("GymTEC");
            var collection = db.GetCollection<Cliente>("Cliente");

            var Cliente_nuevo = cliente;
            collection.Insert(Cliente_nuevo);
            return ("Insertado");

        }
        /*
         * Esta funcion hace una peticion sobre todos los clientes almacenados
         */
        public static List<Cliente> Consultar_todos()
        {
            var db = server.GetDatabase("GymTEC");
            var collection = db.GetCollection<Cliente>("Cliente");
            List<Cliente> lista = collection.FindAll().ToList<Cliente>();
            return (lista);

        }
        /*
         * Esta funcion busca la informacion sobre un cliente relacionado a un correo electronico
         */
        public static List<Cliente> Consultar_correo(Cliente cliente)
        {
            var db = server.GetDatabase("GymTEC");
            var collection = db.GetCollection<Cliente>("Cliente");
            var query = Query<Cliente>.EQ(e => e.Correo, cliente.Correo);
            List<Cliente> resultado = collection.Find(query).ToList<Cliente>();
            return (resultado);

        }
        /*
         * Esta funcion edita los datos de un cliente , tomando como referencia el numero de cedula de este 
         */
        public static string Editar(Cliente cliente)
        {
            //error
            var db = server.GetDatabase("GymTEC");
            var collection = db.GetCollection<Cliente>("Cliente");
            

            var Cliente_nuevo = cliente;
            var query2 = Query<Cliente>.EQ(e => e.Correo, cliente.Correo);
            List<Cliente> lista = collection.Find(query2).ToList<Cliente>();
         
            var filter = Builders<Cliente>.Filter.Eq(s => s.Cedula, cliente.Cedula);
            
            cliente.Id = lista[0].Id;
            var query = Query<Cliente>.EQ(e => e.Cedula, cliente.Cedula);
            collection.Update(query,Update.Replace(cliente));
            
            return ("Editado");

        }

        /*
         * Esta funcion borra un cliente relacionado a un numero de cedula
         */
        public static string Borrar(Cliente cliente)
        {
            //error
            var db = server.GetDatabase("GymTEC");
            var collection = db.GetCollection<Cliente>("Cliente");

            var query = Query<Cliente>.EQ(e => e.Cedula, cliente.Cedula);
            collection.Remove(query);
            return ("Cliente Borrado");

        }

    }
}