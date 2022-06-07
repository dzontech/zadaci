using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
	public class ProductRepo : IProductRepo
	{
		private string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		public int Delete(int id)
		{
			using(SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();
				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "DELETE FROM Products WHERE Id =" + id;

				return comm.ExecuteNonQuery();
			}
		}

		public List<Product> GetProducts()
		{
			List<Product> list = new List<Product>();
			using (SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();
				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "SELECT * FROM Products";

				SqlDataReader dataReader = comm.ExecuteReader();

				while(dataReader.Read())
				{
					Product p = new Product();
					p.Id = dataReader.GetInt32(0);
					p.Name = dataReader.GetString(1);
					p.Description = dataReader.GetString(2);
					p.Price = dataReader.GetDecimal(3);
					list.Add(p);
				}
			}
			return list;

		}

		public int Insert(Product p)
		{
			using (SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();
				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "INSERT INTO Products VALUES(" +
					"'" + p.Name + "'," +
					"'" + p.Description + "'," +
					"'" + p.Price + "')";

				return comm.ExecuteNonQuery();
			}
		}
	}
}
