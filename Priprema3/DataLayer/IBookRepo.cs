using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface IBookRepo
	{
		List<Book> GetBooks();
		int InsertBook(Book book);

		
		int UpdateBook(Book book, int id);
	}
}
