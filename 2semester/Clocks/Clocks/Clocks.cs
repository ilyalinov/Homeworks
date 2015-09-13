using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clocks
{
    public partial class Clocks : Form
    {
        public Clocks()
        {
            InitializeComponent();
        }

        private string Add0(string buffer)
        {
            if (Convert.ToInt32(buffer) < 10)
            {
                buffer = "0" + buffer;
            }
            return buffer;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            string hours = Convert.ToString(time.Hour);
            string minutes = Convert.ToString(time.Minute);
            string seconds = Convert.ToString(time.Second);
            hours = Add0(hours);
            minutes = Add0(minutes);
            seconds = Add0(seconds);

            this.hoursTextBox.Text = hours;
            this.minutesTextBox.Text = minutes;
            this.secondsTextBox.Text = seconds;
        }
    }
}
