using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Model;

namespace WebApplication3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();

        public void removeId(int id);
        public void createStudent(Student student);

        public void updateStudent(int id, Student student);
    }
}
