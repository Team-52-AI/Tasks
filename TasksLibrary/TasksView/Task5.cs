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
    // Форма для задачи генерации N первых простых чисел
    public partial class Task5 : Form
    {
        // Конструктор формы
        public Task5()
        {
            InitializeComponent(); // Инициализация компонентов интерфейса
        }

        // Обработчик кнопки закрытия формы
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрытие текущей формы
        }

        // Обработчик кнопки генерации простых чисел
        private void button1_Click(object sender, EventArgs e)
        {
            // Очистка предыдущего результата
            richTextBox1.Clear();

            string input = textBox1.Text; // Получаем ввод пользователя
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
            if (!int.TryParse(textBox1.Text, out int count) || count < 1)
            {
                richTextBox1.Text = "Пожалуйста, введите целое число больше 0!";
                return;
            }

            try
            {
                // Генерация простых чисел с помощью решета Эратосфена
                List<int> primes = GeneratePrimesBySieve(count);

                // Форматирование вывода через StringBuilder для эффективности
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Join(", ", primes)); // Числа через запятую

                // Вывод результата
                richTextBox1.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                richTextBox1.Text = $"Ошибка: {ex.Message}"; // Обработка исключений
            }
        }

        // Метод генерации N первых простых чисел с помощью решета Эратосфена
        public static List<int> GeneratePrimesBySieve(int count)
        {
            if (count < 1) return new List<int>(); // Проверка на валидность ввода

            // Приблизительная оценка верхней границы для N-го простого числа
            int limit = ApproximateNthPrime(count);

            // Инициализация решета Эратосфена
            bool[] sieve = new bool[limit + 1];
            for (int i = 2; i <= limit; i++)
                sieve[i] = true; // Изначально все числа считаются простыми

            // Алгоритм решета - отметка составных чисел
            for (int i = 2; i * i <= limit; i++)
            {
                if (sieve[i]) // Если i простое
                {
                    // Отмечаем все кратные i как составные
                    for (int j = i * i; j <= limit; j += i)
                        sieve[j] = false;
                }
            }

            // Сбор простых чисел в список
            var primes = new List<int>();
            for (int i = 2; i <= limit && primes.Count < count; i++)
            {
                if (sieve[i])
                    primes.Add(i); // Добавляем простые числа пока не наберем нужное количество
            }

            return primes;
        }

        // Метод приблизительной оценки N-го простого числа
        private static int ApproximateNthPrime(int n)
        {
            // Эвристическая формула для оценки верхней границы
            if (n < 6) return 15; // Эмпирически подобранные значения для малых n
            double logN = Math.Log(n);
            return (int)(n * (logN + Math.Log(logN))); // Формула Россера
        }
    }
}