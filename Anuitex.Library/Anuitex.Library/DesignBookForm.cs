using System;
using System.Windows.Forms;
using Anuitex.Library.Base.Helpers;
using Anuitex.Library.Data;
using Anuitex.Library.Data.Entities;

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
            textBoxPrice.Text = _book.Price.ToString();
            textBoxAmount.Text = _book.Amount.ToString();

            buttonBuild.Text = "Update";
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {                       
            if(!FormValidateHelper.DesignBookValidateInputs(this)) return;

            int year = 0;
            int pages = 0;
            float price = 0;
            int amount = 0;

            if (!int.TryParse(textBoxYear.Text, out year))
            {
                MessageBox.Show("Incorrect field \"Year\"");
                return;
            }
            if (!int.TryParse(textBoxPages.Text, out pages))
            {
                MessageBox.Show("Incorrect field \"Pages\"");
            }
            if (!float.TryParse(textBoxPrice.Text, out price))
            {
                MessageBox.Show("Incorrect field \"Price\"");
                return;
            }
            if (!int.TryParse(textBoxAmount.Text, out amount))
            {
                MessageBox.Show("Incorrect field \"Amount\"");
            }


            _book = new Book()
            {
                Id = _book?.Id ?? 0,
                Title = textBoxTitle.Text,
                Author = textBoxAuthor.Text,
                Genre = textBoxGenre.Text,
                Year = year,
                Pages = pages,
                Amount = amount,
                Price = price
            };
            this.DialogResult = DialogResult.OK;                        
        }
        
        
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxAuthor.Text = String.Empty;
            textBoxTitle.Text = String.Empty;
            textBoxGenre.Text = String.Empty;
            textBoxYear.Text = String.Empty;
            textBoxPages.Text = String.Empty;
            textBoxAmount.Text = String.Empty;
            textBoxPrice.Text = String.Empty;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
