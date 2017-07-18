using Anuitex.Library.Data;
using System;
using System.Windows.Forms;

namespace Anuitex.Library
{
    public partial class DesignNewspaperForm : Form
    {
        public Newspaper ResultNewspaper => _newspaper;
        private Newspaper _newspaper;

        public DesignNewspaperForm()
        {
            InitializeComponent();
        }

        public DesignNewspaperForm(Newspaper newspaper)
        {
            InitializeComponent();
            this._newspaper = newspaper;
            InitializeForUpdate();
        }
        private void InitializeForUpdate()
        {
            textBoxTitle.Text = _newspaper.Title;
            textBoxPeriodicity.Text = _newspaper.Periodicity;            
            textBoxDate.Text = _newspaper.Date;

            buttonBuild.Text = "Update";
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Fied \"Title\" must be filled");
                return false;
            }            
            if (string.IsNullOrWhiteSpace(textBoxPeriodicity.Text))
            {
                MessageBox.Show("Fied \"Periodicity\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxDate.Text))
            {
                MessageBox.Show("Fied \"Date\" must be filled");
                return false;
            }

            return true;
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            _newspaper = new Newspaper()
            {
                Id = _newspaper?.Id ?? 0,
                Title = textBoxTitle.Text,
                Periodicity = textBoxPeriodicity.Text,                
                Date = textBoxDate.Text,
                Available = true
            };
            this.DialogResult = DialogResult.OK;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxTitle.Text = String.Empty;
            textBoxPeriodicity.Text = String.Empty;            
            textBoxDate.Text = String.Empty;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
