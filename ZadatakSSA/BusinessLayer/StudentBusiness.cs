using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer
{
    public class StudentBusiness : IStudentBusiness
    {
        private IStudentRepository studentRepository;

        public StudentBusiness(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public void GetConnectionString(string connString)
        {
            this.studentRepository.GetConnectionString(connString);
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = this.studentRepository.GetAllStudents();
            if (students.Count > 0)
            {
                return students;
            }
            else
            {
                return null;
            }
        }

        public Student GetStudentById(int Id)
        {
            List<Student> students = this.studentRepository.GetAllStudents();

            if (students.Count > 0)
            {
                return students.Find(s => s.Id == Id);
            }
            else
            {
                return null;
            }
        }

        public bool InsertStudent(Student s)
        {
            if (this.studentRepository.InsertStudent(s) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    
        public bool InsertListOfStudents(List<Student> students)
        {
            bool result = true; 
            foreach (Student s in students)
            {
              
                if (this.studentRepository.InsertStudent(s) <= 0)
                {
                  
                    result = false;
                }
            }
            return result;
        }

     
        public bool UpdateStudent(Student s)
        {
            bool result = false; 
            if (s.Id != 0 && this.studentRepository.UpdateStudent(s) > 0)
            {
             
                result = true;
            }
            return result;
        }

    
        public bool DeleteStudent(int id)
        {
            bool result = false; 
            if (id != 0 && this.studentRepository.DeleteStudent(id) > 0)
            {
              
                result = true;
            }
            return result;
        }

        public JsonResult Select_student_evaluate(string index_of_number)
        {
            return this.studentRepository.Select_student_evaluate(index_of_number);
        }

    }
}
