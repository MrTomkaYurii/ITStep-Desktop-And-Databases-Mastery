using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_01_03
{
    class MyForm : Form
    {
        public MyForm(string caption)
        {
            //установка заголовка окна
            Text = caption;
            //закрепляем обработчик события
            Click += new EventHandler(ClickHandler);
        }
        public void ClickHandler(Object sender, EventArgs e)
        {
            MessageBox.Show("Click");
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


            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyForm("Hello GUYS"));
        }
    }
}
