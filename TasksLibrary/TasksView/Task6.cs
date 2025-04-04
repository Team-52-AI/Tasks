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
    // Форма для вычисления наибольшего общего делителя (НОД) двух чисел
    public partial class Task6 : Form
    {
        // Конструктор формы, инициализирующий компоненты интерфейса
        public Task6()
        {
            InitializeComponent(); // Загрузка элементов управления из дизайнера
        }

        // Обработчик кнопки закрытия формы (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрытие текущей формы
        }

        // Обработчик кнопки вычисления НОД (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем введенные пользователем значения
            string input_1 = textBox1.Text; // Первое число
            string input_2 = textBox2.Text; // Второе число
            int i_1, i_2; // Числовые значения

            // Проверка корректности ввода первого числа
            try
            {
                i_1 = Convert.ToInt32(input_1);
            }
            catch (Exception)
            {
                richTextBox1.Text = "Введите число в первое поле!";
                return;
            }

            // Проверка корректности ввода второго числа
            try
            {
                i_2 = Convert.ToInt32(input_2);
            }
            catch (Exception)
            {
                richTextBox1.Text = "Введите число во второе поле!";
                return;
            }

            // Вычисляем наибольший общий делитель
            int gcd = GCD(i_1, i_2);

            // Выводим результат в текстовое поле
            richTextBox1.Text = gcd.ToString();
        }

        /// <summary>
        /// Вычисляет наибольший общий делитель (НОД) двух чисел
        /// с использованием алгоритма Евклида
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Наибольший общий делитель</returns>
        public static int GCD(int a, int b)
        {
            // Алгоритм Евклида:
            // 1. Пока второе число не станет равным 0
            // 2. Заменяем первое число вторым, а второе - остатком от деления
            while (b != 0)
            {
                int temp = b; // Сохраняем текущее значение b
                b = a % b;    // Вычисляем остаток от деления a на b
                a = temp;      // Присваиваем a предыдущее значение b
            }
            return a; // Когда b стало 0, a содержит НОД
        }
    }
}