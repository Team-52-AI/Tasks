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
    public partial class Task3 : Form
    {
        public Task3()
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

            // Получаем число из текстового поля
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

            // Проверяем, что введено число
            if (!int.TryParse(input, out int number) || number < 1)
            {
                richTextBox1.Text = "Пожалуйста, введите целое число больше 0!";
                return;
            }

            // Получаем факторизацию числа
            Dictionary<int, int> factors = Factorize(number);

            // Формируем строку результата
            string result = $"{number} = ";
            bool firstFactor = true;

            foreach (var factor in factors)
            {
                if (!firstFactor)
                {
                    result += " × ";
                }
                result += $"{factor.Key}^{factor.Value}";
                firstFactor = false;
            }

            // Выводим результат в richTextBox1
            richTextBox1.Text = result;
        }

        // Функция факторизации числа
        private Dictionary<int, int> Factorize(int n)
        {
            var factors = new Dictionary<int, int>();

            // Обрабатываем делитель 2 отдельно
            while (n % 2 == 0)
            {
                if (factors.ContainsKey(2))
                    factors[2]++;
                else
                    factors[2] = 1;
                n /= 2;
            }

            // Проверяем нечетные делители от 3 до sqrt(n)
            for (int i = 3; i * i <= n; i += 2)
            {
                while (n % i == 0)
                {
                    if (factors.ContainsKey(i))
                        factors[i]++;
                    else
                        factors[i] = 1;
                    n /= i;
                }
            }

            // Если осталось простое число больше 2
            if (n > 2)
            {
                factors[n] = 1;
            }

            return factors;
        }
    }
}