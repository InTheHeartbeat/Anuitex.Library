using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Anuitex.Library.Data.Entities;

namespace Anuitex.Library
{
    public sealed partial class MainForm : Form
    {
        public IEnumerable<Book> Books;
        public IEnumerable<Journal> Journals;
        public List<Newspaper> Newspapers;

        #region Book events
        public event Action BooksListUpdated;
        public event Action<Book> BookCreated;
        public event Action<Book> BookDeleted;
        public event Action<Book> BookUpdated;
        public event Action<Book> BookSelled;
        public event Action<Book> BookReturned;
        #endregion
        #region Journal events
        public event Action JournalsListUpdated;
        public event Action<Journal> JournalCreated;
        public event Action<Journal> JournalDeleted;
        public event Action<Journal> JournalUpdated;
        public event Action<Journal> JournalSelled;
        public event Action<Journal> JournalReturned;
        #endregion
        #region Newspaper events
        public event Action NewspapersListUpdated;
        public event Action<Newspaper> NewspaperCreated;
        public event Action<Newspaper> NewspaperDeleted;
        public event Action<Newspaper> NewspaperUpdated;
        public event Action<Newspaper> NewspaperSelled;
        public event Action<Newspaper> NewspaperReturned;
        #endregion

        public event Action<List<Book>, string> BooksXmlExported;
        public event Action<List<Book>, string> BooksRawExported;
        public event Action<List<Journal>, string> JournalsXmlExported;
        public event Action<List<Journal>, string> JournalsRawExported;
        public event Action<List<Newspaper>, string> NewspapersXmlExported;
        public event Action<List<Newspaper>, string> NewspapersRawExported;

        public event Action<string> BooksXmlImported;
        public event Action<string> BooksRawImported;
        public event Action<string> JournalsXmlImported;
        public event Action<string> JournalsRawImported;
        public event Action<string> NewspapersXmlImported;
        public event Action<string> NewspapersRawImported;

        public MainForm()
        {
            InitializeComponent();            

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
            bool anyCurrentExists = false;


            if (selectedPage.Name == "tabPageBooks")
            {
                anyCurrentExists = Books.Any();
            }

            if (selectedPage.Name == "tabPageJournals")
            {
                anyCurrentExists = Journals.Any();                
            }

            if (selectedPage.Name == "tabPageNewspapers")
            {
                anyCurrentExists = Newspapers.Any();                
            }

            buttonSell.Enabled = anyCurrentExists;
            buttonUpdateSelected.Enabled = anyCurrentExists;
            buttonDeleteSelected.Enabled = anyCurrentExists;
            buttonExportFile.Enabled = anyCurrentExists;
            buttonExportXml.Enabled = anyCurrentExists;
        }

        private TabPage GetCurrentTabPage()
        {
            return tabControl.SelectedTab;
        }

