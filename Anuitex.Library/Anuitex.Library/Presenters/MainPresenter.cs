using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            _view.ComponentsInitialized += UpdateBooksList;
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
