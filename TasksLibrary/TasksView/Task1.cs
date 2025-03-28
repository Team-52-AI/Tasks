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
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string n_1 = textBox1.Text;
            int n;

            try
            {
                n = Convert.ToInt32(n_1);
            }
            catch (Exception)
            {
                richTextBox1.Text = "Введите число!";
                return;
            }

            // Вызываем функцию поиска делителей
            List<int> divisors = FindDivisors(n);

            // Выводим результат в label1
            if (divisors.Count == 0)
            {
                richTextBox1.Text = "Число должно быть положительным!";
            }
            else
            {
                richTextBox1.Text = $"{string.Join(", ", divisors)}";
            }
        }

        public static List<int> FindDivisors(int n)
        {
            if (n < 1)
                return new List<int>();

            var divisors = new List<int>();

            // Перебираем возможные делители от 1 до sqrt(n)
            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                    // Добавляем парный делитель, если он не совпадает с текущим
                    if (i != n / i)
                        divisors.Add(n / i);
                }
            }

            // Сортируем делители по возрастанию
            divisors.Sort();
            return divisors;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}