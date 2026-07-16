using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_01_01
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // создание объекта класса формы
            Form frm = new Form();
            // задаём заголовок формы
            frm.Text = "First Windows Forms application";
            // отображаем форму на экран пользователю 
            // для этого мы используем метод для отображения модальных диалогов
            frm.ShowDialog();


        }
    }
}
