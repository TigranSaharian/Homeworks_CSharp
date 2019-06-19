using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace StudentsLibrary
{
    public class StudentService : IstudentService
    {
        private StudentDataService studentDataService;

        public Student CreateStudent()
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent()
        {
            throw new NotImplementedException();
        }

        public Student[] GetStudent()
        {
            this.studentDataService = new StudentDataService();
            return this.studentDataService.GetStudents().ToArray();
        }

        public Student GetStudentById()
        {
            throw new NotImplementedException();
        }

        public void UpdateSudent()
        {
            throw new NotImplementedException();
        }
    }
}
