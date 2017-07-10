using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Data;

namespace Anuitex.Library.Models.Repositories
{
    public class BookRepository
    {

        private readonly LibraryDataContext _dataContext;

        public BookRepository()
        {
            _dataContext = new LibraryDataContext();
        }

        public IEnumerable<Book> GetBookList()
        {
            return _dataContext.Books.AsEnumerable();
        }
        public Book GetBook(int id)
        {
            return _dataContext.Books.FirstOrDefault(book => book.Id == id);
        }

        public void Create(Book item)
        {
            _dataContext.Books.InsertOnSubmit(item);
        }

        public void Update(Book newItem)
        {
            Book old = _dataContext.Books.FirstOrDefault(book => book.Id == newItem.Id);
            old.Title = !old.Title.Equals(newItem.Title)          ? newItem.Title    : old.Title;
            old.Year = !old.Year.Equals(newItem.Year)             ? newItem.Year     : old.Year;
            old.Pages = !old.Pages.Equals(newItem.Pages)          ? newItem.Pages    : old.Pages;
            old.Author = !old.Author.Equals(newItem.Author) ? newItem.Author : old.Author;
            old.Genre = !old.Genre.Equals(newItem.Genre)    ? newItem.Genre  : old.Genre;
            old.Available = !old.Available.Equals(newItem.Available) ? newItem.Available : old.Available;
            _dataContext.SubmitChanges();
        }

        void Delete(int id)
        {
            _dataContext.Books.DeleteOnSubmit(_dataContext.Books.FirstOrDefault(book=>book.Id == id));
        }

        public void SetAvailableValue(Book book, bool available)
        {
            _dataContext.Books.FirstOrDefault(first => first.Id == book.Id).Available = available;            
            _dataContext.SubmitChanges();
        }
    }
}
