using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Data;
using Anuitex.Library.Models.Repositories;

namespace Anuitex.Library.Presenters
{
    public class MainPresenter
    {
        private readonly MainForm view;
        private readonly BookRepository bookRepository;

        public MainPresenter(MainForm view, BookRepository bookRepository)
        {
            this.view = view;
            this.bookRepository = bookRepository;

            this.view.UiUpdated += UpdateBooksList;
            this.view.BookTakenToRead += OnViewBookTakenToRead;
            this.view.BookReturned += OnViewBookReturned;
            this.view.BookDeleted += OnViewBookDeleted;
            this.view.BookCreated += OnViewBookCreated;
            this.view.BookUpdated += OnViewBookUpdated;
        }

        private void OnViewBookUpdated(Book book)
        {
            if (book != null)
            {
                bookRepository.Update(book);
                bookRepository.Submit();
            }
        }

        private void OnViewBookCreated(Data.Book book)
        {
            if (book != null)
            {
                bookRepository.Create(book);
                bookRepository.Submit();
            }
        }

        private void OnViewBookDeleted(Book book)
        {
            if (book != null)
            {
                bookRepository.Delete(book);
                bookRepository.Submit();
            }
        }

        private void OnViewBookReturned(Book book)
        {
            if (book != null)
            {
                bookRepository.SetAvailableValue(book.Id, true);
                bookRepository.Submit();
            }
        }

        private void OnViewBookTakenToRead(Book book)
        {
            if (book != null)
            {
                bookRepository.SetAvailableValue(book.Id, false);
                bookRepository.Submit();
            }
        }

        private void UpdateBooksList()
        {
            view.Books = bookRepository.GetBookList();
        }

        public void Run()
        {
            view.Show();            
        }
    }
}
