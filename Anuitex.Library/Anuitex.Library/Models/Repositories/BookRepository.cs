using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anuitex.Library.Data;
using DataContext = Anuitex.Library.Data.DataContext;

namespace Anuitex.Library.Models.Repositories
{
    public class BookRepository
    {      
        public BookRepository()
        {                        
        }

        public IEnumerable<Book> GetList()
        {
            return DataContext.Context.LibraryContext.Books.AsEnumerable();
        }  

        public void Add(Book item)
        {              
            DataContext.Context.LibraryContext.Books.InsertOnSubmit(item);
        }

        public void Update(Book newItem)
        {
            Book old = DataContext.Context.LibraryContext.Books.FirstOrDefault(book => book.Id == newItem.Id);
            old.Title = !old.Title.Equals(newItem.Title)          ? newItem.Title    : old.Title;
            old.Year = !old.Year.Equals(newItem.Year)             ? newItem.Year     : old.Year;
            old.Pages = !old.Pages.Equals(newItem.Pages)          ? newItem.Pages    : old.Pages;
            old.Author = !old.Author.Equals(newItem.Author) ? newItem.Author : old.Author;
            old.Genre = !old.Genre.Equals(newItem.Genre)    ? newItem.Genre  : old.Genre;
            old.Available = !old.Available.Equals(newItem.Available) ? newItem.Available : old.Available;            
        }

        public void Delete(Book book)
        {
            DataContext.Context.LibraryContext.Books.DeleteOnSubmit(book);            
        }

        public void SetAvailableValue(int bookId, bool available)
        {
            Book book = DataContext.Context.LibraryContext.Books.FirstOrDefault(first => first.Id == bookId);

            if (book != null)
            {
                book.Available = available;
            }
        }

        public void Submit()
        {
            DataContext.Context.LibraryContext.SubmitChanges();
        }
    }
}
