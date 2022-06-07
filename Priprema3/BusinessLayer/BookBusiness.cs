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


		public bool InsertBook(Book book)
		{
			if (this.bookRepo.InsertBook(book) > 0)
				return true;
			else
				return false;
		}

		public Book ShowBook(string isbn)
		{
			List<Book> list = this.bookRepo.GetBooks();
			return list.Find(b => b.ISBN.Equals(isbn));
		}

		public bool UpdateBook(Book book, int id)
		{
			bool r = false;
			if (book.Id != 0 && this.bookRepo.UpdateBook(book,id) > 0)
				r = true;
			return r;
		}
	}
}
