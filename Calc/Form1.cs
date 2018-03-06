using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;


namespace Calc
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            InitializeComponent();
        }
        //
        //NUMBERS
        //

        private void buttonOne_Click(object sender, EventArgs e)
        {
            if (textEkran.Text.StartsWith("0") && !textEkran.Text.StartsWith("0."))
                textEkran.Text = String.Empty;
            textEkran.Text += (sender as Button).Text;
        }

        //(NIE)mozliwe przypadki
        //-
        //00000
        private void buttonZero_Click(object sender, EventArgs e)
        {
            if (textEkran.Text != "-0" && textEkran.Text != "0") 
                textEkran.Text += (sender as Button).Text;
        }
        //
        //Operators
        //
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textEkran.Text))
            {
                if(!string.IsNullOrWhiteSpace(labelTemp.Text) && labelTemp.Text != "-" )
                {
                    buttonEqualization_Click(sender, e);
                }
                if (textEkran.Text == "0.")
                    this.CalcValue = 0;
                else
                    this.CalcValue = double.Parse(textEkran.Text);
                labelTemp.Text = this.CalcValue.ToString();
                labelTemp.Text += (sender as Button).Text.ToString();
                textEkran.Text = String.Empty;
            }
            else
                textEkran.Text = (sender as Button).Text.ToString();

        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textEkran.Text))
            {
                if (!string.IsNullOrWhiteSpace(labelTemp.Text) && labelTemp.Text != "-")
                {
                    buttonEqualization_Click(sender, e);
                }
                if (textEkran.Text == "0.")
                    this.CalcValue = 0;
                else
                    this.CalcValue = double.Parse(textEkran.Text);
                labelTemp.Text = this.CalcValue.ToString();
                labelTemp.Text += (sender as Button).Text.ToString();

            }
            textEkran.Text = String.Empty;
            if (labelTemp.Text.Length > 1)
                if (labelTemp.Text.Substring(labelTemp.Text.Length - 1) != (sender as Button).Text)
                    labelTemp.Text = labelTemp.Text.Remove(labelTemp.Text.Length - 1, 1) + (sender as Button).Text;
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textEkran.Text))
            {
                if (!string.IsNullOrWhiteSpace(labelTemp.Text) && labelTemp.Text != "-")
                {
                    buttonEqualization_Click(sender, e);
                }
                if (textEkran.Text == "0.")
                    this.CalcValue = 0;
                else
                    this.CalcValue = double.Parse(textEkran.Text);
                labelTemp.Text = this.CalcValue.ToString();
                labelTemp.Text += (sender as Button).Text.ToString();

            }
            textEkran.Text = String.Empty;
            if (labelTemp.Text.Length > 1)
                if (labelTemp.Text.Substring(labelTemp.Text.Length - 1) != (sender as Button).Text)
                    labelTemp.Text = labelTemp.Text.Remove(labelTemp.Text.Length - 1, 1) + (sender as Button).Text;
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textEkran.Text))
            {
                if (!string.IsNullOrWhiteSpace(labelTemp.Text) && labelTemp.Text != "-")
                {
                    buttonEqualization_Click(sender, e);
                }
                if (textEkran.Text == "0.") 
                    this.CalcValue = 0;
                else
                    this.CalcValue = double.Parse(textEkran.Text);
                labelTemp.Text = this.CalcValue.ToString();
                labelTemp.Text += (sender as Button).Text.ToString();

            }
            textEkran.Text = String.Empty;
            if(labelTemp.Text.Length>1)
                if (labelTemp.Text.Substring(labelTemp.Text.Length - 1) != (sender as Button).Text)
                    labelTemp.Text = labelTemp.Text.Remove(labelTemp.Text.Length - 1, 1) + (sender as Button).Text;
        }

        private void buttonEqualization_Click(object sender, EventArgs e)
        {
            if (textEkran.Text != "")
            {
                double temp;
                if (labelTemp.Text.EndsWith("+"))
                {
                    if (Double.TryParse(textEkran.Text, out temp))
                        CalcValue = CalcValue + temp;
                }
                else if (labelTemp.Text.EndsWith("-"))
                {
                    if (Double.TryParse(textEkran.Text, out temp))
                        CalcValue = CalcValue - temp;
                }
                else if (labelTemp.Text.EndsWith("*"))
                {
                    if(Double.TryParse(textEkran.Text, out temp))
                        CalcValue = CalcValue * temp;
                }
                else if (labelTemp.Text.EndsWith("/") && textEkran.Text != "0" && textEkran.Text != "0." && textEkran.Text != "-0." && textEkran.Text != "-0" && textEkran.Text != "-")
                {
                 
                    if (Double.TryParse(textEkran.Text, out temp))
                        CalcValue = CalcValue / temp;
                        
  
                }
                else if(textEkran.Text == "0" || textEkran.Text == "0." || textEkran.Text == "-0." || textEkran.Text == "-0" || textEkran.Text == "-")
                    labelTemp.Text = "Division by zero!";
            }
            textEkran.Text = CalcValue.ToString();
            if (labelTemp.Text != "Division by zero!")
                labelTemp.Text = String.Empty;
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!textEkran.Text.Contains('.'))
            {
                if (string.IsNullOrEmpty(textEkran.Text))
                    textEkran.Text = "0" + (sender as Button).Text;
                else
                    textEkran.Text += (sender as Button).Text;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textEkran.Text))
                textEkran.Text = textEkran.Text.Remove(textEkran.Text.Length - 1, 1);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            CalcValue = 0;
            textEkran.Text = "0";
            labelTemp.Text =  string.Empty;
        }

        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textEkran.Text))
                if (textEkran.Text.StartsWith("-"))
                    textEkran.Text = textEkran.Text.Remove(0, 1);
                else
                    textEkran.Text = "-" + textEkran.Text;
        }
    }   
}
