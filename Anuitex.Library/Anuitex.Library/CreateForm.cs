using System;
using System.Windows.Forms;
using Anuitex.Library.Data;

namespace Anuitex.Library
{
    public partial class CreateForm : Form
    {
        public event Action<Book> BookCreated; 


        public CreateForm()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
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

            Book result = new Book()
            {
                Title = textBoxTitle.Text,
                Author = textBoxAuthor.Text,
                Genre = textBoxGenre.Text,
                Year = year,
                Pages = pages,
                Available = true
            };

            OnBookCreated(result);
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

        protected virtual void OnBookCreated(Book obj)
        {
            BookCreated?.Invoke(obj);
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
