using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
	public class PatientRepo : IPatientRepo
	{
		private string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PolyclinicDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		public List<Patient> GetPatients()
		{
			List<Patient> list = new List<Patient>();

			using(SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "SELECT * FROM Patients";

				SqlDataReader dataReader = comm.ExecuteReader();

				while(dataReader.Read())
				{
					Patient p = new Patient();
					p.Id = dataReader.GetInt32(0);
					p.Name = dataReader.GetString(1);
					p.LBO = dataReader.GetString(2);
					p.Gender = dataReader.GetString(3);

					list.Add(p);
				}
			}
			return list;
		}

		public int InsertPatient(Patient p)
		{
			using (SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "INSERT INTO Patients VALUES (" +
					"'" + p.Name + "'," +
					"'" + p.LBO + "'," +
					"'" + p.Gender + "')";

				return comm.ExecuteNonQuery();
			}
		}

		public int UpdatePatient(UpdatePatientDto p, int id)
		{
			using (SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "UPDATE Patients SET " +
					"Name = " + "'" + p.Name + "'," +
					"LBO = " + "'" + p.LBO + "'," +
					"Gender = " + "'" + p.Gender + "'" +
					"WHERE Id = " + id;

				return comm.ExecuteNonQuery();
			}
		}

		public int Delete(int id)
		{
			using (SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "DELETE FROM Patients WHERE Id = " + id;

				return comm.ExecuteNonQuery();
			}
		}
	}
}
