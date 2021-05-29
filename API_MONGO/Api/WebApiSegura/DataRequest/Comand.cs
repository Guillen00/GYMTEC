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
     *  
     */
    public static class BD_Mongo_Conection
    {



        private static MongoServer server;
        private static string database { get; set; }
        public static void MongoDataService()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");

            server = client.GetServer();

        }

        public static string Insertar(Cliente cliente)
        {
            var db = server.GetDatabase("GymTEC");
            var collection = db.GetCollection<Cliente>("Cliente");

            var Cliente_nuevo = cliente;
            collection.Insert(Cliente_nuevo);
            return ("Insertado");

        }

        public static List<Cliente> Consultar_todos()
        {
            var db = server.GetDatabase("GymTEC");
            var collection = db.GetCollection<Cliente>("Cliente");
            List<Cliente> lista = collection.FindAll().ToList<Cliente>();
            return (lista);

        }
        public static MongoCursor<Cliente> Consultar_correo(Cliente cliente)
        {
            var db = server.GetDatabase("GymTEC");
            var collection = db.GetCollection<Cliente>("Cliente");
            var query = Query<Cliente>.EQ(e => e.Correo, cliente.Correo);
            
            return (collection.Find(query));

        }

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