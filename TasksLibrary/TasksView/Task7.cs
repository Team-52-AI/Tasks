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
    public partial class Task7 : Form
    {
        public Task7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем введенные значения
            string input1 = textBox1.Text;
            string input2 = textBox2.Text;
            int num1, num2;

            // Проверяем корректность ввода первого числа
            if (!int.TryParse(input1, out num1))
            {
                richTextBox1.Text = "Введите число!";
                return;
            }

            // Проверяем корректность ввода второго числа
            if (!int.TryParse(input2, out num2))
            {
                richTextBox1.Text = "Введите число!";
                return;
            }

            // Вычисляем НОК
            int lcm = LCM(num1, num2);

            // Выводим результат
            richTextBox1.Text = lcm.ToString();
        }

        /// <summary>
        /// Вычисляет наибольший общий делитель (НОД) двух чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>НОД чисел a и b</returns>
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Находит наименьшее общее кратное (НОК) двух чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>НОК чисел a и b</returns>
        public static int LCM(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;
            return Math.Abs(a * b) / GCD(a, b);
        }
    }
}