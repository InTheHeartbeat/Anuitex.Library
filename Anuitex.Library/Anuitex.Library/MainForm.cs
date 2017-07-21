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
        public IEnumerable<Journal> Journals;
        public IEnumerable<Newspaper> Newspapers;


        #region Book events
        public event Action BooksListUpdated;
        public event Action<Book> BookCreated;
        public event Action<Book> BookDeleted;
        public event Action<Book> BookUpdated;
        public event Action<Book> BookTakenToRead;
        public event Action<Book> BookReturned;
        #endregion
        #region Journal events
        public event Action JournalsListUpdated;
        public event Action<Journal> JournalCreated;
        public event Action<Journal> JournalDeleted;
        public event Action<Journal> JournalUpdated;
        public event Action<Journal> JournalTakenToRead;
        public event Action<Journal> JournalReturned;
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
            Journals = new List<Journal>();
            Newspapers = new List<Newspaper>();                    
        }

        public new void Show()
        {
            OnBooksListUpdated();
            SetButtonsState();
            Application.Run(this);              
        }

        private void SetButtonsState()
        {
            TabPage selectedPage = tabControl.SelectedTab;

            if (selectedPage.Name == "tabPageBooks")
            {
                bool anyBookExists = Books.Any();

                buttonTakeToRead.Enabled = anyBookExists;
                buttonReturnSelected.Enabled = anyBookExists;
                buttonUpdateSelected.Enabled = anyBookExists;
                buttonDeleteSelected.Enabled = anyBookExists;
            }

            if (selectedPage.Name == "tabPageJournals")
            {
                bool anyJournalsExists = Journals.Any();

                buttonTakeToRead.Enabled = anyJournalsExists;
                buttonReturnSelected.Enabled = anyJournalsExists;
                buttonUpdateSelected.Enabled = anyJournalsExists;
                buttonDeleteSelected.Enabled = anyJournalsExists;
            }

            if (selectedPage.Name == "tabPageNewspapers")
            {
                bool anyNewspapersExists = Newspapers.Any();

                buttonTakeToRead.Enabled = anyNewspapersExists;
                buttonReturnSelected.Enabled = anyNewspapersExists;
                buttonUpdateSelected.Enabled = anyNewspapersExists;
                buttonDeleteSelected.Enabled = anyNewspapersExists;
            }
        }

        private Type GetTypeSelectedItem()
        {
            TabPage selectedPage = tabControl.SelectedTab;
            if (selectedPage.Name == "tabPageBooks" && booksGridView.Visible)
            {
                return typeof(Book);                
            }

            if (selectedPage.Name == "tabPageJournals" && journalsGridView.Visible)
            {
                return typeof(Journal);
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
                buttonReturnSelected.Enabled = !bookAvailable;
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

        #region Journal

        private void journalsGridView_SelectionChanged(object sender, EventArgs e)
        {
            SetButtonsState();

            if (journalsGridView.SelectedRows.Count > 0)
            {
                bool available = GetSelectedJournal().Available;

                buttonTakeToRead.Enabled = available;
                buttonReturnSelected.Enabled = !available;
            }
        }        

        private void UpdateJournalsGridView()
        {
            journalsGridView.Rows.Clear();
            if (Journals.Any())
            {
                foreach (Journal journal in Journals)
                {
                    journalsGridView.Rows.Add(
                        journal.Id,
                        journal.Title,
                        journal.Date,
                        journal.Periodicity,
                        journal.Subjects,                        
                        journal.Available);
                }
            }
        }

        private int GetSelectedJournalId()
        {
            return (int)journalsGridView.SelectedRows[0].Cells["JournalId"].Value;
        }

        private Journal GetSelectedJournal()
        {
            return Journals.FirstOrDefault(journal => journal.Id == GetSelectedJournalId());
        }
        
        private void OnJournalsListUpdated()
        {
            JournalsListUpdated?.Invoke();
            UpdateJournalsGridView();
        }

        private void OnJournalCreated(Journal obj)
        {
            JournalCreated?.Invoke(obj);
            OnJournalsListUpdated();
        }

        private void OnJournalDeleted(Journal obj)
        {
            JournalDeleted?.Invoke(obj);
            OnJournalsListUpdated();
        }

        private void OnJournalUpdated(Journal obj)
        {
            JournalUpdated?.Invoke(obj);
            OnJournalsListUpdated();
        }

        private void OnJournalTakenToRead(Journal obj)
        {
            JournalTakenToRead?.Invoke(obj);
            OnJournalsListUpdated();
        }

        private void OnJournalReturned(Journal obj)
        {
            JournalReturned?.Invoke(obj);
            OnJournalsListUpdated();
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
                buttonReturnSelected.Enabled = !available;
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
            if (selectedType == typeof(Journal))
            {
                OnJournalTakenToRead(GetSelectedJournal());
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
            if (selectedType == typeof(Journal))
            {
                OnJournalReturned(GetSelectedJournal());
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
            if (selectedType == typeof(Journal))
            {
                OnJournalDeleted(GetSelectedJournal());
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

            if (GetTypeSelectedItem() == typeof(Journal))
            {
                DesignJournalForm form = new DesignJournalForm();
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnJournalCreated(form.ResultJournal);
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

            if(GetTypeSelectedItem() == typeof(Journal))
            {
                DesignJournalForm form = new DesignJournalForm(GetSelectedJournal());
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnJournalUpdated(form.ResultJournal);
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

                buttonAdd.Text = "Add new book";
                buttonDeleteSelected.Text = "Delete selected book";                
                buttonUpdateSelected.Text = "Update selected book";
            }

            if (selectedPage.Name == "tabPageJournals")
            {
                OnJournalsListUpdated();

                buttonAdd.Text = "Add new journal";
                buttonDeleteSelected.Text = "Delete selected journal";
                buttonUpdateSelected.Text = "Update selected journal";
            }

            if (selectedPage.Name == "tabPageNewspapers")
            {
                OnNewspapersListUpdated();

                buttonAdd.Text = "Add new newspaper";
                buttonDeleteSelected.Text = "Delete selected newspaper";
                buttonUpdateSelected.Text = "Update selected newspaper";
            }
            SetButtonsState();
        }        
    }
}
