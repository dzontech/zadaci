using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priprema4.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private IStudentBusiness studentBusiness;

		public StudentController(IStudentBusiness studentBusiness)
		{
			this.studentBusiness = studentBusiness;
		}

		[HttpGet("getall")]
		public List<Student> GetStudents()
		{
			return this.studentBusiness.GetStudents();
		}

		[HttpGet("get/{index_number}")]
		public Student ShowStudent(string index_number)
		{
			return this.studentBusiness.ShowStudent(index_number);
		}

		[HttpPost("insert")]
		public bool InsertStudent(Student s)
		{
			return this.studentBusiness.InsertStudent(s);
		}

		[HttpPut("update/{id}")]
		public bool UpdateStudent(Student s, int id)
		{
			return this.studentBusiness.UpdateStudent(s, id);
		}
	}
}
