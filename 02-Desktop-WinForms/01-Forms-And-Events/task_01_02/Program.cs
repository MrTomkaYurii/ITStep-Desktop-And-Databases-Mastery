using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_01_02
{
    // пользовательский класс
    class MyForm : Form
    {
        // конструктор класса
        public MyForm(string caption)
        {
            // задаём заголовок формы
            Text = caption;
        }
    }


    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // создание объекта пользовательского класса формы
            MyForm frm = new MyForm("Hello, world!!!");
            // отображаем форму на экран пользователю 
            // для этого мы используем метод для отображения модальных диалогов
            frm.ShowDialog();
        }
    }
}
