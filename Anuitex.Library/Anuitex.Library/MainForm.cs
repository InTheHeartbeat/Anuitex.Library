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
        public IEnumerable<Magazine> Magazines;
        public IEnumerable<Newspaper> Newspapers;


        #region Book events
        public event Action BooksListUpdated;
        public event Action<Book> BookCreated;
        public event Action<Book> BookDeleted;
        public event Action<Book> BookUpdated;
        public event Action<Book> BookTakenToRead;
        public event Action<Book> BookReturned;
        #endregion
        #region Magazine events
        public event Action MagazinesListUpdated;
        public event Action<Magazine> MagazineCreated;
        public event Action<Magazine> MagazineDeleted;
        public event Action<Magazine> MagazineUpdated;
        public event Action<Magazine> MagazineTakenToRead;
        public event Action<Magazine> MagazineReturned;
        #endregion
        #region Newspaper events
        public event Action NewspapersListUpdated;
        public event Action<Newspaper> NewspaperCreated;
        public event Action<Newspaper> NewspaperDeleted;
        public event Action<Newspaper> NewspaperUpdated;
        public event Action<Newspaper> NewspaperTakenToRead;
        public event Action<Newspaper> NewspaperReturned;
        #endregion


        public MainForm()
        {
            InitializeComponent();

            booksGridView.SelectionChanged += BooksGridView_SelectionChanged;

            Books = new List<Book>();   
            Magazines = new List<Magazine>();
            Newspapers = new List<Newspaper>();                    
        }

        public new void Show()
        {            
            Application.Run(this);                     
        }

        private void SetButtonsState()
        {
            bool anyBookExists = Books.Any();

            buttonTakeToRead.Enabled = anyBookExists;
            buttonReturnSelectedBook.Enabled = anyBookExists;
            buttonUpdateSelected.Enabled = anyBookExists;
            buttonDeleteSelected.Enabled = anyBookExists;
        }

        private Type GetTypeSelectedItem()
        {
            TabPage selectedPage = tabControl.SelectedTab;
            if (selectedPage.Name == "tabPageBooks" && booksGridView.Visible)
            {
                return typeof(Book);                
            }

            if (selectedPage.Name == "tabPageMagazines" && magazinesGridView.Visible)
            {
                return typeof(Magazine);
            }

            if (selectedPage.Name == "tabPageNewspapers" && newspapersGridView.Visible)
            {
                return typeof(Newspaper);
            }
            return null;
        }
                

        #region Book

        private void BooksGridView_SelectionChanged(object sender, EventArgs e)
        {
            SetButtonsState();

            if (booksGridView.SelectedRows.Count > 0)
            {
                bool bookAvailable = GetSelectedBook().Available;

                buttonTakeToRead.Enabled = bookAvailable;
                buttonReturnSelectedBook.Enabled = !bookAvailable;
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

        private int GetSelectedBookId()
        {
            return (int)booksGridView.SelectedRows[0].Cells["BookId"].Value;
        }

        private Book GetSelectedBook()
        {
            return Books.FirstOrDefault(book => book.Id == GetSelectedBookId());
        }

        private void OnBookCreated(Book obj)
        {
            BookCreated?.Invoke(obj);
            OnBooksListUpdated();
        }
        private void OnBookUpdated(Book obj)
        {
            BookUpdated?.Invoke(obj);
            OnBooksListUpdated();
        }
        private void OnBookDeleted(Book obj)
        {
            BookDeleted?.Invoke(obj);
            OnBooksListUpdated();
        }
        private void OnBookTakenToRead(Book obj)
        {
            BookTakenToRead?.Invoke(obj);
            OnBooksListUpdated();
        }
        private void OnBookReturned(Book obj)
        {
            BookReturned?.Invoke(obj);
            OnBooksListUpdated();
        }

        private void OnBooksListUpdated()
        {
            BooksListUpdated?.Invoke();
            UpdateBooksGridView();
        }

        #endregion

        #region Magazine

        private void magazinesGridView_SelectionChanged(object sender, EventArgs e)
        {
            SetButtonsState();

            if (magazinesGridView.SelectedRows.Count > 0)
            {
                bool available = GetSelectedMagazine().Available;

                buttonTakeToRead.Enabled = available;
                buttonReturnSelectedBook.Enabled = !available;
            }
        }        

        private void UpdateMagazinesGridView()
        {
            magazinesGridView.Rows.Clear();
            if (Magazines.Any())
            {
                foreach (Magazine magazine in Magazines)
                {
                    magazinesGridView.Rows.Add(
                        magazine.Id,
                        magazine.Title,
                        magazine.Date,
                        magazine.Periodicity,
                        magazine.Subjects,                        
                        magazine.Available);
                }
            }
        }

        private int GetSelectedMagazineId()
        {
            return (int)magazinesGridView.SelectedRows[0].Cells["MagazineId"].Value;
        }

        private Magazine GetSelectedMagazine()
        {
            return Magazines.FirstOrDefault(magazine => magazine.Id == GetSelectedMagazineId());
        }
        
        private void OnMagazinesListUpdated()
        {
            MagazinesListUpdated?.Invoke();
            UpdateMagazinesGridView();
        }

        private void OnMagazineCreated(Magazine obj)
        {
            MagazineCreated?.Invoke(obj);
            OnMagazinesListUpdated();
        }

        private void OnMagazineDeleted(Magazine obj)
        {
            MagazineDeleted?.Invoke(obj);
            OnMagazinesListUpdated();
        }

        private void OnMagazineUpdated(Magazine obj)
        {
            MagazineUpdated?.Invoke(obj);
            OnMagazinesListUpdated();
        }

        private void OnMagazineTakenToRead(Magazine obj)
        {
            MagazineTakenToRead?.Invoke(obj);
            OnMagazinesListUpdated();
        }

        private void OnMagazineReturned(Magazine obj)
        {
            MagazineReturned?.Invoke(obj);
            OnMagazinesListUpdated();
        }

        #endregion

        #region Newspaper

        private void newspapersGridView_SelectionChanged(object sender, EventArgs e)
        {
            SetButtonsState();

            if (newspapersGridView.SelectedRows.Count > 0)
            {
                bool available = GetSelectedNewspaper().Available;

                buttonTakeToRead.Enabled = available;
                buttonReturnSelectedBook.Enabled = !available;
            }
        }

        private void UpdateNewspapersGridView()
        {
            newspapersGridView.Rows.Clear();
            if (Newspapers.Any())
            {
                foreach (Newspaper newspaper in Newspapers)
                {
                    newspapersGridView.Rows.Add(
                        newspaper.Id,
                        newspaper.Title,
                        newspaper.Date,
                        newspaper.Periodicity,                        
                        newspaper.Available);
                }
            }
        }

        private int GetSelectedNewspaperId()
        {
            return (int)newspapersGridView.SelectedRows[0].Cells["NewspaperId"].Value;
        }

        private Newspaper GetSelectedNewspaper()
        {
            return Newspapers.FirstOrDefault(newspaper => newspaper.Id == GetSelectedNewspaperId());
        }

        private void OnNewspapersListUpdated()
        {
            NewspapersListUpdated?.Invoke();
            UpdateNewspapersGridView();
        }

        private void OnNewspaperCreated(Newspaper obj)
        {
            NewspaperCreated?.Invoke(obj);
            OnNewspapersListUpdated();
        }

        private void OnNewspaperDeleted(Newspaper obj)
        {
            NewspaperDeleted?.Invoke(obj);
            OnNewspapersListUpdated();
        }

        private void OnNewspaperUpdated(Newspaper obj)
        {
            NewspaperUpdated?.Invoke(obj);
            OnNewspapersListUpdated();
        }

        private void OnNewspaperTakenToRead(Newspaper obj)
        {
            NewspaperTakenToRead?.Invoke(obj);
            OnNewspapersListUpdated();
        }

        private void OnNewspaperReturned(Newspaper obj)
        {
            NewspaperReturned?.Invoke(obj);
            OnNewspapersListUpdated();
        }

        #endregion

        #region Buttons handlers                
        private void buttonTakeToRead_Click(object sender, EventArgs e)
        {
            Type selectedType = GetTypeSelectedItem();
            if (selectedType == typeof(Book))
            {
                OnBookTakenToRead(GetSelectedBook());
            }
            if (selectedType == typeof(Magazine))
            {
                OnMagazineTakenToRead(GetSelectedMagazine());
            }
            if (selectedType == typeof(Newspaper))
            {
                OnNewspaperTakenToRead(GetSelectedNewspaper());
            }
        }       
        private void buttonReturnSelectedBook_Click(object sender, EventArgs e)
        {
            Type selectedType = GetTypeSelectedItem();
            if (selectedType == typeof(Book))
            {
                OnBookReturned(GetSelectedBook());
            }
            if (selectedType == typeof(Magazine))
            {
                OnMagazineReturned(GetSelectedMagazine());
            }
            if (selectedType == typeof(Newspaper))
            {
                OnNewspaperReturned(GetSelectedNewspaper());
            }
        }        
        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            Type selectedType = GetTypeSelectedItem();
            if (selectedType == typeof(Book))
            {
                OnBookDeleted(GetSelectedBook());
            }
            if (selectedType == typeof(Magazine))
            {
                OnMagazineDeleted(GetSelectedMagazine());
            }
            if (selectedType == typeof(Newspaper))
            {
                OnNewspaperDeleted(GetSelectedNewspaper());
            }
        }
        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            if (GetTypeSelectedItem() == typeof(Book))
            {
                DesignBookForm form = new DesignBookForm();
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnBookCreated(form.ResultBook);
                }
                form.Dispose();
            }

            if (GetTypeSelectedItem() == typeof(Magazine))
            {
                DesignMagazineForm form = new DesignMagazineForm();
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnMagazineCreated(form.ResultMagazine);
                }
                form.Dispose();
            }

            if (GetTypeSelectedItem() == typeof(Newspaper))
            {
                DesignNewspaperForm form = new DesignNewspaperForm();
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnNewspaperCreated(form.ResultNewspaper);
                }
                form.Dispose();
            }
        }
        private void buttonUpdateSelected_Click(object sender, EventArgs e)
        {
            if (GetTypeSelectedItem() == typeof(Book))
            {
                DesignBookForm form = new DesignBookForm(GetSelectedBook());
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnBookUpdated(form.ResultBook);
                }
                form.Dispose();
            }

            if(GetTypeSelectedItem() == typeof(Magazine))
            {
                DesignMagazineForm form = new DesignMagazineForm(GetSelectedMagazine());
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnMagazineUpdated(form.ResultMagazine);
                }
                form.Dispose();
            }

            if (GetTypeSelectedItem() == typeof(Newspaper))
            {
                DesignNewspaperForm form = new DesignNewspaperForm(GetSelectedNewspaper());
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnNewspaperUpdated(form.ResultNewspaper);
                }
                form.Dispose();
            }
        }
        #endregion
        
        
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedPage = tabControl.SelectedTab;

            if (selectedPage.Name == "tabPageBooks")
            {
                OnBooksListUpdated();
            }

            if (selectedPage.Name == "tabPageMagazines")
            {
                OnMagazinesListUpdated();
            }

            if (selectedPage.Name == "tabPageNewspapers")
            {
                OnNewspapersListUpdated();
            }
        }        
    }
}
