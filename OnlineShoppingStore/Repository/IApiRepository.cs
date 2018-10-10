using OnlineShoppingStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Repository
{
    interface IApiRepository
    {
        List<Student> getStudents();
        Student getStudentById(long id);
        Student deleteStudent(long id);
        Student editStudent(long id);

    }
}
