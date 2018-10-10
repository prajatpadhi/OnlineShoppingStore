using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Concrete
{
    public interface IStudentRepository
    {
        void CreateStudent(StudentViewModel student);
        void DeleteStudent(int id);
        void EditStudent(StudentViewModel student);
        IEnumerable<StudentViewModel> GetAllStudents();
        StudentViewModel GetStudentById(int id);
    }
}