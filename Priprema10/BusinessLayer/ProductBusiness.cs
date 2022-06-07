using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
	public class ProductBusiness : IProductBusiness
	{
		private IProductRepo productRepo;

		public ProductBusiness(IProductRepo productRepo)
		{
			this.productRepo = productRepo;
		}

		public bool Delete(int id)
		{
			bool r = false;
			if (id != 0 && this.productRepo.Delete(id) > 0)
				r = true;
			return r;
		}

		public List<Product> GetProductByPrice(decimal maxprice, decimal minprice)
		{
			List<Product> list = this.productRepo.GetProducts();
			return list.FindAll(p => p.Price < maxprice && p.Price > minprice);
		}

		public List<Product> GetProducts()
		{
			List<Product> list = this.productRepo.GetProducts();
			if (list.Count > 0)
				return list;
			else
				return null;
		}

		public bool Insert(Product p)
		{
			if (this.productRepo.Insert(p)>0)
				return true;
			else
				return false;
		}
	}
}
