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
    // Форма для выполнения задачи 4 (генерация первых N простых чисел)
    public partial class Task4 : Form
    {
        // Конструктор формы, инициализирующий компоненты интерфейса
        public Task4()
        {
            InitializeComponent(); // Загрузка элементов управления из дизайнера
        }

        // Обработчик кнопки закрытия формы (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрытие текущей формы
        }

        // Обработчик кнопки генерации простых чисел (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            // Очищаем поле вывода перед новым расчетом
            richTextBox1.Clear();

            // Получаем введенное пользователем значение
            string input = textBox1.Text;
            int i_1;

            // Проверка корректности ввода (целое число)
            try
            {
                i_1 = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                richTextBox1.Text = "Введите число!";
                return;
            }

            // Дополнительная проверка (положительное число)
            if (!int.TryParse(input, out int count) || count < 1)
            {
                richTextBox1.Text = "Пожалуйста, введите целое число больше 0!";
                return;
            }

            // Генерируем список первых N простых чисел
            List<int> primes = GeneratePrimesByDefinition(count);

            // Форматируем вывод в виде строки с разделителями
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Join(", ", primes));

            // Выводим результат в текстовое поле
            richTextBox1.Text = sb.ToString();
        }

        /// <summary>
        /// Проверяет, является ли число простым (по определению)
        /// </summary>
        /// <param name="n">Число для проверки</param>
        /// <returns>True, если число простое</returns>
        public static bool IsPrime(int n)
        {
            // Исключаем числа меньше 2 и четные числа (кроме 2)
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            // Проверяем делители от 3 до квадратного корня из n
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Генерирует список первых N простых чисел
        /// </summary>
        /// <param name="count">Требуемое количество простых чисел</param>
        /// <returns>Список первых N простых чисел</returns>
        public static List<int> GeneratePrimesByDefinition(int count)
        {
            var primes = new List<int>();
            int num = 2; // Начинаем проверку с первого простого числа

            // Продолжаем поиск, пока не найдем нужное количество простых чисел
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