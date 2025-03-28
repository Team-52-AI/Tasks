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
    public partial class Task6 : Form
    {
        public Task6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input_1 = textBox1.Text;
            string input_2 = textBox2.Text;
            int i_1;
            int i_2;

            try
            {
                i_1 = Convert.ToInt32(input_1);
            }
            catch (Exception)
            {
                richTextBox1.Text = "Введите число!";
                return;
            }

            try
            {
                i_2 = Convert.ToInt32(input_2);
            }
            catch (Exception)
            {
                richTextBox1.Text = "Введите число!";
                return;
            }

            // Вычисляем НОД
            int gcd = GCD(i_1, i_2);

            // Выводим результат
            richTextBox1.Text = gcd.ToString();
        }

        /// <summary>
        /// Вычисляет наибольший общий делитель (НОД) двух чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>НОД чисел a и b</returns>
        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}