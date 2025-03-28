using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TasksView
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Reference form = new Reference();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task1 form = new Task1();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task2 form = new Task2();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Task3 form = new Task3();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task4 form = new Task4();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Task5 form = new Task5();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Task6 form = new Task6();
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Task7 form = new Task7();
            form.ShowDialog();
        }
    }
}
