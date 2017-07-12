using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Models.Repositories;

namespace Anuitex.Library.Presenters
{
    public class CreatePresenter
    {
        private readonly CreateForm _view;
        private readonly BookRepository _repository;

        public CreatePresenter(CreateForm view, BookRepository repository)
        {
            _view = view;
            _repository = repository;

            _view.BookCreated += _view_BookCreated;
        }

        private void _view_BookCreated(Data.Book book)
        {
            if (book != null)
            {
                _repository.Create(book);
                _repository.Submit();
            }
        }

        public void Run()
        {
            _view.Show();
        }
    }
}
