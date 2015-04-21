using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFCalculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += button3.Text;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += buttonPlus.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += button6.Text;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += buttonMinus.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += button9.Text;
        }

        private void buttonMultiplication_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += buttonMultiplication.Text;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text += button0.Text;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.ResultTextBox.Text = "";
        }
    }
}
