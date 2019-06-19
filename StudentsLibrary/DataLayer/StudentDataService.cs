using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StudentDataService
    {
        private List<Student> Students;

        public StudentDataService()
        {
            this.Students = new List<Student>();
            SeedData();
        }

        private void SeedData()
        {
            Student std = new Student();
            std.StudentId = 1;
            std.Name = "Aram";
            std.Age = 20;
            this.Students.Add(std);
        }

        public List<Student> GetStudents()
        {
            return this.Students;
        }

    }
}
