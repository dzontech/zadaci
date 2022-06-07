using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
	public class BookRepo : IBookRepo
	{
		private string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		public List<Book> GetBooks()
		{
			List<Book> list = new List<Book>();
			using (SqlConnection connection = new SqlConnection(this.conn))
			{

				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "SELECT * FROM Books";

				SqlDataReader dataReader = comm.ExecuteReader();

				while (dataReader.Read())
				{
					Book b = new Book();
					b.Id = dataReader.GetInt32(0);
					b.Name = dataReader.GetString(1);
					b.ISBN = dataReader.GetString(2);
					b.Genre = dataReader.GetString(3);
					list.Add(b);
				}


			}
			return list;
		}

		public int Insert(Book b)
		{
			using (SqlConnection connection = new SqlConnection(conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "INSERT INTO Books VALUES(" +
					"'" + b.Name + "'," +
					"'" + b.ISBN + "'," +
					"'" + b.Genre + "')";


				return comm.ExecuteNonQuery();
			}
		}

		public int Update(BookDTO b, int id)
		{

			using (SqlConnection connection = new SqlConnection(conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "UPDATE Books SET " +
					"Name = " + "'" + b.Name + "'," +
					"ISBN = " + "'" + b.ISBN + "'," +
					"Genre = " + "'" + b.Genre + "'" +
					"WHERE Id = " + id;

				return comm.ExecuteNonQuery();
			}
		}
	}
}
