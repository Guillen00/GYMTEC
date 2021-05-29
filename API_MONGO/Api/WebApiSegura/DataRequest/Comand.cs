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

        public static string Borrar(Cliente cliente)
        {
            //error
            var db = server.GetDatabase("GymTEC");
            var collection = db.GetCollection<Cliente>("Cliente");

            var Cliente_nuevo = cliente;

            string update = "{'_id': " + cliente.Id + ", 'Nombre' : '"+cliente.Nombre + "', 'Apellido' : '" + cliente.Apellido + "', 'Apellido2' : '" + cliente.Apellido2 + ", 'Cedula' : " + cliente.Cedula+ ", 'Direccion' : '" + cliente.Direccion + "', 'Correo' : '" + cliente.Correo + "', 'Password' : '" + cliente.Password + "', 'IMC' : " + cliente.IMC + ", 'Peso' : " + cliente.Peso + ", 'Fecha_Nacimiento' : " + cliente.Fecha_Nacimiento.ToString() + ", 'Edad' : " + cliente.Edad + "}";
            string filtro = "{'Cedula': "+cliente.Cedula +"}";
            BsonDocument filtroDoc = BsonDocument.Parse(filtro);
            BsonDocument document = BsonDocument.Parse(update);
            collection.Update((IMongoQuery)filtroDoc,(IMongoUpdate)document);
            return ("Borrado");

        }

    }
}