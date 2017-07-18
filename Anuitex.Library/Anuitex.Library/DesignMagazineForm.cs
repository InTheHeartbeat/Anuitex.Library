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
    public partial class DesignMagazineForm : Form
    {

        public Magazine ResultMagazine => _magazine;

        private Magazine _magazine;

        public DesignMagazineForm()
        {
            InitializeComponent();
        }

        public DesignMagazineForm(Magazine magazine)
        {
            InitializeComponent();
            this._magazine = magazine;
            InitializeForUpdate();
        }

        private void InitializeForUpdate()
        {
            textBoxTitle.Text = _magazine.Title;
            textBoxPeriodicity.Text = _magazine.Periodicity;
            textBoxSubjects.Text = _magazine.Subjects;
            textBoxDate.Text = _magazine.Date;            

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

            _magazine = new Magazine()
            {
                Id = _magazine?.Id ?? 0,
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
