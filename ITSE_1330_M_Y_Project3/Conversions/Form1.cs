using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[,] conversionTable = {
            {"Miles to kilometers", "Miles", "Kilometers", "1.6093"},
            {"Kilometers to miles", "Kilometers", "Miles", "0.6214"},
            {"Feet to meters", "Feet", "Meters", "0.3048"},
            {"Meters to feet", "Meters", "Feet", "3.2808"},
            {"Inches to centimeters", "Inches", "Centimeters", "2.54"},
            {"Centimeters to inches", "Centimeters", "Inches", "0.3937"}

        };

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsDecimal(TextBox textBox, string name)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(name + " must be a decimal number.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboConversions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cboConversions.SelectedIndex;
            string fromText = conversionTable[idx, 1];
            string toText = conversionTable[idx, 2];
            lblFromLength.Text = fromText;
            lblToLength.Text = toText;
            lblCalculatedLength.Text = "";
            txtLength.Text = "";
            txtLength.Focus();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < conversionTable.GetLength(0); i++)
            {
                string conversion = conversionTable[i, 0];
                cboConversions.Items.Add(conversion);
            }
            cboConversions.SelectedIndex = 0;
            txtLength.Focus();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

            if (this.IsDecimal(txtLength, lblFromLength.Text) && this.IsPresent(txtLength, lblFromLength.Text))
            {
                decimal userInput = Convert.ToDecimal(txtLength.Text);
                int calcIndex = cboConversions.SelectedIndex;

                string conversionString = conversionTable[calcIndex, 3];
                decimal conversionNumber = Convert.ToDecimal(conversionString);
                decimal calculation = conversionNumber * userInput;
                string calculationString = calculation.ToString("G");
                lblCalculatedLength.Text = calculationString;
            }

        }

    }
}