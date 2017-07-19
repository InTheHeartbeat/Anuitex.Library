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
        private readonly JournalRepository journalRepository;
        private readonly NewspaperRepository newspaperRepository;


        public MainPresenter(MainForm view, BookRepository bookRepository, JournalRepository journalRepository, NewspaperRepository newspaperRepository)
        {
            this.view = view;
            this.bookRepository = bookRepository;
            this.journalRepository = journalRepository;
            this.newspaperRepository = newspaperRepository;

            this.view.BooksListUpdated += UpdateBooksList;
            this.view.BookTakenToRead += OnViewBookTakenToRead;
            this.view.BookReturned += OnViewBookReturned;
            this.view.BookDeleted += OnViewBookDeleted;
            this.view.BookCreated += OnViewBookCreated;
            this.view.BookUpdated += OnViewBookUpdated;

            this.view.JournalsListUpdated += UpdateJournalsList;
            this.view.JournalTakenToRead += OnViewJournalTakenToRead;
            this.view.JournalReturned += OnViewJournalReturned;
            this.view.JournalDeleted += OnViewJournalDeleted;
            this.view.JournalCreated += OnViewJournalCreated;
            this.view.JournalUpdated += OnViewJournalUpdated;

            this.view.NewspapersListUpdated += UpdateNewspapersList;
            this.view.NewspaperTakenToRead += OnViewNewspaperTakenToRead;
            this.view.NewspaperReturned += OnViewNewspaperReturned;
            this.view.NewspaperDeleted += OnViewNewspaperDeleted;
            this.view.NewspaperCreated += OnViewNewspaperCreated;
            this.view.NewspaperUpdated += OnViewNewspaperUpdated;
        }

        #region Newspaper
        private void OnViewNewspaperUpdated(Newspaper obj)
        {
            if(obj != null)
            {
                newspaperRepository.Update(obj);
                newspaperRepository.Submit();
            }
        }

        private void OnViewNewspaperCreated(Newspaper obj)
        {
            if (obj != null)
            {
                newspaperRepository.Add(obj);
                newspaperRepository.Submit();
            }
        }

        private void OnViewNewspaperDeleted(Newspaper obj)
        {
            if (obj != null)
            {
                newspaperRepository.Delete(obj);
                newspaperRepository.Submit();
            }
        }

        private void OnViewNewspaperReturned(Newspaper obj)
        {
            if (obj != null)
            {
                newspaperRepository.SetAvailableValue(obj.Id, true);
                newspaperRepository.Submit();
            }
        }

        private void OnViewNewspaperTakenToRead(Newspaper obj)
        {
            if (obj != null)
            {
                newspaperRepository.SetAvailableValue(obj.Id, false); 
                newspaperRepository.Submit();
            }
        }

        private void UpdateNewspapersList()
        {
            this.view.Newspapers = newspaperRepository.GetList();
        }
#endregion

        #region Marazine
        private void OnViewJournalUpdated(Journal obj)
        {
            if(obj != null)
            {
                journalRepository.Update(obj);
                journalRepository.Submit();
            }
        }

        private void OnViewJournalCreated(Journal obj)
        {
            if (obj != null)
            {
                journalRepository.Add(obj);
                journalRepository.Submit();
            }
        }

        private void OnViewJournalDeleted(Journal obj)
        {
            if (obj != null)
            {
                journalRepository.Delete(obj);
                journalRepository.Submit();
            }
        }

        private void OnViewJournalReturned(Journal obj)
        {
            if (obj != null)
            {
                journalRepository.SetAvailableValue(obj.Id, true);
                journalRepository.Submit();
            }
        }

        private void OnViewJournalTakenToRead(Journal obj)
        {
            if (obj != null)
            {
                journalRepository.SetAvailableValue(obj.Id, false);
                journalRepository.Submit();
            }
        }

        private void UpdateJournalsList()
        {
            this.view.Journals = journalRepository.GetList();
        }
        #endregion

        #region Book
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
                bookRepository.Add(book);
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
            view.Books = bookRepository.GetList();
        }
#endregion


        public void Run()
        {
            view.Show();            
        }
    }
}
