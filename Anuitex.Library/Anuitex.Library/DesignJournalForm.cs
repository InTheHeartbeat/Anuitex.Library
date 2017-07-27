using Anuitex.Library.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anuitex.Library.Base.Helpers;
using Anuitex.Library.Data.Entities;

namespace Anuitex.Library
{
    public partial class DesignJournalForm : Form
    {
        public Journal ResultJournal => _journal;

        private Journal _journal;

        public DesignJournalForm()
        {
            InitializeComponent();
        }

        public DesignJournalForm(Journal journal)
        {
            InitializeComponent();
            this._journal = journal;
            InitializeForUpdate();
        }

        private void InitializeForUpdate()
        {
            textBoxTitle.Text = _journal.Title;
            textBoxPeriodicity.Text = _journal.Periodicity;
            textBoxSubjects.Text = _journal.Subjects;
            textBoxDate.Text = _journal.Date;
            textBoxPrice.Text = _journal.Price.ToString();
            textBoxAmount.Text = _journal.Amount.ToString();            

            buttonBuild.Text = "Update";
        }        

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (!FormValidateHelper.DesignJournalValidateInputs(this)) return;

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

            _journal = new Journal()
            {
                Id = _journal?.Id ?? 0,
                Title = textBoxTitle.Text,
                Periodicity = textBoxPeriodicity.Text,
                Subjects = textBoxSubjects.Text,
                Date= textBoxDate.Text,
                Amount = amount,
                Price = price
            };
            this.DialogResult = DialogResult.OK;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxTitle.Text = String.Empty;
            textBoxPeriodicity.Text = String.Empty;
            textBoxSubjects.Text = String.Empty;
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
