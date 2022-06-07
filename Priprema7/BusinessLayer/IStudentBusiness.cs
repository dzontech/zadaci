using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public interface IStudentBusiness
	{
		List<Student> GetStudents();
		bool Insert(Student s);
		bool Update(StudentDTO s, int id);
		Student ShowByIndex(string index);
	}
}
