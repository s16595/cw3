using System;
using System.IO;
using System.Collections.Generic;
using WebApplication3.Model;
using System.Data.SqlClient;


namespace WebApplication3.DAL
{
    public class DBController : IDbService
    {

        static string DBPath = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\conta\\source\\repos\\Zad3\\WebApplication3\\DBFile.mdf;Integrated Security=True;Connect Timeout=30";
        public void createStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudents()
        {
            List<Student> students = new List<Student> { };
            using (var client = new SqlConnection(DBPath))
            using (var com= new SqlCommand())
            {
                com.Connection = client;
                client.Open();
                com.CommandText = "SELECT * FROM dbo.Student";
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.IndexNumber = dr["IndexNumber"].ToString();

                    students.Add(st);
                }
                    
            }

            return students;
        }


        public IEnumerable<Enrollment> GetStudentsSemestr(String index)
        {
            List<Enrollment> enrollments = new List<Enrollment> { };
            using (var client = new SqlConnection(DBPath))
            using (var com = new SqlCommand())
            {
                com.Connection = client;
                client.Open();
                //com.CommandText = "SELECT e.* FROM dbo.Student s INNER JOIN dbo.Enrollment e ON s.IdEnrollment = e.IdEnrollment WHERE s.IndexNumber = " + index ;
                com.CommandText = "SELECT e.* FROM dbo.Student s INNER JOIN dbo.Enrollment e ON s.IdEnrollment = e.IdEnrollment WHERE s.IndexNumber = @id";
                com.Parameters.AddWithValue("id", index);
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Enrollment();
                    st.IdStudy = Int32.Parse(dr["IdStudy"].ToString());
                    st.Semester = Int32.Parse(dr["Semeester"].ToString());
                    st.IdEnrollment = Int32.Parse(dr["IdEnrollment"].ToString());
                    st.StartDate = dr["StartDate"].ToString();

                    enrollments.Add(st);
                }

            }

            return enrollments;
        }

        public void removeId(int id)
        {
            throw new NotImplementedException();
        }

        public void updateStudent(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
