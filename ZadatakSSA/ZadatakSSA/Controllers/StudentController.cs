using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZadatakSSA.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]

    public class StudentController : ControllerBase
    {
        private IStudentBusiness studentBusiness;

        public StudentController(IStudentBusiness studentBusiness)
        {
            this.studentBusiness = studentBusiness;
            this.studentBusiness.GetConnectionString(Startup.ConnectionString);
        }

     
        [HttpGet]
        public List<Student> GetAllStudents()
        {
            return this.studentBusiness.GetAllStudents();
        }

     
        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            return this.studentBusiness.GetStudentById(id);
        }

     

        [Route("insert")]
        [HttpPost]
        public bool InsertStudent([FromBody] Student s)
        {
            return this.studentBusiness.InsertStudent(s);
        }

      

        [Route("insert-list")]
        [HttpPost]
        public bool InsertStudents([FromBody] List<Student> students)
        {
            return this.studentBusiness.InsertListOfStudents(students);
        }

        
        [Route("update")]
        [HttpPut]
        public bool UpdateStudent([FromBody] Student s)
        {
            return this.studentBusiness.UpdateStudent(s);
        }


        
        [HttpDelete("{id}")]
        public bool DeleteStudent(int id)
        {
            return this.studentBusiness.DeleteStudent(id);
        }

        
        [HttpGet("index_of_number")]

        public JsonResult Select_student(string index_of_number)
        {
            return this.studentBusiness.Select_student_evaluate(index_of_number);
        }


    }



}
