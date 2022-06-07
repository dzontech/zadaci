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
		int Insert(Book b);
		int Update(BookDTO b, int id);
	}
}
