using System;
using System.Windows.Forms;

namespace WFCalculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private int prevValue = 0;
        private int currentValue = 0;
        private string valueBuffer = "";
        private Operation prevOperation = new Plus();

        /// <summary>
        /// Print button text to user text box
        /// </summary>
        /// <param name="button"></param>
        private void PrintText(Button button)
        {
            this.userTextBox.Text += button.Text;
        }

        /// <summary>
        /// Calculate simple arithmetic expression and print the result to result text box
        /// </summary>
        /// <param name="operation"> given arithmetic operation </param>
        private void Calculate(Operation operation)
        {
            try
            {
                prevValue = operation.Count(prevValue, currentValue);
                this.resultTextBox.Text = Convert.ToString(prevValue);
            }
            catch (NullReferenceException e)
            {
                this.resultTextBox.Text = e.Message;
            }
        }

        /// <summary>
        /// Click handler for buttons 0-9 and +, -, *, /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                this.PrintText(button);
            }
            switch (button.Text)
            {
                case ("+"):
                    currentValue = Convert.ToInt32(valueBuffer);
                    Calculate(prevOperation);
                    prevOperation = new Plus();
                    valueBuffer = "";
                    break;
                case ("-"):
                    currentValue = Convert.ToInt32(valueBuffer);
                    Calculate(prevOperation);
                    prevOperation = new Minus();
                    valueBuffer = "";
                    break;
                case ("/"):
                    currentValue = Convert.ToInt32(valueBuffer);
                    Calculate(prevOperation);
                    prevOperation = new Division();
                    valueBuffer = "";
                    break;
                case("*"):
                    currentValue = Convert.ToInt32(valueBuffer);
                    Calculate(prevOperation);
                    prevOperation = new Multiplication();
                    valueBuffer = "";
                    break;
                default:
                    valueBuffer += button.Text;
                    break;


            }
        }

        /// <summary>
        /// Clear result and user text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.userTextBox.Text = "";
            this.resultTextBox.Text = "";
            prevValue = 0;
            currentValue = 0;
            valueBuffer = "";
            prevOperation = new Plus();
        }

        /// <summary>
        /// Return result of complex arithmetic expression
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResult_Click(object sender, EventArgs e)
        {
            currentValue = Convert.ToInt32(valueBuffer);
            Calculate(prevOperation);
            prevValue = 0;
            currentValue = 0;
            valueBuffer = "";
            prevOperation = new Plus();
        }
    }
}
