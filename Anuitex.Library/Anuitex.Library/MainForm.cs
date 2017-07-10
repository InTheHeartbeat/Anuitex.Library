using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anuitex.Library.Data;

namespace Anuitex.Library
{
    public sealed partial class MainForm : Form
    {

        public IEnumerable<Book> Books;

        public event Action UiUpdated;
        public event Action<Book> BookTakenToRead;
        public event Action<Book> BookReturned;
        public event Action<Book> BookDeleted;

       
        public MainForm()
        {
            InitializeComponent();

            booksGridView.SelectionChanged += BooksGridView_SelectionChanged;

            Books = new List<Book>();

                       
        }

        private void BooksGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (booksGridView.SelectedRows.Count > 0)
            {                
                bool bookAvailable = CheckBookAvailable(GetSelectedBook());
                if (!bookAvailable)
                {
                    buttonTakeToRead.Enabled = false;
                    buttonReturnSelectedBook.Enabled = true;
                }
                if (bookAvailable)
                {
                    buttonTakeToRead.Enabled = true;
                    buttonReturnSelectedBook.Enabled = false;
                }
            }
        }

        private bool CheckBookAvailable(Book book)
        {
            return book.Available != null && (bool) book.Available;
        }

        private Book GetSelectedBook()
        {
            return Books.FirstOrDefault(book => book.Id == (int) booksGridView.SelectedRows[0].Cells["Id"].Value);
        }

        private void UpdateBooksGridView()
        {
            booksGridView.Rows.Clear();
            if (Books.Any())
            {                
                foreach (Book book in Books)
                {
                    booksGridView.Rows.Add(
                        book.Id,
                        book.Title, 
                        book.Author,
                        book.Genre,
                        book.Year,
                        book.Pages,
                        book.Available);
                }
            }
        }

        public new void Show()
        {
            OnUiUpdated();            
            Application.Run(this);            
        }

        private void OnUiUpdated()
        {
            UiUpdated?.Invoke();
            UpdateBooksGridView();
        }

        private void buttonTakeToRead_Click(object sender, EventArgs e)
        {
            OnBookTakenToRead(GetSelectedBook());
            OnUiUpdated();
        }

        private void OnBookTakenToRead(Book obj)
        {
            BookTakenToRead?.Invoke(obj);
        }

        private void buttonReturnSelectedBook_Click(object sender, EventArgs e)
        {
            OnBookReturned(GetSelectedBook());
        }

        private void OnBookReturned(Book obj)
        {
            BookReturned?.Invoke(obj);
            OnUiUpdated();
        }

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            OnBookDeleted(GetSelectedBook());
        }

        private void OnBookDeleted(Book obj)
        {
            BookDeleted?.Invoke(obj);
            OnUiUpdated();
        }
    }
}
