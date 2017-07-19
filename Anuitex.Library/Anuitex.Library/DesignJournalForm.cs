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

            buttonBuild.Text = "Update";
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Fied \"Title\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxSubjects.Text))
            {
                MessageBox.Show("Fied \"Subjects\" must be filled");
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

            _journal = new Journal()
            {
                Id = _journal?.Id ?? 0,
                Title = textBoxTitle.Text,
                Periodicity = textBoxPeriodicity.Text,
                Subjects = textBoxSubjects.Text,
                Date= textBoxDate.Text,                
                Available = true
            };
            this.DialogResult = DialogResult.OK;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxTitle.Text = String.Empty;
            textBoxPeriodicity.Text = String.Empty;
            textBoxSubjects.Text = String.Empty;
            textBoxDate.Text = String.Empty;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
