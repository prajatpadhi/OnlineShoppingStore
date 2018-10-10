using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFrameworkCodeFirst.Model;

namespace EntityFrameworkCodeFirst.Concrete
{
    class StudentContext: DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Student> Grades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().MapToStoredProcedures(p => p.Insert(sp => sp.HasName("").Parameter(pa => pa.StudentName, "name").Result(r => r.StudentID, "StudentId"))
                                                                     .Update(sp => sp.HasName("").Parameter(pa => pa.StudentName, "name"))
                                                                     .Delete(sp => sp.HasName("").Parameter(pa => pa.StudentName, "name")));
        }


    }

    
}
