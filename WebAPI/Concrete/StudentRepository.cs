using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
namespace WebAPI.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        SchoolDBEntities context = new SchoolDBEntities();

        public IEnumerable<StudentViewModel> GetAllStudents()
        {
            context.Configuration.LazyLoadingEnabled = false;
            var students = context.Students.Include("StudentAddress").Select(s => new StudentViewModel
            {
                StudentName = s.StudentName,
                StudentID = s.StudentID,
                StandardId = s.StandardId,
                Address = new AddressViewModel
                {
                    Address1 = s.StudentAddress.Address1,
                    Address2 = s.StudentAddress.Address2,
                    City = s.StudentAddress.City,
                    State = s.StudentAddress.State
                },
                Standard = new StandardViewModel
                {
                    StandardName = s.Standard.StandardName,
                    Description=s.Standard.Description
                }
            }).ToList();
           
            return students;
        }

        public StudentViewModel GetStudentById(int id)
        {
            context.Configuration.LazyLoadingEnabled = false;
            var student = context.Students.Include("StudentAddress").Where(s=>s.StudentID==id).Select(s => new StudentViewModel
            {
                StudentName = s.StudentName,
                StudentID = s.StudentID,
                Address = new AddressViewModel
                {
                    Address1 = s.StudentAddress.Address1,
                    Address2 = s.StudentAddress.Address2,
                    City = s.StudentAddress.City,
                    State = s.StudentAddress.State
                },
                Standard = new StandardViewModel
                {
                    StandardName = s.Standard.StandardName,
                    Description = s.Standard.Description
                },


                StandardId = s.StandardId
            }).FirstOrDefault();

            return student;
        }

        public void CreateStudent(StudentViewModel student)
        {
            var Student = new Student()
            {
                StudentName = student.StudentName,
                Standard = new Standard() { StandardName = student.Standard.StandardName },
                StudentAddress = new StudentAddress()
                {
                    Address1 = student.Address.Address1,
                    Address2 = student.Address.Address2,
                    City = student.Address.City,
                    State = student.Address.State
                }

            };

            context.Students.Add(Student);
            context.SaveChanges();
        }


        public void EditStudent(StudentViewModel student)
        {
            Student estudent = context.Students.Where(s => s.StudentID == student.StudentID).FirstOrDefault();

            estudent.StudentName = student.StudentName;
            estudent.Standard.StandardName = student.Standard.StandardName;
            estudent.StudentAddress = new StudentAddress()
            {
                Address1 = student.Address.Address1,
                Address2 = student.Address.Address2,
                City = student.Address.City,
                State = student.Address.State
            };
            

            
            context.SaveChanges();
        }


        public void DeleteStudent(int id)
        {
            Student estudent = context.Students.Where(s => s.StudentID == id).FirstOrDefault();

            context.Students.Remove(estudent);
            context.SaveChanges();
        }
    }
}