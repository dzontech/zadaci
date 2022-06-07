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
		List<Product> GetAllProducts();
		bool InsertProduct(Product product);

		List<Product> MinMaxPrice(int minPrice, int maxPrice);
	}
}
