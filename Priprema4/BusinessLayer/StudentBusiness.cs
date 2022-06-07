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

		public bool InsertStudent(Student s)
		{
			if (this.studentRepo.InsertStudent(s) > 0)
				return true;
			else
				return false;
		}

		public Student ShowStudent(string index_number)
		{
			List<Student> list = this.studentRepo.GetStudents();
			return list.Find(s => s.Index_number.Equals(index_number));
		}

		public bool UpdateStudent(Student s, int id)
		{
			bool r = false;
			if (s.Id != 0 && this.studentRepo.UpdateStudent(s, id) > 0)
				r = true;
			return r;
		}
	}
}
