using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_01_07
{
    public partial class Form1 : Form
    {
        private static Timer vTimer = new Timer();
        // Обработчик тика для таймера
        private void ShowTime(object vObj, EventArgs e)
        {
            // преобразование к строке
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }

        public Form1()
        {
            InitializeComponent();
            // преобразование к строке
            labelTime.Text = DateTime.Now.ToLongTimeString();
            // закрепление обработчика
            vTimer.Tick += new EventHandler(ShowTime);
            // установка интервала времени
            vTimer.Interval = 500;
            // стартуем таймер
            vTimer.Start();
        }
    }
}
