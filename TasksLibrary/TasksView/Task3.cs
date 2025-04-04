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
    // Форма для выполнения задачи факторизации числа (разложения на простые множители)
    public partial class Task3 : Form
    {
        // Конструктор формы, инициализирующий компоненты интерфейса
        public Task3()
        {
            InitializeComponent(); // Загрузка элементов управления из дизайнера
        }

        // Обработчик кнопки закрытия формы (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрытие текущей формы
        }

        // Обработчик кнопки выполнения факторизации (button1)
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
            if (!int.TryParse(input, out int number) || number < 1)
            {
                richTextBox1.Text = "Пожалуйста, введите целое число больше 0!";
                return;
            }

            // Получаем разложение на простые множители
            Dictionary<int, int> factors = Factorize(number);

            // Форматируем результат в виде строки (например: "24 = 2^3 × 3^1")
            string result = $"{number} = ";
            bool firstFactor = true; // Флаг для правильной расстановки знаков умножения

            foreach (var factor in factors)
            {
                if (!firstFactor)
                {
                    result += " × "; // Добавляем знак умножения между множителями
                }
                result += $"{factor.Key}^{factor.Value}"; // Формат "простое^степень"
                firstFactor = false;
            }

            // Выводим отформатированный результат
            richTextBox1.Text = result;
        }

        // Метод для факторизации числа (разложения на простые множители)
        private Dictionary<int, int> Factorize(int n)
        {
            var factors = new Dictionary<int, int>();

            // Сначала обрабатываем все делители 2 (четные числа)
            while (n % 2 == 0)
            {
                if (factors.ContainsKey(2))
                    factors[2]++; // Увеличиваем степень для множителя 2
                else
                    factors[2] = 1; // Добавляем множитель 2 в словарь
                n /= 2; // Делим число на 2
            }

            // Затем проверяем нечетные делители от 3 до квадратного корня из n
            for (int i = 3; i * i <= n; i += 2)
            {
                while (n % i == 0)
                {
                    if (factors.ContainsKey(i))
                        factors[i]++; // Увеличиваем степень существующего множителя
                    else
                        factors[i] = 1; // Добавляем новый множитель
                    n /= i; // Делим число на текущий множитель
                }
            }

            // Если после обработки осталось число больше 2 - оно простое
            if (n > 2)
            {
                factors[n] = 1; // Добавляем последний простой множитель
            }

            return factors; // Возвращаем словарь множителей и их степеней
        }
    }
}