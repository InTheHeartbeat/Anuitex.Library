using Anuitex.Library.Data;
using System;
using System.Windows.Forms;
using Anuitex.Library.Base.Helpers;
using Anuitex.Library.Data.Entities;

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
            textBoxPrice.Text = _newspaper.Price.ToString();
            textBoxAmount.Text = _newspaper.Amount.ToString();

            buttonBuild.Text = "Update";
        }

        

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (!FormValidateHelper.DesignNewspaperValidateInputs(this)) return;

            float price = 0;
            int amount = 0;

            if (!float.TryParse(textBoxPrice.Text, out price))
            {
                MessageBox.Show("Incorrect field \"Price\"");
                return;
            }
            if (!int.TryParse(textBoxAmount.Text, out amount))
            {
                MessageBox.Show("Incorrect field \"Amount\"");
            }

            _newspaper = new Newspaper()
            {
                Id = _newspaper?.Id ?? 0,
                Title = textBoxTitle.Text,
                Periodicity = textBoxPeriodicity.Text,
                Date = textBoxDate.Text,
                Amount = amount,
                Price = price
            };
            this.DialogResult = DialogResult.OK;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxTitle.Text = String.Empty;
            textBoxPeriodicity.Text = String.Empty;            
            textBoxDate.Text = String.Empty;
            textBoxPrice.Text = String.Empty;
            textBoxAmount.Text = String.Empty;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
