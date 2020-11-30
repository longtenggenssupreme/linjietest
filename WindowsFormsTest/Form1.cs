using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest
{
    public partial class Form1 : Form
    {
        Button ButtonTest;
        static int ss = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //while (true)
            //{
            ButtonTest = new Button
            {
                Location = new Point(0 + 139 * ss, 131 + 10 * ss),
                Name = "button1",
                Text = ss.ToString(),
                Size = new Size(75, 23)
            };
            ButtonTest.Click += ButtonTest_Click;
            this.Controls.Add(ButtonTest);
            ButtonTest.PerformClick();
            //Thread.Sleep(10000);
            //}
        }

        private void ButtonTest_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            Interlocked.Increment(ref ss);
            this.textBox1.Text = ss.ToString();
        }
    }
}
