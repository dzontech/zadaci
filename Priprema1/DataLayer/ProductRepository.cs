using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer
{
	public class ProductRepository : IProductRepository
	{
		private string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public List<Product> GetAllProducts()
		{
			List<Product> list = new List<Product>();

			using(SqlConnection connection = new SqlConnection(this.conn))
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
					p.Desc = dataReader.GetString(2);
					p.Price = dataReader.GetDecimal(3);

					list.Add(p);
				}

			}

			return list;
		}

		public int InsertProduct(Product product)
		{
			using(SqlConnection connection = new SqlConnection(this.conn))
			{
				connection.Open();
				SqlCommand comm = new SqlCommand();
				comm.Connection = connection;
				comm.CommandText = "INSERT INTO Products VALUES ( " +
					"'" + product.Name + "'" + "," +
					"'" + product.Desc + "'" + "," +
					 +product.Price + ")";

				return comm.ExecuteNonQuery();
			}
		}
	}
}
