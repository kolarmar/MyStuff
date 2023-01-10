using System.Data;
using System.Linq.Expressions;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numberZeroButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "0";
        }

        private void numberOneButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "1";
        }

        private void numberTwoButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "2";
        }

        private void numberThreeButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "3";
        }

        private void numberFourButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "4";
        }

        private void numberFiveButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "5";
        }

        private void numberSixButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "6";
        }

        private void numberSevenButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "7";
        }

        private void numberEightButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "8";
        }

        private void numberNineButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += "9";
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
            mainTextBox.Text = Evaluate(mainTextBox.Text).ToString();
        }
    }
}