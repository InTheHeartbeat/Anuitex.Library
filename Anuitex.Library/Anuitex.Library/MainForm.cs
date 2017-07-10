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

        public event Action ComponentsInitialized;

        public MainForm()
        {
            InitializeComponent();

            Books = new List<Book>();

                       
        }

        

        private void FillBooksGridView()
        {
            if (Books.Any())
            {
                booksGridView.Rows.Clear();
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
            OnComponentsInitialized();
            FillBooksGridView();
            Application.Run(this);            
        }

        private void OnComponentsInitialized()
        {
            ComponentsInitialized?.Invoke();
        }
    }
}
