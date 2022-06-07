using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
	public class BookBusiness : IBookBusiness
	{
		private IBookRepo bookRepo;

		public BookBusiness(IBookRepo bookRepo)
		{
			this.bookRepo = bookRepo;
		}

		public List<Book> GetBooks()
		{
			List<Book> list = this.bookRepo.GetBooks();
			if (list.Count > 0)
				return list;
			else
				return null;
		}

		public bool Insert(Book b)
		{
			if (this.bookRepo.Insert(b) > 0)
				return true;
			else
				return false;
		}

		public Book ShowByISBN(string isbn)
		{
			List<Book> list = this.bookRepo.GetBooks();
			return list.Find(b => b.ISBN.Equals(isbn));
		}

		public bool Update(BookDTO b, int id)
		{
			bool r = false;
			if (id != 0 && this.bookRepo.Update(b, id) > 0)
				r = true;
			return r;
		}
	}
}
