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
        private readonly MagazineRepository magazineRepository;
        private readonly NewspaperRepository newspaperRepository;


        public MainPresenter(MainForm view, BookRepository bookRepository, MagazineRepository magazineRepository, NewspaperRepository newspaperRepository)
        {
            this.view = view;
            this.bookRepository = bookRepository;
            this.magazineRepository = magazineRepository;
            this.newspaperRepository = newspaperRepository;

            this.view.BooksListUpdated += UpdateBooksList;
            this.view.BookTakenToRead += OnViewBookTakenToRead;
            this.view.BookReturned += OnViewBookReturned;
            this.view.BookDeleted += OnViewBookDeleted;
            this.view.BookCreated += OnViewBookCreated;
            this.view.BookUpdated += OnViewBookUpdated;

            this.view.MagazinesListUpdated += UpdateMagazinesList;
            this.view.MagazineTakenToRead += OnViewMagazineTakenToRead;
            this.view.MagazineReturned += OnViewMagazineReturned;
            this.view.MagazineDeleted += OnViewMagazineDeleted;
            this.view.MagazineCreated += OnViewMagazineCreated;
            this.view.MagazineUpdated += OnViewMagazineUpdated;

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
        private void OnViewMagazineUpdated(Magazine obj)
        {
            if(obj != null)
            {
                magazineRepository.Update(obj);
                magazineRepository.Submit();
            }
        }

        private void OnViewMagazineCreated(Magazine obj)
        {
            if (obj != null)
            {
                magazineRepository.Add(obj);
                magazineRepository.Submit();
            }
        }

        private void OnViewMagazineDeleted(Magazine obj)
        {
            if (obj != null)
            {
                magazineRepository.Delete(obj);
                magazineRepository.Submit();
            }
        }

        private void OnViewMagazineReturned(Magazine obj)
        {
            if (obj != null)
            {
                magazineRepository.SetAvailableValue(obj.Id, true);
                magazineRepository.Submit();
            }
        }

        private void OnViewMagazineTakenToRead(Magazine obj)
        {
            if (obj != null)
            {
                magazineRepository.SetAvailableValue(obj.Id, false);
                magazineRepository.Submit();
            }
        }

        private void UpdateMagazinesList()
        {
            this.view.Magazines = magazineRepository.GetList();
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