        private Type GetSelectedType()
        {
            TabPage selectedPage = GetCurrentTabPage();
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
                buttonSell.Enabled = GetSelectedBooks().All(book => book.AvailableToBuy);                
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
                        book.Price,
                        book.Amount);
                }
            }
        }        

        private List<int> GetSelectedBookIds()
        {
            List<int> result = new List<int>();
            for (int i = 0; i < booksGridView.SelectedRows.Count; i++)
            {
                result.Add((int)booksGridView.SelectedRows[i].Cells["BookId"].Value);
            }
            return result;
        }

        private List<Book> GetSelectedBooks()
        {            
            return Books.Where(book => GetSelectedBookIds().Contains(book.Id)).ToList();
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
        private void OnBookSelled(Book obj)
        {
            BookSelled?.Invoke(obj);
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
                buttonSell.Enabled = GetSelectedJournals().All(journal => journal.AvailableToBuy);                
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
                        journal.Periodicity,
                        journal.Subjects,
                        journal.Date,                        
                        journal.Price,
                        journal.Amount);
                }
            }
        }

        private List<int> GetSelectedJournalIds()
        {
            List<int> result = new List<int>();
            for (int i = 0; i < journalsGridView.SelectedRows.Count; i++)
            {
                result.Add((int)journalsGridView.SelectedRows[i].Cells["JournalId"].Value);
            }
            return result;
        }

        private List<Journal> GetSelectedJournals()
        {
            return Journals.Where(journal => GetSelectedJournalIds().Contains(journal.Id)).ToList();
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

        private void OnJournalSelled(Journal obj)
        {
            JournalSelled?.Invoke(obj);
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
                buttonSell.Enabled = GetSelectedNewspapers().All(newspaper=>newspaper.AvailableToBuy);                
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
                        newspaper.Price,
                        newspaper.Amount);
                }
            }
        }

        private List<int> GetSelectedNewspaperIds()
        {
            List<int> result = new List<int>();
            for (int i = 0; i < newspapersGridView.SelectedRows.Count; i++)
            {
                result.Add((int)newspapersGridView.SelectedRows[i].Cells["NewspaperId"].Value);
            }
            return result;
        }

        private List<Newspaper> GetSelectedNewspapers()
        {
            return Newspapers.Where(newspaper => GetSelectedNewspaperIds().Contains(newspaper.Id)).ToList();
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

        private void OnNewspaperSelled(Newspaper obj)
        {
            NewspaperSelled?.Invoke(obj);
            OnNewspapersListUpdated();
        }

        private void OnNewspaperReturned(Newspaper obj)
        {
            NewspaperReturned?.Invoke(obj);
            OnNewspapersListUpdated();
        }

        #endregion

        #region Buttons handlers                
        private void ButtonSellClick(object sender, EventArgs e)
        {            
            Type selectedType = GetSelectedType();
            if (selectedType == typeof(Book))
            {
                List<Book> selectedBooks = GetSelectedBooks();

                foreach (Book selectedBook in selectedBooks)
                {
                    SellForm form = new SellForm(selectedBook.Price, $"Book {selectedBook.Title}-{selectedBook.Author} \n {selectedBook.Genre} \n {selectedBook.Year} \n {selectedBook.Pages}");
                    DialogResult dialogResult = form.ShowDialog(this);
                    if (dialogResult == DialogResult.OK)
                    {
                        OnBookSelled(selectedBook);
                    }
                    form.Dispose();
                }                
            }
            if (selectedType == typeof(Journal))
            {
                List<Journal> selectedJournals = GetSelectedJournals();

                foreach (Journal selectedJournal in selectedJournals)
                {
                    SellForm form = new SellForm(selectedJournal.Price, $"Journal {selectedJournal.Title}\n{selectedJournal.Periodicity}\n{selectedJournal.Subjects}\n{selectedJournal.Date}");
                    DialogResult dialogResult = form.ShowDialog(this);
                    if (dialogResult == DialogResult.OK)
                    {
                        OnJournalSelled(selectedJournal);
                    }
                    form.Dispose();
                }
            }
            if (selectedType == typeof(Newspaper))
            {
                List<Newspaper> selectedNewspapers = GetSelectedNewspapers();

                foreach (Newspaper selectedNewspaper in selectedNewspapers)
                {
                    SellForm form = new SellForm(selectedNewspaper.Price, $"Newspaper {selectedNewspaper.Title}\n{selectedNewspaper.Periodicity}\n{selectedNewspaper.Date}");
                    DialogResult dialogResult = form.ShowDialog(this);
                    if (dialogResult == DialogResult.OK)
                    {
                        OnNewspaperSelled(selectedNewspaper);
                    }
                    form.Dispose();
                }
            }
        }       
       
        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            Type selectedType = GetSelectedType();
            if (selectedType == typeof(Book))
            {
                GetSelectedBooks().ForEach(OnBookDeleted);
            }
            if (selectedType == typeof(Journal))
            {
                GetSelectedJournals().ForEach(OnJournalDeleted);
            }
            if (selectedType == typeof(Newspaper))
            {
                GetSelectedNewspapers().ForEach(OnNewspaperDeleted);
            }
        }
        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            if (GetSelectedType() == typeof(Book))
            {
                DesignBookForm form = new DesignBookForm();
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnBookCreated(form.ResultBook);
                }
                form.Dispose();
            }

            if (GetSelectedType() == typeof(Journal))
            {
                DesignJournalForm form = new DesignJournalForm();
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnJournalCreated(form.ResultJournal);
                }
                form.Dispose();
            }

            if (GetSelectedType() == typeof(Newspaper))
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
            if (GetSelectedType() == typeof(Book))
            {
                List<Book> selectedBooks = GetSelectedBooks();
                foreach (Book selectedBook in selectedBooks)
                {
                    DesignBookForm form = new DesignBookForm(selectedBook);
                    DialogResult dialogResult = form.ShowDialog(this);
                    if (dialogResult == DialogResult.OK)
                    {
                        OnBookUpdated(form.ResultBook);
                    }
                    form.Dispose();
                }
            }

            if(GetSelectedType() == typeof(Journal))
            {
                List<Journal> selectedJournals = GetSelectedJournals();
                foreach (Journal selectedJournal in selectedJournals)
                {
                    DesignJournalForm form = new DesignJournalForm(selectedJournal);
                    DialogResult dialogResult = form.ShowDialog(this);
                    if (dialogResult == DialogResult.OK)
                    {
                        OnJournalUpdated(form.ResultJournal);
                    }
                    form.Dispose();
                }
            }

            if (GetSelectedType() == typeof(Newspaper))
            {
                List<Newspaper> selectedNewspapers = GetSelectedNewspapers();
                foreach (Newspaper selectedNewspaper in selectedNewspapers)
                {
                    DesignNewspaperForm form = new DesignNewspaperForm(selectedNewspaper);
                    DialogResult dialogResult = form.ShowDialog(this);
                    if (dialogResult == DialogResult.OK)
                    {
                        OnNewspaperUpdated(form.ResultNewspaper);
                    }
                    form.Dispose();
                }
            }
        }
        #endregion
        
        
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedPage = GetCurrentTabPage();

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

        private void buttonExportXml_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".xml",
                AddExtension = true,
                CheckPathExists = true,
                CreatePrompt = true,
                OverwritePrompt = true,
                Filter = "Xml files (*.xml)|*.xml"
            };
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                Type selectedType = GetSelectedType();
                if (selectedType == typeof(Book))
                {
                    OnBooksXmlExported(GetSelectedBooks(), saveFileDialog.FileName);
                }                
                if (selectedType == typeof(Journal))
                {
                    OnJournalsXmlExported(GetSelectedJournals(), saveFileDialog.FileName);
                }
                if (selectedType == typeof(Newspaper))
                {
                    OnNewspapersXmlExported(GetSelectedNewspapers(), saveFileDialog.FileName);
                }
            }
        }        

        private void buttonExportFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".txt",
                AddExtension = true,
                CheckPathExists = true,
                CreatePrompt = true,
                OverwritePrompt = true,
                Filter = "Text files (*.txt)|*.txt"
            };
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                Type selectedType = GetSelectedType();
                if (selectedType == typeof(Book))
                {
                    OnBooksRawExported(GetSelectedBooks(), saveFileDialog.FileName);
                }
                if (selectedType == typeof(Journal))
                {
                    OnJournalsRawExported(GetSelectedJournals(), saveFileDialog.FileName);
                }
                if (selectedType == typeof(Newspaper))
                {
                    OnNewspapersRawExported(GetSelectedNewspapers(), saveFileDialog.FileName);
                }
            }
        }

        private void buttonImportXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                DefaultExt = ".xml",
                AddExtension = true,
                CheckPathExists = true,
                Filter = "Xml files (*.xml)|*.xml"
            };
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                Type selectedType = GetSelectedType();
                if (selectedType == typeof(Book))
                {
                    OnBooksXmlImported(openFileDialog.FileName);
                    OnBooksListUpdated();
                }
                if (selectedType == typeof(Journal))
                {
                    OnJournalsXmlImported(openFileDialog.FileName);
                    OnJournalsListUpdated();
                }
                if (selectedType == typeof(Newspaper))
                {
                    OnNewspapersXmlImported(openFileDialog.FileName);
                    OnNewspapersListUpdated();
                }
            }            
        }

        private void buttonImportFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    DefaultExt = ".txt",
                    AddExtension = true,
                    CheckPathExists = true,
                    Filter = "Text files (*.txt)|*.txt"
                };
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    Type selectedType = GetSelectedType();
                    if (selectedType == typeof(Book))
                    {
                        OnBooksRawImported(openFileDialog.FileName);
                        OnBooksListUpdated();
                    }
                    if (selectedType == typeof(Journal))
                    {
                        OnJournalsRawImported(openFileDialog.FileName);
                        OnJournalsListUpdated();
                    }
                    if (selectedType == typeof(Newspaper))
                    {
                        OnNewspapersRawImported(openFileDialog.FileName);
                        OnNewspapersListUpdated();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnBooksXmlExported(List<Book> obj, string path)
        {
            BooksXmlExported?.Invoke(obj, path);
        }
        private void OnBooksRawExported(List<Book> books, string path)
        {
            BooksRawExported?.Invoke(books, path);
        }

        private void OnJournalsXmlExported(List<Journal> journals, string path)
        {
            JournalsXmlExported?.Invoke(journals, path);
        }

        private void OnJournalsRawExported(List<Journal> journals, string path)
        {
            JournalsRawExported?.Invoke(journals, path);
        }

        private void OnNewspapersXmlExported(List<Newspaper> newspapers, string path)
        {
            NewspapersXmlExported?.Invoke(newspapers, path);
        }

        private void OnNewspapersRawExported(List<Newspaper> newspapers, string path)
        {
            NewspapersRawExported?.Invoke(newspapers, path);
        }


        private void OnBooksXmlImported(string path)
        {
            BooksXmlImported?.Invoke(path);
        }

        private void OnBooksRawImported(string path)
        {
            BooksRawImported?.Invoke(path);
        }

        private void OnJournalsXmlImported(string path)
        {
            JournalsXmlImported?.Invoke(path);
        }

        private void OnJournalsRawImported(string path)
        {
            JournalsRawImported?.Invoke(path);
        }

        private void OnNewspapersXmlImported(string path)
        {
            NewspapersXmlImported?.Invoke(path);
        }

        private void OnNewspapersRawImported(string path)
        {
            NewspapersRawImported?.Invoke(path);
        }        
    }
}
