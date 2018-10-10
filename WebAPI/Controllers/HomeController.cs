using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<StudentViewModel> students = null;

            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2659/api/");
                var responseTask = client.GetAsync("student");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<StudentViewModel>>();
                    readTask.Wait();
                    students = readTask.Result;

                }

                else
                {
                    ModelState.AddModelError("error","There was a error");
                }

            }

                return View(students);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2659/api/");
                var responseTask = client.PostAsJsonAsync("student",student);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }

                else
                {
                    ModelState.AddModelError("error", "There was a error");
                }

            }

            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentViewModel student = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2659/api/");
                var responseTask = client.GetAsync("student?id="+ id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StudentViewModel>();
                    readTask.Wait();
                    student = readTask.Result;

                }

                else
                {
                    ModelState.AddModelError("error", "There was a error");
                }

            }
            return View(student);
        }


        [HttpPost]
        public ActionResult Edit(StudentViewModel student)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2659/api/");
                var responseTask = client.PutAsJsonAsync("student", student);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }

                else
                {
                    ModelState.AddModelError("error", "There was a error");
                }

            }

            return View();
        }

        
        public ActionResult Delete(int id)
        {
            

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2659/api/");
                var responseTask = client.DeleteAsync("student?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }

                else
                {
                    ModelState.AddModelError("error", "There was a error");
                }

            }
            return RedirectToAction("Index");
        }

    }
}
