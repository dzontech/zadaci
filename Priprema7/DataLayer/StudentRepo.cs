using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
	public class StudentRepo : IStudentRepo
	{
		private string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FacultyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		public List<Student> GetStudents()
		{
			List<Student> list = new List<Student>();

			using (SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "SELECT * FROM Students";

				SqlDataReader dataReader = comm.ExecuteReader();

				while (dataReader.Read())
				{
					Student s = new Student();
					s.Id = dataReader.GetInt32(0);
					s.Name = dataReader.GetString(1);
					s.Index_number = dataReader.GetString(2);
					s.Course = dataReader.GetString(3);

					list.Add(s);
				}
			}
			return list;
		}

		public int Insert(Student s)
		{
			using (SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "INSERT INTO Students VALUES(" +
					"'" + s.Name + "'," +
					"'" + s.Index_number + "'," +
					"'" + s.Course + "')";

				return comm.ExecuteNonQuery();
			}
		}

		public int Update(StudentDTO s, int id)
		{
			using (SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "UPDATE Students SET " +
					"Name = " + "'" + s.Name + "'," +
					"Index_number = " + "'" + s.Index_number + "'," +
					"Course = " + "'" + s.Course + "'" +
					"WHERE Id = " + id;

				return comm.ExecuteNonQuery();
			}
		}
	}
}
	

