using MongoDB.Driver;
using PatientsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientsData.Controllers
{
    [Authorize]
    public class PatientsController : ApiController
    {
        IMongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }

        public IHttpActionResult Get()
        {
            //return Ok(_patients.Find(_ => true).ToList());
            return Ok(_patients.AsQueryable<Patient>().ToList());
        }

        public IHttpActionResult Get(string id)
        {
            var patient =  _patients.AsQueryable<Patient>().ToList().Find(p=> p.Id==id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }
        [Route("api/patients/{id}/medications")]
        public IHttpActionResult GetMedication(string id)
        {
            var patient = _patients.AsQueryable<Patient>().ToList().Find(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient.Medications);
        }
    }
}
