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
    // Форма для вычисления наименьшего общего кратного (НОК) двух чисел
    public partial class Task7 : Form
    {
        // Конструктор формы, инициализирующий компоненты интерфейса
        public Task7()
        {
            InitializeComponent(); // Загрузка элементов управления из дизайнера
        }

        // Обработчик кнопки закрытия формы (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрытие текущей формы
        }

        // Обработчик кнопки вычисления НОК (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем введенные пользователем значения
            string input1 = textBox1.Text; // Первое число
            string input2 = textBox2.Text; // Второе число
            int num1, num2; // Переменные для хранения чисел

            // Проверка корректности ввода первого числа
            if (!int.TryParse(input1, out num1))
            {
                richTextBox1.Text = "Введите число в первое поле!";
                return;
            }

            // Проверка корректности ввода второго числа
            if (!int.TryParse(input2, out num2))
            {
                richTextBox1.Text = "Введите число во второе поле!";
                return;
            }

            // Вычисляем наименьшее общее кратное
            int lcm = LCM(num1, num2);

            // Выводим результат в текстовое поле
            richTextBox1.Text = lcm.ToString();
        }

        /// <summary>
        /// Вычисляет наибольший общий делитель (НОД) двух чисел
        /// с использованием алгоритма Евклида
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>НОД чисел a и b</returns>
        private static int GCD(int a, int b)
        {
            // Алгоритм Евклида:
            while (b != 0)
            {
                int temp = b; // Сохраняем текущее значение b
                b = a % b;    // Находим остаток от деления a на b
                a = temp;     // Присваиваем a предыдущее значение b
            }
            return a; // Когда b становится 0, a содержит НОД
        }

        /// <summary>
        /// Вычисляет наименьшее общее кратное (НОК) двух чисел
        /// используя формулу: НОК(a,b) = |a*b| / НОД(a,b)
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>НОК чисел a и b</returns>
        public static int LCM(int a, int b)
        {
            // Если одно из чисел равно 0, то НОК тоже 0
            if (a == 0 || b == 0)
                return 0;

            // Вычисляем по формуле, используя абсолютные значения
            return Math.Abs(a * b) / GCD(a, b);
        }
    }
}