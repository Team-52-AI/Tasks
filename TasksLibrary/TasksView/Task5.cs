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
    public partial class Task5 : Form
    {
        public Task5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Очищаем предыдущий результат
            richTextBox1.Clear();

            string input = textBox1.Text;
            int i_1;

            try
            {
                i_1 = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                richTextBox1.Text = "Введите число!".ToString();
                return;
            }

            // Получаем количество простых чисел из textBox1
            if (!int.TryParse(textBox1.Text, out int count) || count < 1)
            {
                richTextBox1.Text = "Пожалуйста, введите целое число больше 0!";
                return;
            }

            try
            {
                // Генерируем простые числа
                List<int> primes = GeneratePrimesBySieve(count);

                // Форматируем вывод
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Join(", ", primes));

                // Выводим результат
                richTextBox1.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                richTextBox1.Text = $"Ошибка: {ex.Message}";
            }
        }

        public static List<int> GeneratePrimesBySieve(int count)
        {
            if (count < 1) return new List<int>();

            // Приблизительная оценка верхней границы
            int limit = ApproximateNthPrime(count);

            // Решето Эратосфена
            bool[] sieve = new bool[limit + 1];
            for (int i = 2; i <= limit; i++)
                sieve[i] = true;

            for (int i = 2; i * i <= limit; i++)
            {
                if (sieve[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                        sieve[j] = false;
                }
            }

            // Собираем простые числа
            var primes = new List<int>();
            for (int i = 2; i <= limit && primes.Count < count; i++)
            {
                if (sieve[i])
                    primes.Add(i);
            }

            return primes;
        }

        private static int ApproximateNthPrime(int n)
        {
            // Формула для приблизительной оценки n-го простого числа
            if (n < 6) return 15;
            double logN = Math.Log(n);
            return (int)(n * (logN + Math.Log(logN)));
        }
    }
}