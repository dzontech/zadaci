using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer
{
    public interface IStudentBusiness
    {
        void GetConnectionString(string connString);

        Student GetStudentById(int Id);
        List<Student> GetAllStudents();

        bool InsertStudent(Student s);

        bool InsertListOfStudents(List<Student> students);


        bool UpdateStudent(Student s);

        bool DeleteStudent(int id);

      
        JsonResult Select_student_evaluate(string index_of_number);

    }
}
