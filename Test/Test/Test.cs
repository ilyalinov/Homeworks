using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();

            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.progressBar1.Step = 1;
            this.progressBar1.Maximum = 200;
            int count = this.progressBar1.Maximum / this.progressBar1.Step;

            this.progressBar1.PerformStep();
            for (int i = 0; i < count; i++)
            {
                this.progressBar1.PerformStep();
                System.Threading.Thread.Sleep(10);
            }

            this.button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
