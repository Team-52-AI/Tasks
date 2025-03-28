using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TasksView
{
    public partial class Task4 : Form
    {
        public Task4()
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

            // Получаем количество простых чисел из текстового поля
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

            // Проверяем, что введено корректное число
            if (!int.TryParse(input, out int count) || count < 1)
            {
                richTextBox1.Text = "Пожалуйста, введите целое число больше 0!";
                return;
            }

            // Генерируем список простых чисел
            List<int> primes = GeneratePrimesByDefinition(count);

            // Форматируем вывод
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(", ", primes));

            // Выводим результат в richTextBox1
            richTextBox1.Text = sb.ToString();
        }

        /// <summary>
        /// Проверяет, является ли число простым (по определению)
        /// </summary>
        /// <param name="n">Число для проверки</param>
        /// <returns>True, если число простое</returns>
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Генерирует список первых N простых чисел (задача 4)
        /// </summary>
        /// <param name="count">Количество простых чисел</param>
        /// <returns>Список первых N простых чисел</returns>
        public static List<int> GeneratePrimesByDefinition(int count)
        {
            var primes = new List<int>();
            int num = 2;
            while (primes.Count < count)
            {
                if (IsPrime(num))
                    primes.Add(num);
                num++;
            }
            return primes;
        }
    }
}