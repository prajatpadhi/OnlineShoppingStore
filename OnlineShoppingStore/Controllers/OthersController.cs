using OnlineShoppingStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.Concrete;

namespace OnlineShoppingStore.Controllers
{
    [Authorize]
    public class OthersController : Controller
    {


        public List<Student> Students = new List<Student>()
                {
                    new Student(){ FirstName="Prajat",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="sgbsdba",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="Praafsfvsjat",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="Pbdghdg",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="bdgdgh",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="cdhbdh",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="dhbdfhd",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="edfdhd",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="fsgvsgb",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="ggsrhgs",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="hgsdghghs",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="idbsdzbs",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="jbshbs",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="kvbsdbs",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="lfdfhd",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="mfndfn",LastName="Padhi",RollNo=1},
                    new Student(){ FirstName="ndbdfbd",LastName="Padhi",RollNo=1},

                };
        // GET: Others
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CustomValidation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomValidation(CustomValidationStudent s)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Your data entry was successful";
                return View();
            }

            else
            {
                ViewBag.Message = "Your data entry was not successful";
                return View();
            }
        }

        [HttpGet]
        public ActionResult SecondCustomValidation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SecondCustomValidation(SecondCustomValidationStudent s)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Your data entry was successful";
                return View();
            }

            else
            {
                ViewBag.Message = "Your data entry was not successful";
                return View();
            }
        }


        [HttpGet]
        public ActionResult AsyncSearch(String SearchTerm)
        {
            
              var students = Students
                          .Where(p => SearchTerm == null || p.FirstName.StartsWith(SearchTerm))
                          .OrderBy(p => p.FirstName);


            return View(students);
        }

        [HttpPost]
        public ActionResult AsyncSearch(SecondCustomValidationStudent s)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Your data entry was successful";
                return View();
            }

            else
            {
                ViewBag.Message = "Your data entry was not successful";
                return View();
            }
        }
    }
}