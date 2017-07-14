using System;
using System.Windows.Forms;
using Anuitex.Library.Data;

namespace Anuitex.Library
{
    public partial class DesignBookForm : Form
    {
        public Book ResultBook => _book;

        private Book _book;
        public DesignBookForm() 
        {
            InitializeComponent();
        }

        public DesignBookForm(Book book)
        {
            InitializeComponent();

            this._book = book;
            InitializeForUpdate();
        }

        private void InitializeForUpdate()
        {
            textBoxTitle.Text = _book.Title;
            textBoxAuthor.Text = _book.Author;
            textBoxGenre.Text = _book.Genre;
            textBoxPages.Text = _book.Pages.ToString();
            textBoxYear.Text = _book.Year.ToString();

            buttonBuild.Text = "Update";
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {                       
            if(!ValidateInputs()) return;

            int year = 0;
            int pages = 0;

            if (!int.TryParse(textBoxYear.Text, out year))
            {
                MessageBox.Show("Incorrect field \"Year\"");
                return;
            }
            if (!int.TryParse(textBoxPages.Text, out pages))
            {
                MessageBox.Show("Incorrect field \"Pages\"");
            }

            _book = new Book()
            {
                Id = _book?.Id ?? 0,
                Title = textBoxTitle.Text,
                Author = textBoxAuthor.Text,
                Genre = textBoxGenre.Text,
                Year = year,
                Pages = pages,
                Available = true
            };
            this.DialogResult = DialogResult.OK;                        
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Fied \"Title\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxAuthor.Text))
            {
                MessageBox.Show("Fied \"Author\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxGenre.Text))
            {
                MessageBox.Show("Fied \"Genre\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxYear.Text))
            {
                MessageBox.Show("Fied \"Year\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxPages.Text))
            {
                MessageBox.Show("Fied \"Pages\" must be filled");
                return false;
            }
            return true;
        }
        
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxAuthor.Text = String.Empty;
            textBoxTitle.Text = String.Empty;
            textBoxGenre.Text = String.Empty;
            textBoxYear.Text = String.Empty;
            textBoxPages.Text = String.Empty;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
