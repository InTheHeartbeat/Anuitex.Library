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
using Anuitex.Library.Models.Repositories;
using Anuitex.Library.Presenters;

namespace Anuitex.Library
{
    public sealed partial class MainForm : Form
    {

        public IEnumerable<Book> Books;

        public event Action UiUpdated;
        public event Action<Book> BookCreated;
        public event Action<Book> BookDeleted;
        public event Action<Book> BookUpdated;
        public event Action<Book> BookTakenToRead;
        public event Action<Book> BookReturned;        
        
       
        public MainForm()
        {
            InitializeComponent();

            booksGridView.SelectionChanged += BooksGridView_SelectionChanged;

            Books = new List<Book>();                       
        }

        public new void Show()
        {
            OnUiUpdated();
            Application.Run(this);
        }


        private void BooksGridView_SelectionChanged(object sender, EventArgs e)
        {
            SetButtonsState();

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

        private void SetButtonsState()
        {
            if (!Books.Any())
            {
                buttonTakeToRead.Enabled = false;
                buttonReturnSelectedBook.Enabled = false;
                buttonUpdateSelected.Enabled = false;
                buttonDeleteSelected.Enabled = false;
            }

            if (Books.Any())
            {
                buttonTakeToRead.Enabled = true;
                buttonReturnSelectedBook.Enabled = true;
                buttonUpdateSelected.Enabled = true;
                buttonDeleteSelected.Enabled = true;
            }
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

        private bool CheckBookAvailable(Book book)
        {
            return book.Available != null && (bool)book.Available;
        }

        private Book GetSelectedBook()
        {
            return Books.FirstOrDefault(book => book.Id == (int)booksGridView.SelectedRows[0].Cells["Id"].Value);
        }

        private void buttonTakeToRead_Click(object sender, EventArgs e)
        {
            OnBookTakenToRead(GetSelectedBook());            
        } 
               
        private void buttonReturnSelectedBook_Click(object sender, EventArgs e)
        {
            OnBookReturned(GetSelectedBook());
        }        
        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            OnBookDeleted(GetSelectedBook());
        }
        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            BuildBookForm form = new BuildBookForm();
            DialogResult dialogResult = form.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                OnBookCreated(form.ResultBook);
            }            
            form.Dispose();
        }
        private void buttonUpdateSelected_Click(object sender, EventArgs e)
        {
            BuildBookForm form = new BuildBookForm(GetSelectedBook());
            DialogResult dialogResult = form.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                OnBookUpdated(form.ResultBook);
            }
            form.Dispose();
        }

        private void OnBookCreated(Book obj)
        {
            BookCreated?.Invoke(obj);
            OnUiUpdated();
        }
        private void OnBookUpdated(Book obj)
        {
            BookUpdated?.Invoke(obj);
            OnUiUpdated();
        }
        private void OnBookDeleted(Book obj)
        {
            BookDeleted?.Invoke(obj);
            OnUiUpdated();
        }
        private void OnBookTakenToRead(Book obj)
        {
            BookTakenToRead?.Invoke(obj);
            OnUiUpdated();
        }
        private void OnBookReturned(Book obj)
        {
            BookReturned?.Invoke(obj);
            OnUiUpdated();
        }                        
        private void OnUiUpdated()
        {
            UiUpdated?.Invoke();
            UpdateBooksGridView();
        }        
    }
}
