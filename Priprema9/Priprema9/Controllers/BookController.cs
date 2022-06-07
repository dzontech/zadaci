using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priprema9.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private IBookBusiness bookBusiness;

		public BookController(IBookBusiness bookBusiness)
		{
			this.bookBusiness = bookBusiness;
		}

		[HttpGet("getall")]
		public List<Book> GetBooks()
		{
			return this.bookBusiness.GetBooks();
		}

		[HttpPost("insert")]
		public bool Insert(Book b)
		{
			return this.bookBusiness.Insert(b);
		}

		[HttpPut("update/{id}")]
		public bool Update(BookDTO b, int id)
		{
			return this.bookBusiness.Update(b, id);
		}

		[HttpGet("getall/{isbn}")]
		public Book ShowByISBN(string isbn)
		{
			return this.bookBusiness.ShowByISBN(isbn);
		}
		
	}
}
