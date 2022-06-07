using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer
{
    public interface IStudentRepository
    {
        void GetConnectionString(string connString);
        List<Student> GetAllStudents();

        int InsertStudent(Student s);

        int UpdateStudent(Student s);

        int DeleteStudent(int id);

        JsonResult Select_student_evaluate(string index_of_number);
    }
}
