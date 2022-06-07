using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface IProductRepo
	{
		List<Product> GetProducts();
		int Insert(Product p);
		int Delete(int id);
	}
}
