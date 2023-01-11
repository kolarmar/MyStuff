using System.Data;
using System.Linq.Expressions;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private bool calculated = false;
        private string lastAnswer;


        public Form1()
        {
            InitializeComponent();
        }

        private void numberZeroButton_Click(object sender, EventArgs e)
        {
            if (calculated)
            {
                mainTextBox.Text = string.Empty;
            }
            mainTextBox.Text += "0";
            calculated = false;
        }

        private void numberOneButton_Click(object sender, EventArgs e)
        {
            if (calculated)
            {
                mainTextBox.Text = string.Empty;
            }
            mainTextBox.Text += "1";
            calculated = false;
        }

        private void numberTwoButton_Click(object sender, EventArgs e)
        {
            if (calculated)
            {
                mainTextBox.Text = string.Empty;
            }
            mainTextBox.Text += "2";
            calculated = false;
        }

        private void numberThreeButton_Click(object sender, EventArgs e)
        {
            if (calculated)
            {
                mainTextBox.Text = string.Empty;
            }
            mainTextBox.Text += "3";
            calculated = false;
        }

        private void numberFourButton_Click(object sender, EventArgs e)
        {
            if (calculated)
            {
                mainTextBox.Text = string.Empty;
            }
            mainTextBox.Text += "4";
            calculated = false;
        }

        private void numberFiveButton_Click(object sender, EventArgs e)
        {
            if (calculated)
            {
                mainTextBox.Text = string.Empty;
            }
            mainTextBox.Text += "5";
            calculated = false;
        }

        private void numberSixButton_Click(object sender, EventArgs e)
        {
            if (calculated)
            {
                mainTextBox.Text = string.Empty;
            }
            mainTextBox.Text += "6";
            calculated = false;
        }

        private void numberSevenButton_Click(object sender, EventArgs e)
        {
            if (calculated)
            {
                mainTextBox.Text = string.Empty;
            }
            mainTextBox.Text += "7";
            calculated = false;
        }

        private void numberEightButton_Click(object sender, EventArgs e)
        {
            if (calculated)
            {
                mainTextBox.Text = string.Empty;
            }
            mainTextBox.Text += "8";
            calculated = false;
        }

        private void numberNineButton_Click(object sender, EventArgs e)
        {
            if (calculated)
            {
                mainTextBox.Text = string.Empty;
            }
            mainTextBox.Text += "9";
            calculated = false;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text = string.Empty;
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "+";
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "-";
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "*";
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "/";
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (mainTextBox.Text != string.Empty)
            {
                mainTextBox.Text = mainTextBox.Text.Remove(mainTextBox.Text.Length - 1);
            }
        }
        private void ansButton_Click(object sender, EventArgs e)
        {
            if (calculated)
            {
                mainTextBox.Text = string.Empty;
            }
            mainTextBox.Text += lastAnswer;
            calculated = false;
        }

        private double Evaluate(string expression)
        {
            // This method was written by AI

            var dataTable = new DataTable();
            var column = new DataColumn("Eval", typeof(double), expression);
            dataTable.Columns.Add(column);
            dataTable.Rows.Add(0);
            return (double)(dataTable.Rows[0]["Eval"]);
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            if (mainTextBox.Text == string.Empty)
            {
                return;
            }

            try
            {
                mainTextBox.Text = Evaluate(mainTextBox.Text).ToString();
                if (mainTextBox.Text == "∞")
                {
                    mainTextBox.Text = string.Empty;
                    errorMessageLabel.Text = "Cannot divide by zero.";
                    
                }
                else
                {
                    lastAnswer = mainTextBox.Text;
                    errorMessageLabel.Text = string.Empty;
                    calculated = true;
                }
            }
            catch (OverflowException ex)
            {
                errorMessageLabel.Text = "Unable to process numbers this big.";
            }
            catch
            {
                errorMessageLabel.Text = "Syntax Error";
            }
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                equalsButton_Click(sender, e);
            }
        }


    }
}