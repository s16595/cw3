using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Model;

namespace WebApplication3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student{ IdStudent=1, FirstName="Jan", LastName="Kowalski", IndexNumber="s0001"},
                new Student{ IdStudent=1, FirstName="Anna", LastName="Malewska", IndexNumber="s0002"},
                new Student{ IdStudent=1, FirstName="Andrzej", LastName="Nowak", IndexNumber="s0003"}
            };

        }

        public void createStudent(Student student)
        {
            _students.Append(student);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public IEnumerable<Enrollment> GetStudentsSemestr(string id)
        {
            throw new NotImplementedException();
        }

        public void removeId(int id)
        {
            Student toRemove = null;
            foreach(Student s in _students)
            {
                if (s.IdStudent == id)
                {
                    toRemove = s;
                }
            }

            var list = _students.ToList();
            list.Remove(toRemove);
            _students = list;
        }

        public void updateStudent(int id, Student student)
        {
            removeId(id);
            _students.Append(student);
        }
    }
}
