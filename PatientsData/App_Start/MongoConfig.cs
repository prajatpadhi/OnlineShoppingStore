using PatientsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace PatientsData.App_Start
{
    public static class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientDb.Open();

            if (!patients.AsQueryable().Any(p => p.Name == "Prajat"))
            {
                var data = new List<Patient>()
                {
                    new Patient(){ Name="Rajat" , Ailments=new List<Ailment>()
                    {new Ailment(){ Name="gastro"},new Ailment(){ Name="sex"} },
                    Medications=new List<Medication>(){ new Medication() { Name= "juiefcjhb", Doses=2 },
                        new Medication(){ Name="jfljslvjk", Doses=3}
                    } },
                    new Patient(){ Name="Prajat" , Ailments=new List<Ailment>()
                    {new Ailment(){ Name="gastro"},new Ailment(){ Name="sex"} },
                    Medications=new List<Medication>(){ new Medication() { Name= "juiefcjhb", Doses=2 },
                        new Medication(){ Name="jfljslvjk", Doses=3}
                    } },

                    new Patient(){ Name="efwfwf" , Ailments=new List<Ailment>()
                    {new Ailment(){ Name="gastro"},new Ailment(){ Name="sex"} },
                    Medications=new List<Medication>(){ new Medication() { Name= "juiefcjhb", Doses=2 },
                        new Medication(){ Name="jfljslvjk", Doses=3}
                    } }

                };

                patients.InsertMany(data);
            }
        }
    }
}