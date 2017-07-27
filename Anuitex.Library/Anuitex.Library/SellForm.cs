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
using Anuitex.Library.Data.Interfaces;

namespace Anuitex.Library
{
    public partial class SellForm : Form
    {
        public List<ILibraryEntity> SelledEntities;

        private double totalPrice;

        private List<ILibraryEntity> checkedItems;

        public SellForm(List<ILibraryEntity> list)
        {
            InitializeComponent();            
            checkedItems = new List<ILibraryEntity>();
            sellEntitiesListBox.ItemCheck += SellEntitiesListBox_ItemCheck;

            sellEntitiesListBox.Items.AddRange(list.ToArray());
            
            for (var i = 0; i < sellEntitiesListBox.Items.Count; i++)
            {
                sellEntitiesListBox.SetItemChecked(i,true);
            }
            CalcTotalPrice();

            
        }

        private void SellEntitiesListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedItems = sellEntitiesListBox.CheckedItems.Cast<ILibraryEntity>().ToList();
            if (e.NewValue == CheckState.Checked)
            {
                if (!checkedItems.Contains(sellEntitiesListBox.Items[e.Index]))
                {
                    checkedItems.Add((ILibraryEntity) sellEntitiesListBox.Items[e.Index]);
                }
            }
            if (e.NewValue == CheckState.Unchecked)
            {
                if (checkedItems.Contains(sellEntitiesListBox.Items[e.Index]))
                {
                    checkedItems.Remove((ILibraryEntity) sellEntitiesListBox.Items[e.Index]);
                }
            }
            CalcTotalPrice();
        }

        private void CalcTotalPrice()
        {            
            totalPrice = checkedItems.Sum(e => e.Price);
            labelPrice.Text = totalPrice.ToString();
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

            if (money < totalPrice)
            {
                MessageBox.Show("Money should be more than the price");
                return;
            }

            if (money > totalPrice)
            {
                MessageBox.Show($"Delivery {money - totalPrice}");
            }

            SelledEntities = checkedItems;
            DialogResult = DialogResult.OK;
        }
    }
}
