using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anuitex.Library.Base.Helpers
{
    public class FormValidateHelper
    {
        public static bool DesignJournalValidateInputs(DesignJournalForm form)
        {
            if (string.IsNullOrWhiteSpace(form.textBoxTitle.Text))
            {
                MessageBox.Show("Fied \"Title\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxSubjects.Text))
            {
                MessageBox.Show("Fied \"Subjects\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxPeriodicity.Text))
            {
                MessageBox.Show("Fied \"Periodicity\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxDate.Text))
            {
                MessageBox.Show("Fied \"Date\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxPrice.Text))
            {
                MessageBox.Show("Fied \"Price\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxAmount.Text))
            {
                MessageBox.Show("Fied \"Amount\" must be filled");
                return false;
            }
            return true;
        }

        public static bool DesignBookValidateInputs(DesignBookForm form)
        {
            if (string.IsNullOrWhiteSpace(form.textBoxTitle.Text))
            {
                MessageBox.Show("Fied \"Title\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxAuthor.Text))
            {
                MessageBox.Show("Fied \"Author\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxGenre.Text))
            {
                MessageBox.Show("Fied \"Genre\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxYear.Text))
            {
                MessageBox.Show("Fied \"Year\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxPages.Text))
            {
                MessageBox.Show("Fied \"Pages\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxPrice.Text))
            {
                MessageBox.Show("Fied \"Price\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxAmount.Text))
            {
                MessageBox.Show("Fied \"Amount\" must be filled");
                return false;
            }
            return true;
        }

        public static bool DesignNewspaperValidateInputs(DesignNewspaperForm form)
        {
            if (string.IsNullOrWhiteSpace(form.textBoxTitle.Text))
            {
                MessageBox.Show("Fied \"Title\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxPeriodicity.Text))
            {
                MessageBox.Show("Fied \"Periodicity\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxDate.Text))
            {
                MessageBox.Show("Fied \"Date\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxAmount.Text))
            {
                MessageBox.Show("Fied \"Amount\" must be filled");
                return false;
            }
            if (string.IsNullOrWhiteSpace(form.textBoxPrice.Text))
            {
                MessageBox.Show("Fied \"Price\" must be filled");
                return false;
            }

            return true;
        }
    }
}
