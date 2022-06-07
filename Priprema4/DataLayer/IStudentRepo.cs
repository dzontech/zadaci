using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface IStudentRepo
	{
		List<Student> GetStudents();
		int InsertStudent(Student s);
		int UpdateStudent(Student s, int id);

	}
}
