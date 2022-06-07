using BusinessLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priprema3.Controllers
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
		public List<Book> GetAllBooks()
		{
			return this.bookBusiness.GetBooks();
		}

		[HttpGet("get/{isbn}")]
		public Book ShowBook(string isbn)
		{
			return this.bookBusiness.ShowBook(isbn);
		}

		[HttpPost("insert")]
		public bool InsertBook(Book book)
		{
			return this.bookBusiness.InsertBook(book);
		}

		[HttpPut("update/{id}")]
		public bool UpdateBook(Book book, int id)
		{
			return this.bookBusiness.UpdateBook(book, id);
		}
	}
}
