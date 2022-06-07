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
		bool InsertStudent(Student s);
		bool UpdateStudent(Student s, int id);

		Student ShowStudent(string index_number);
	}
}
