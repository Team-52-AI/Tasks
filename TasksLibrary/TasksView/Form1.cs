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
    // Основная форма приложения, служащая главным меню для доступа к задачам
    public partial class Form1 : Form
    {
        // Конструктор главной формы, инициализирующий компоненты интерфейса
        public Form1()
        {
            InitializeComponent(); // Загрузка и настройка элементов управления формы
        }

        // Обработчик кнопки выхода из приложения (button9)
        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Полное завершение работы приложения
        }

        // Обработчик кнопки вызова справочной информации (button8)
        private void button8_Click(object sender, EventArgs e)
        {
            Reference form = new Reference(); // Создание экземпляра формы справочника
            form.ShowDialog(); // Открытие справочника в модальном окне
        }

        // Серия обработчиков для кнопок запуска различных задач:

        // Запуск Задачи 1 (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            Task1 form = new Task1(); // Создание формы для задачи 1
            form.ShowDialog(); // Открытие в модальном режиме
        }

        // Запуск Задачи 2 (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            Task2 form = new Task2();
            form.ShowDialog();
        }

        // Запуск Задачи 3 (button4)
        private void button4_Click(object sender, EventArgs e)
        {
            Task3 form = new Task3();
            form.ShowDialog();
        }

        // Запуск Задачи 4 (button3)
        private void button3_Click(object sender, EventArgs e)
        {
            Task4 form = new Task4();
            form.ShowDialog();
        }

        // Запуск Задачи 5 (button6)
        private void button6_Click(object sender, EventArgs e)
        {
            Task5 form = new Task5();
            form.ShowDialog();
        }

        // Запуск Задачи 6 (button5)
        private void button5_Click(object sender, EventArgs e)
        {
            Task6 form = new Task6();
            form.ShowDialog();
        }

        // Запуск Задачи 7 (button7)
        private void button7_Click(object sender, EventArgs e)
        {
            Task7 form = new Task7();
            form.ShowDialog();
        }
    }
}