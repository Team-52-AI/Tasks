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
    // Форма для выполнения Задачи 1 (поиск делителей числа)
    public partial class Task1 : Form
    {
        // Конструктор формы, инициализирующий компоненты
        public Task1()
        {
            InitializeComponent(); // Загрузка элементов интерфейса из дизайнера
        }

        // Обработчик нажатия кнопки "Найти делители" (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            string n_1 = textBox1.Text; // Получаем текст из поля ввода
            int n; // Переменная для хранения числа

            // Пытаемся преобразовать введенный текст в число
            try
            {
                n = Convert.ToInt32(n_1);
            }
            catch (Exception)
            {
                // Выводим сообщение об ошибке, если преобразование не удалось
                richTextBox1.Text = "Введите число!";
                return;
            }

            // Вызываем функцию поиска делителей
            List<int> divisors = FindDivisors(n);

            // Выводим результат в richTextBox1
            if (divisors.Count == 0)
            {
                richTextBox1.Text = "Число должно быть положительным!";
            }
            else
            {
                // Форматируем делители в строку через запятую
                richTextBox1.Text = $"{string.Join(", ", divisors)}";
            }
        }

        // Метод для поиска всех делителей числа
        public static List<int> FindDivisors(int n)
        {
            // Возвращаем пустой список для неположительных чисел
            if (n < 1)
                return new List<int>();

            var divisors = new List<int>();

            // Перебираем возможные делители от 1 до квадратного корня из n
            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) // Если i - делитель n
                {
                    divisors.Add(i); // Добавляем делитель i
                    // Добавляем парный делитель, если он отличается от i
                    if (i != n / i)
                        divisors.Add(n / i);
                }
            }

            // Сортируем делители по возрастанию для удобства чтения
            divisors.Sort();
            return divisors;
        }

        // Обработчик нажатия кнопки "Закрыть" (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрываем текущую форму
        }
    }
}