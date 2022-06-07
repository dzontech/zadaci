using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priprema10.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private IProductBusiness productBusiness;

		public HomeController(IProductBusiness productBusiness)
		{
			this.productBusiness = productBusiness;
		}

		[HttpGet("getall")]
		public List<Product> GetProducts()
		{
			return this.productBusiness.GetProducts();
		}

		[HttpPost("insert")]
		public bool Insert(Product p)
		{
			return this.productBusiness.Insert(p);
		}

		[HttpDelete("delete/{id}")]
		public bool Delete(int id)
		{
			return this.productBusiness.Delete(id);
		}

		[HttpGet("get/{maxprice}/{minprice}")]
		public List<Product> GetProductByPrice(decimal maxprice, decimal minprice)
		{
			return this.productBusiness.GetProductByPrice(maxprice, minprice);
		}
		
		
	}
}
