using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_01_04
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            static DialogResult ShowMessageBoxes()
            {
                //показ окна, отображающего текстовое сообщение и кнопку ОК
                String message = "Окно, отображающее текстовое сообщение";
                MessageBox.Show(message);

                //показ окна с текстом и двумя кнопками OK и CANCEL
                message = "Окно с текстом и двумя кнопками OK и CANCEL";
                String caption = "Окно с двумя кнопками";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel);
                String button = result.ToString();

                //показ Окна с тремя кнопками и какой-то иконкой
                result = MessageBox.Show("Вы нажали кнопку " + button + ". Повторить?", button, MessageBoxButtons.AbortRetryIgnore,
                                MessageBoxIcon.Asterisk);
                return result;
            }

            DialogResult result;
            do 
            {
                result = ShowMessageBoxes();
            } while (result == DialogResult.Retry);

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
