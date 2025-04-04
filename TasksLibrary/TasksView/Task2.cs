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
    // Форма для выполнения Задачи 2 (поиск чисел с 5 делителями в диапазоне)
    public partial class Task2 : Form
    {
        // Конструктор формы, инициализирующий компоненты интерфейса
        public Task2()
        {
            InitializeComponent(); // Загрузка элементов управления из дизайнера
        }

        // Обработчик кнопки закрытия формы (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрытие текущей формы
        }

        // Обработчик кнопки поиска чисел (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем значения из текстовых полей
            string mText = textBox1.Text; // Начало диапазона
            string nText = textBox2.Text; // Конец диапазона
            int mInt, nInt; // Числовые значения диапазона

            // Проверка корректности ввода начала диапазона
            try
            {
                mInt = Convert.ToInt32(mText);
            }
            catch (Exception)
            {
                richTextBox1.Text = "Введите число для начала диапазона!";
                return;
            }

            // Проверка корректности ввода конца диапазона
            try
            {
                nInt = Convert.ToInt32(nText);
            }
            catch (Exception)
            {
                richTextBox1.Text = "Введите число для конца диапазона!";
                return;
            }

            // Дополнительная проверка парсинга (избыточная, можно удалить)
            if (!int.TryParse(mText, out int m) || !int.TryParse(nText, out int n))
            {
                richTextBox1.Text = "Введите корректные числа!";
                return;
            }

            // Проверка корректности диапазона
            if (m > n)
            {
                richTextBox1.Text = "Начало диапазона должно быть меньше конца!";
                return;
            }

            // Поиск чисел с 5 делителями в заданном диапазоне
            List<int> numbersWith5Divisors = Divisors.FindNumbersWith5Divisors(m, n);

            // Вывод результатов
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

    // Статический класс для работы с делителями чисел
    public static class Divisors
    {
        /// <summary>
        /// Находит все делители числа N
        /// </summary>
        /// <param name="n">Число для анализа</param>
        /// <returns>Список делителей</returns>
        public static List<int> FindDivisors(int n)
        {
            if (n < 1)
                return new List<int>();

            var divisors = new List<int>();

            // Оптимизированный поиск делителей до √n
            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                    // Добавление парного делителя
                    if (i != n / i)
                        divisors.Add(n / i);
                }
            }

            divisors.Sort(); // Сортировка по возрастанию
            return divisors;
        }

        /// <summary>
        /// Подсчитывает количество делителей числа
        /// </summary>
        /// <param name="n">Число для анализа</param>
        /// <returns>Количество делителей</returns>
        public static int CountDivisors(int n)
        {
            return n < 1 ? 0 : FindDivisors(n).Count;
        }

        /// <summary>
        /// Находит числа с ровно 5 делителями в диапазоне [m, n]
        /// </summary>
        /// <param name="m">Начало диапазона</param>
        /// <param name="n">Конец диапазона</param>
        /// <returns>Список чисел с 5 делителями</returns>
        public static List<int> FindNumbersWith5Divisors(int m, int n)
        {
            var result = new List<int>();
            // Перебор всех чисел в диапазоне
            for (int i = m; i <= n; i++)
            {
                if (CountDivisors(i) == 5) // Проверка на 5 делителей
                    result.Add(i);
            }
            return result;
        }
    }
}