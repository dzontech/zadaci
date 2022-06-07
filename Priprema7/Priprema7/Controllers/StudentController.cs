using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priprema7.Controllers
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

		[HttpPost("insert")]
		public bool Insert(Student s)
		{
			return this.studentBusiness.Insert(s);
		}

		[HttpPut("update/{id}")]
		public bool Update (StudentDTO s, int id)
		{
			return this.studentBusiness.Update(s, id);
		}

		[HttpGet("getall/{index}")]
		public Student ShowByIndex(string index)
		{
			return this.studentBusiness.ShowByIndex(index);
		}


		
	}
}
