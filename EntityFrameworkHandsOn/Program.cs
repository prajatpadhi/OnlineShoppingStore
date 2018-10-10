using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkHandsOn;

namespace EntityFrameworkHandsOn
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context=new SchoolDBEntities() )
            {
                var stud1 = context.Students.Where(s => s.StudentName == "Bill").FirstOrDefault();



                var a = context.Entry(stud1).Collection("Courses").Name;
            }
        }
    }
}
