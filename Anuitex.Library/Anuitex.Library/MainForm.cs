using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Anuitex.Library.Base.Enums;
using Anuitex.Library.Data.Entities;
using Anuitex.Library.Data.Interfaces;

namespace Anuitex.Library
{
    public sealed partial class MainForm : Form
    {
        public List<Book> Books;
        public List<Journal> Journals;
        public List<Newspaper> Newspapers;
        
        public event Action<Type> DataUpdated;
        public event Action<ILibraryEntity> CreatedEntity;
        public event Action<ILibraryEntity> DeletedEntity;
        public event Action<ILibraryEntity> UpdatedEntity;
        public event Action<ILibraryEntity> SelledEntity;                

        public event Action<List<ILibraryEntity>, string, FileStorageType> Exported;                
        public event Action<Type,string, FileStorageType> Imported;        
        
        public MainForm()
        {
            InitializeComponent();            

            Books = new List<Book>();   
            Journals = new List<Journal>();
            Newspapers = new List<Newspaper>();                    
        }

        public new void Show()
        {
            OnDataUpdated(GetSelectedType());
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

        private List<ILibraryEntity> GetSelectedEntities()
        {
            Type selectedType = GetSelectedType();
            if (selectedType == typeof(Book))
            {
                return new List<ILibraryEntity>(GetSelectedBooks());
            }
            if (selectedType == typeof(Journal))
            {
                return new List<ILibraryEntity>(GetSelectedJournals());
            }
            if (selectedType == typeof(Newspaper))
            {
                return new List<ILibraryEntity>(GetSelectedNewspapers());
            }
            return null;
        }


        private void UpdateCurrentDataGrid()
        {
            Type current = GetSelectedType();
            if (current == typeof(Book))
            {
                UpdateBooksGridView();
            }
            if (current == typeof(Journal))
            {
                UpdateJournalsGridView();
            }
            if (current == typeof(Newspaper))
            {
                UpdateNewspapersGridView();
            }
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
        #endregion

        #region Buttons handlers                

        private void ButtonSellClick(object sender, EventArgs e)
        {
            SellForm form = new SellForm(GetSelectedEntities());
            DialogResult dialogResult = form.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                form.SelledEntities.ForEach(OnSelledEntity);   
            }

            form.Dispose();
        }

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {            
            GetSelectedEntities().ForEach(OnDeletedEntity);
        }
        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            if (GetSelectedType() == typeof(Book))
            {
                DesignBookForm form = new DesignBookForm();
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnCreatedEntity(form.ResultBook);
                }
                form.Dispose();
            }

            if (GetSelectedType() == typeof(Journal))
            {
                DesignJournalForm form = new DesignJournalForm();
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnCreatedEntity(form.ResultJournal);
                }
                form.Dispose();
            }

            if (GetSelectedType() == typeof(Newspaper))
            {
                DesignNewspaperForm form = new DesignNewspaperForm();
                DialogResult dialogResult = form.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    OnCreatedEntity(form.ResultNewspaper);
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
                        OnUpdatedEntity(form.ResultBook);
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
                        OnUpdatedEntity(form.ResultJournal);
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
                        OnUpdatedEntity(form.ResultNewspaper);
                    }
                    form.Dispose();
                }
            }
        }
        #endregion
        
        
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedPage = GetCurrentTabPage();
            OnDataUpdated(GetSelectedType());
            if (selectedPage.Name == "tabPageBooks")
            {                
                buttonAdd.Text = "Add new book";
                buttonDeleteSelected.Text = "Delete selected book";                
                buttonUpdateSelected.Text = "Update selected book";                
            }

            if (selectedPage.Name == "tabPageJournals")
            {
                buttonAdd.Text = "Add new journal";
                buttonDeleteSelected.Text = "Delete selected journal";
                buttonUpdateSelected.Text = "Update selected journal";                
            }

            if (selectedPage.Name == "tabPageNewspapers")
            {
                buttonAdd.Text = "Add new newspaper";
                buttonDeleteSelected.Text = "Delete selected newspaper";
                buttonUpdateSelected.Text = "Update selected newspaper";                
            }
            UpdateCurrentDataGrid();
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
                try
                {
                    OnExported(GetSelectedEntities(), saveFileDialog.FileName, FileStorageType.Xml);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error");
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
                try
                {
                    OnExported(GetSelectedEntities(), saveFileDialog.FileName, FileStorageType.Raw);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error");
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
                try
                {
                    OnImported(GetSelectedType(), openFileDialog.FileName, FileStorageType.Xml);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error");
                }
            }
        }

        private void buttonImportFile_Click(object sender, EventArgs e)
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
                try
                {
                    OnImported(GetSelectedType(), openFileDialog.FileName, FileStorageType.Raw);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OnDataUpdated(Type obj)
        {
            DataUpdated?.Invoke(obj);
            UpdateCurrentDataGrid();
        }

        private void OnCreatedEntity(ILibraryEntity obj)
        {
            CreatedEntity?.Invoke(obj);
            OnDataUpdated(obj.GetType());
        }

        private void OnDeletedEntity(ILibraryEntity obj)
        {
            DeletedEntity?.Invoke(obj);
            OnDataUpdated(obj.GetType());
        }

        private void OnUpdatedEntity(ILibraryEntity obj)
        {
            UpdatedEntity?.Invoke(obj);
            OnDataUpdated(obj.GetType());
        }

        private void OnSelledEntity(ILibraryEntity obj)
        {
            SelledEntity?.Invoke(obj);
            OnDataUpdated(obj.GetType());
        }


        private void OnExported(List<ILibraryEntity> arg1, string arg2, FileStorageType arg3)
        {
            Exported?.Invoke(arg1, arg2, arg3);
        }

        private void OnImported(Type arg1, string arg2, FileStorageType arg3)
        {
            Imported?.Invoke(arg1, arg2, arg3);
            OnDataUpdated(arg1);
        }
    }
}
