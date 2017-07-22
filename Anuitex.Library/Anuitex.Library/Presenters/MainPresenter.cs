using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Data;
using Anuitex.Library.Data.Entities;
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
            this.view.BookDeleted += OnViewBookDeleted;
            this.view.BookCreated += OnViewBookCreated;
            this.view.BookUpdated += OnViewBookUpdated;
            this.view.BookSelled += OnViewBookSelled;

            this.view.JournalsListUpdated += UpdateJournalsList;            
            this.view.JournalDeleted += OnViewJournalDeleted;
            this.view.JournalCreated += OnViewJournalCreated;
            this.view.JournalUpdated += OnViewJournalUpdated;
            this.view.JournalSelled += OnViewJournalSelled;

            this.view.NewspapersListUpdated += UpdateNewspapersList;            
            this.view.NewspaperDeleted += OnViewNewspaperDeleted;
            this.view.NewspaperCreated += OnViewNewspaperCreated;
            this.view.NewspaperUpdated += OnViewNewspaperUpdated;
            this.view.NewspaperSelled += OnViewNewspaperSelled;
        }                    

        #region Newspaper
        private void OnViewNewspaperUpdated(Newspaper obj)
        {
            if(obj != null)
            {
                newspaperRepository.Update(obj);                
            }
        }

        private void OnViewNewspaperCreated(Newspaper obj)
        {
            if (obj != null)
            {
                newspaperRepository.Add(obj);                
            }
        }

        private void OnViewNewspaperDeleted(Newspaper obj)
        {
            if (obj != null)
            {
                newspaperRepository.Delete(obj);                
            }
        }
        
        private void UpdateNewspapersList()
        {
            this.view.Newspapers = newspaperRepository.GetList();
        }
        private void OnViewNewspaperSelled(Newspaper obj)
        {
            obj.Amount -= 1;
            newspaperRepository.Update(obj);
        }
        #endregion
        #region Journal
        private void OnViewJournalUpdated(Journal obj)
        {
            if(obj != null)
            {
                journalRepository.Update(obj);                
            }
        }

        private void OnViewJournalCreated(Journal obj)
        {
            if (obj != null)
            {
                journalRepository.Add(obj);                
            }
        }

        private void OnViewJournalDeleted(Journal obj)
        {
            if (obj != null)
            {
                journalRepository.Delete(obj);                
            }
        }      

        private void UpdateJournalsList()
        {
            this.view.Journals = journalRepository.GetList();
        }
        private void OnViewJournalSelled(Journal obj)
        {
            obj.Amount -= 1;
            journalRepository.Update(obj);
        }
        #endregion
        #region Book
        private void OnViewBookUpdated(Book book)
        {
            if (book != null)
            {
                bookRepository.Update(book);                
            }
        }

        private void OnViewBookCreated(Book book)
        {
            if (book != null)
            {
                bookRepository.Add(book);                
            }
        }

        private void OnViewBookDeleted(Book book)
        {
            if (book != null)
            {
                bookRepository.Delete(book);                
            }
        }
      
        private void UpdateBooksList()
        {
            view.Books = bookRepository.GetList();
        }
        private void OnViewBookSelled(Book obj)
        {
            obj.Amount -= 1;
            bookRepository.Update(obj);
        }
        #endregion

        public void Run()
        {
            view.Show();            
        }
    }
}
