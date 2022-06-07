using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public interface IProductBusiness
	{
		List<Product> GetProducts();
		bool Insert(Product p);
		bool Delete(int id);
		List<Product> GetProductByPrice(decimal maxprice, decimal minprice);
	}
}
