using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priprema1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{

		private IProductBusiness productBusiness;

		public ProductController(IProductBusiness productBusiness)
		{
			this.productBusiness = productBusiness;
		}

		[HttpGet("products")]
		public List<Product> GetAllProducts()
		{
			return this.productBusiness.GetAllProducts();
		}

		[HttpPost("insert")]
		public bool InsertProduct([FromBody] Product p)
		{
			return this.productBusiness.InsertProduct(p);
		}

		[HttpGet("{minPrice}/{maxPrice}/get")]
		public List<Product> MinMaxPrice (int minPrice, int maxPrice)
		{
			return this.productBusiness.MinMaxPrice(minPrice, maxPrice);
		}

	}
}
