using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public interface IBookBusiness
	{
		List<Book> GetBooks();
		bool InsertBook(Book book);
		bool UpdateBook(Book book, int id);

		Book ShowBook(string isbn);
		
	}
}
