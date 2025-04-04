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
    // Класс формы "Reference" (справочная информация)
    public partial class Reference : Form
    {
        // Конструктор формы справочной информации
        public Reference()
        {
            // Инициализация компонентов формы, созданных в дизайнере
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки закрытия формы (button9)
        private void button9_Click(object sender, EventArgs e)
        {
            // Закрытие текущей формы справочника
            this.Close();
        }
    }
}