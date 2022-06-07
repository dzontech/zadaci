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

			using(SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "SELECT * FROM Books";

				SqlDataReader dataReader = comm.ExecuteReader();

				while(dataReader.Read())
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

		public int InsertBook(Book book)
		{
			using(SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "INSERT INTO Books VALUES (" +
					"'" + book.Name + "'" + "," +
					"'" + book.ISBN + "'" + "," +
					"'" + book.Genre + "'" + ")";

				return comm.ExecuteNonQuery();
			}
		}

		public int UpdateBook(Book book, int id)
		{
			
			using (SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();

				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "UPDATE Books SET " +
				" Name = " + "'" + book.Name + "'" + "," +
				" ISBN = " + "'" + book.ISBN + "'" + "," +
				" Genre = " + "'" + book.Genre + "'" +  
				" WHERE Id = " + id;

				return comm.ExecuteNonQuery();
			}
		}

		


	}
}
