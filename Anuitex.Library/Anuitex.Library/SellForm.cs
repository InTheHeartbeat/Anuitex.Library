using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anuitex.Library
{
    public partial class SellForm : Form
    {
        private double _price;

        public SellForm(double price, string item)
        {
            InitializeComponent();

            labelItem.Text = item;
            labelPrice.Text = price.ToString(CultureInfo.InvariantCulture);

            _price = price;
        }

        private void buttonConfirmSell_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMoney.Text))
            {
                MessageBox.Show("Field 'Money' most be filled");
                return;
            }

            double money;

            if (!double.TryParse(textBoxMoney.Text, out money))
            {
                MessageBox.Show("Incorrect field 'Money'");
                return;
            }

            if (money < _price)
            {
                MessageBox.Show("Money should be more than the price");
                return;
            }

            if (money > _price)
            {
                MessageBox.Show($"Delivery {money - _price}");
            }

            DialogResult = DialogResult.OK;
        }
    }
}
