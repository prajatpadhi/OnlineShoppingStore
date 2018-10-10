using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using WebAPI.Concrete;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [KnownType(typeof(Student))]
    public class StudentController : ApiController
    {
        // GET api/values
        IStudentRepository repository = new StudentRepository();

        public StudentController(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public IHttpActionResult GetAllStudents()
        {
            var students = repository.GetAllStudents();


            if (students.Count() == 0)
            {
                return NotFound();
            }

            else return Ok(students);
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var student = repository.GetStudentById(id);


            if (student == null)
            {
                return NotFound();
            }

            else return Ok(student);
        }

        // POST api/values
        public IHttpActionResult Post(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repository.CreateStudent(student);
            return Ok();

        }

        // PUT api/values/5
        public IHttpActionResult Put(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repository.EditStudent(student);
            return Ok();
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repository.DeleteStudent(id);
            return Ok();

        }

        public IEnumerable<String> Delete(string name)
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;
            List<String> format = new List<string>();
            foreach (var f in formatters)
            {
                format.Add(f.ToString());
            }
            return format.AsEnumerable<String>();
        }

        
    }
}
