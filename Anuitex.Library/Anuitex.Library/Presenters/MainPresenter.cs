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
        private readonly MainForm _view;
        private readonly BookRepository _bookRepository;

        public MainPresenter(MainForm view, BookRepository bookRepository)
        {
            _view = view;
            _bookRepository = bookRepository;

            _view.UiUpdated += UpdateBooksList;
            _view.BookTakenToRead += _view_BookTakenToRead;
            _view.BookReturned += _view_BookReturned;
            _view.BookDeleted += _view_BookDeleted;
            _view.BookCreated += _view_BookCreated;
        }

        private void _view_BookCreated(Data.Book book)
        {
            if (book != null)
            {
                _bookRepository.Create(book);
                _bookRepository.Submit();
            }
        }

        private void _view_BookDeleted(Book obj)
        {
            _bookRepository.Delete(obj);
            _bookRepository.Submit();
        }

        private void _view_BookReturned(Book obj)
        {
            _bookRepository.SetAvailableValue(obj, true);
        }

        private void _view_BookTakenToRead(Data.Book obj)
        {            
            _bookRepository.SetAvailableValue(obj,false);            
        }

        private void UpdateBooksList()
        {
            _view.Books = _bookRepository.GetBookList();
        }

        public void Run()
        {
            _view.Show();            
        }
    }
}
