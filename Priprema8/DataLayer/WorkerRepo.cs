using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
	public class WorkerRepo : IWorkerRepo
	{
		private string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FactoryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		public List<Worker> GetWorkers()
		{
			List<Worker> list = new List<Worker>();

			using(SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "SELECT * FROM Workers";

				SqlDataReader dataReader = comm.ExecuteReader();

				while(dataReader.Read())
				{
					Worker w = new Worker();
					w.Id = dataReader.GetInt32(0);
					w.Name = dataReader.GetString(1);
					w.Profession = dataReader.GetString(2);
					w.Salary = dataReader.GetDecimal(3);
					list.Add(w);


				}
			}
			return list;
		}

		public int Insert(Worker w)
		{
			using(SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "INSERT INTO Workers VALUES(" +
					"'" + w.Name + "'," +
					"'" + w.Profession + "'," +
					"'" + w.Salary + "')";

				return comm.ExecuteNonQuery();
			}
		}
	}
}
