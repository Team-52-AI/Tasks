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
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            string mText = textBox1.Text;
            string nText = textBox2.Text;
            int mInt;
            int nInt;

            try
            {
                mInt = Convert.ToInt32(mText);
            }
            catch (Exception)
            {
                richTextBox1.Text = "Введите число!";
                return;
            }

            try
            {
                nInt = Convert.ToInt32(nText);
            }
            catch (Exception)
            {
                richTextBox1.Text = "Введите число!";
                return;
            }

            // Парсим входные данные
            if (!int.TryParse(mText, out int m) || !int.TryParse(nText, out int n))
            {
                richTextBox1.Text = "Введите корректные числа!";
                return;
            }

            // Проверяем диапазон
            if (m > n)
            {
                richTextBox1.Text = "Начало диапазона должно быть меньше конца!";
                return;
            }

            // Вызываем функцию поиска чисел с 5 делителями
            List<int> numbersWith5Divisors = Divisors.FindNumbersWith5Divisors(m, n);

            // Выводим результат
            if (numbersWith5Divisors.Count == 0)
            {
                richTextBox1.Text = $"В диапазоне [{m}, {n}] нет чисел с ровно 5 делителями";
            }
            else
            {
                richTextBox1.Text = string.Join(", ", numbersWith5Divisors);
            }
        }
    }

    public static class Divisors
    {
        /// <summary>
        /// Находит все делители числа N (задача 1)
        /// </summary>
        public static List<int> FindDivisors(int n)
        {
            if (n < 1)
                return new List<int>();

            var divisors = new List<int>();

            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                    if (i != n / i)
                        divisors.Add(n / i);
                }
            }

            divisors.Sort();
            return divisors;
        }

        /// <summary>
        /// Подсчитывает количество делителей числа N
        /// </summary>
        public static int CountDivisors(int n)
        {
            return n < 1 ? 0 : FindDivisors(n).Count;
        }

        /// <summary>
        /// Находит числа на интервале [m, n] с ровно 5 делителями
        /// </summary>
        public static List<int> FindNumbersWith5Divisors(int m, int n)
        {
            var result = new List<int>();
            for (int i = m; i <= n; i++)
            {
                if (CountDivisors(i) == 5)
                    result.Add(i);
            }
            return result;
        }
    }
}