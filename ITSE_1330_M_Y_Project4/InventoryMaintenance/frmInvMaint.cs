using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    
    public partial class frmInvMaint : Form
    {
        public frmInvMaint()
        {
            InitializeComponent();
        }

        // Add a statement here that declares the list of items.
        private List<InvItem> invItems = null;

        private void frmInvMaint_Load(object sender, EventArgs e)
        {
            // Add a statement here that gets the list of items.
            invItems = InvItemDB.GetItems();
            FillItemListBox();
        }

        private void FillItemListBox()
        {
            lstItems.Items.Clear();
            // Add code here that loads the list box with the items in the list.
            foreach (InvItem i in invItems)
            {
                lstItems.Items.Add(i.GetDisplayText("\t"));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add code here that creates an instance of the New Item form
            // and then gets a new item from that form.

            frmNewItem newInvItemForm = new frmNewItem();
            InvItem invItem = newInvItemForm.GetNewInvItem();
            if (invItem != null)
            {
                invItems.Add(invItem);
                InvItemDB.SaveItems(invItems);
                FillItemListBox();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstItems.SelectedIndex;
            if (i != -1)
            {
                // Add code here that displays a dialog box to confirm
                // the deletion and then removes the item from the list,
                // saves the list of products, and refreshes the list box
                // if the deletion is confirmed.

                int t = lstItems.SelectedIndex;
                if (t != -1)
                {
                    InvItem invItem = invItems[t];
                    string message = "Are you sure you want to delete " + invItem.Description + "?";
                    DialogResult button = MessageBox.Show(message, "Confirm Deletion", MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                    {
                        invItems.Remove(invItem);
                        InvItemDB.SaveItems(invItems);
                        FillItemListBox();
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class InvItem
    {
        private int itemNo;
        private string description;
        private decimal price;

        public InvItem()
        {
        }

        public InvItem(int itemNo, string description, decimal price)
        {
            this.ItemNo = itemNo;
            this.Description = description;
            this.Price = price;
        }
        public int ItemNo
        {
            get
            {
                return itemNo;
            }
            set
            {
                itemNo = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public string GetDisplayText(string sep)
        {
            return ItemNo.ToString(format: "d7") + "    " + description + " " + "(" + price.ToString("c") + ")";
        }

    }
}