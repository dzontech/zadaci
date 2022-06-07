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
		bool Insert(Book b);
		bool Update(BookDTO b, int id);
		Book ShowByISBN(string isbn);
	}
}
