using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
	public class ProductBusiness : IProductBusiness
	{
		private IProductRepository productRepository;

		public ProductBusiness(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		public List<Product> GetAllProducts()
		{
			List<Product> list = this.productRepository.GetAllProducts();
			if(list.Count > 0)
				return list;
			else  
				return null; 

		}

		public bool InsertProduct(Product product)
		{
			if (this.productRepository.InsertProduct(product) > 0)
				return true;
			else
				return false;
		}

		public List<Product> MinMaxPrice(int minPrice, int maxPrice)
		{
			List<Product> list = this.productRepository.GetAllProducts();
			return list.FindAll(p => p.Price >= minPrice && p.Price <= maxPrice);

		}
	}
}
