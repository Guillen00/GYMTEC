using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/*En este archivo .cs se manejaran todas las clases a utilizar para el manejo de datos, sea en tablas o para la creacion de JSON, tambien para manejar datos que
 * son necesarios para los reportes y diferentes funcionalidades
 * 
 * 
 */
namespace Proyecto2.DataRequest
{
    /*
     * Esta clase maneja la informacion de todos los dispositivos, se puede almacenar temporalmente y transportar la informacion
     */
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Nombre")]
        public string Nombre { get; set; }
        [BsonElement("Apellido")]
        public string Apellido { get; set; }
        [BsonElement("Apellido2")]
        public string Apellido2 { get; set; }
        [BsonElement("Cedula")]
        public int Cedula { get; set; }
        [BsonElement("Direccion")]
        public string Direccion { get; set; }
        [BsonElement("Correo")]
        public string Correo { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
        [BsonElement("IMC")]
        public int IMC { get; set; }
        [BsonElement("Peso")]
        public int Peso { get; set; }
        [BsonElement("Fecha_Nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }
        [BsonElement("Edad")]
        public int Edad { get; set; }

    }

}