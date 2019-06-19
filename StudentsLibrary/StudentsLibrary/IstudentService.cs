using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace StudentsLibrary
{
    [ServiceContract]
    interface IstudentService
    {
        [OperationContract]
        Student[] GetStudent();

        [OperationContract]
        Student GetStudentById();

        [OperationContract]
        Student CreateStudent();

        [OperationContract]
        void UpdateSudent();

        [OperationContract]
        void DeleteStudent();
    }
}
