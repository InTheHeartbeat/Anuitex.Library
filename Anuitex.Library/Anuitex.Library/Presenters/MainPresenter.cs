using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Data;
using Anuitex.Library.Data.Entities;
using Anuitex.Library.Models;
using Anuitex.Library.Models.Repositories;

namespace Anuitex.Library.Presenters
{
    public class MainPresenter
    {
        private readonly MainForm view;
        private readonly BookRepository bookRepository;
        private readonly JournalRepository journalRepository;
        private readonly NewspaperRepository newspaperRepository;

        private readonly XmlRepository xmlRepository;
        private readonly RawFileRepository rawFileRepository;

        public MainPresenter(MainForm view, BookRepository bookRepository, JournalRepository journalRepository, NewspaperRepository newspaperRepository, XmlRepository xmlRepository, RawFileRepository rawFileRepository)
        {
            this.view = view;
            this.bookRepository = bookRepository;
            this.journalRepository = journalRepository;
            this.newspaperRepository = newspaperRepository;
            this.xmlRepository = xmlRepository;
            this.rawFileRepository = rawFileRepository;

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

            this.view.BooksXmlExported += OnViewBooksXmlExported;
            this.view.BooksRawExported += OnViewBooksRawExported;
            this.view.JournalsXmlExported += OnViewJournalsXmlExported;
            this.view.JournalsRawExported += OnViewJournalsRawExported;
            this.view.NewspapersXmlExported += OnViewNewspapersXmlExported;
            this.view.NewspapersRawExported += OnViewNewspapersRawExported;

            this.view.BooksXmlImported += OnViewBooksXmlImported;
            this.view.BooksRawImported += OnViewBooksRawImported;
            this.view.JournalsXmlImported += OnViewJournalsXmlImported;
            this.view.JournalsRawImported += OnViewJournalsRawImported;
            this.view.NewspapersXmlImported += OnViewNewspapersXmlImported;
            this.view.NewspapersRawImported += OnViewNewspapersRawImported;
        }

        private void OnViewNewspapersRawImported(string obj)
        {
            rawFileRepository.Import<Newspaper>(obj).ForEach(newspaperRepository.Add);
        }

        private void OnViewNewspapersXmlImported(string obj)
        {
            xmlRepository.Import<Newspaper>(obj).ForEach(newspaperRepository.Add);
        }

        private void OnViewJournalsRawImported(string obj)
        {
            rawFileRepository.Import<Journal>(obj).ForEach(journalRepository.Add);
        }

        private void OnViewJournalsXmlImported(string obj)
        {
            xmlRepository.Import<Journal>(obj).ForEach(journalRepository.Add);
        }

        private void OnViewBooksRawImported(string path)
        {
            rawFileRepository.Import<Book>(path).ForEach(bookRepository.Add);
        }

        private void OnViewBooksXmlImported(string path)
        {
            xmlRepository.Import<Book>(path).ForEach(bookRepository.Add);
        }

        private void OnViewNewspapersRawExported(List<Newspaper> newspapers, string path)
        {
            rawFileRepository.Export(newspapers,path);
        }

        private void OnViewNewspapersXmlExported(List<Newspaper> newspapers, string path)
        {
            xmlRepository.Export(newspapers,path);
        }

        private void OnViewJournalsRawExported(List<Journal> journals, string path)
        {
            rawFileRepository.Export(journals, path);
        }

        private void OnViewJournalsXmlExported(List<Journal> journals, string path)
        {
            xmlRepository.Export(journals,path);
        }

        private void OnViewBooksRawExported(List<Book> books, string path)
        {
            rawFileRepository.Export(books, path);
        }

        private void OnViewBooksXmlExported(List<Book> obj, string path)
        {
            xmlRepository.Export(obj,path);
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
