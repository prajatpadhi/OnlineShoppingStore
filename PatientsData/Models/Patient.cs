using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace PatientsData.Models
{
    public class Patient
    {
        [BsonElement("_Id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public String Id { get; set; }
        public String Name { get; set; }
        public ICollection<Ailment>  Ailments { get; set; }
        public ICollection<Medication> Medications { get; set; }

    }

    public class Ailment
    {
        public int Id { get; set; }
        public String Name { get; set; }

    }

    public class Medication
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Doses { get; set; }

    }
}