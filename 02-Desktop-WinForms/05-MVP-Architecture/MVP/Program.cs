using MVP.Presenters;
using MVP.Views;
using System.Configuration;

namespace MVP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            string sqlConnectionString = ConfigurationManager.ConnectionStrings["MVP.Properties.Settings.SqlConnection1"].ConnectionString;

            IMainView view = new MainView();
            new MainPresenter(view, sqlConnectionString);
            Application.Run((Form)view);
        }
    }
}