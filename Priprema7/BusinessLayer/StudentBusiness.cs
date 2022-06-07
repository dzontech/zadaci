using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
	public class StudentBusiness : IStudentBusiness
	{
		private IStudentRepo studentRepo;

		public StudentBusiness(IStudentRepo studentRepo)
		{
			this.studentRepo = studentRepo;
		}

		public List<Student> GetStudents()
		{
			List<Student> list = this.studentRepo.GetStudents();
			if (list.Count > 0)
				return list;
			else
				return null;
		}

		public bool Insert(Student s)
		{
			if (this.studentRepo.Insert(s) > 0)
				return true;
			else
				return false;
		}

		public Student ShowByIndex(string index)
		{
			List<Student> list = this.GetStudents();
			return list.Find(i => i.Index_number.Equals(index));
		}

		public bool Update(StudentDTO s, int id)
		{ 
			bool r = false;
			if (id != 0 && this.studentRepo.Update(s, id) > 0)
				r = true;
			return r;
		}
	}
}
