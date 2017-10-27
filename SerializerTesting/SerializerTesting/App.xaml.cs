using SerializerTesting.Application;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SerializerTesting
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private ApplicationViewmodel _mainWindowDataContext;

        private void Application_StartUp(object sender, StartupEventArgs e)
        {
            //Hauptfenster
            var mainWindow = new ApplicationView();
            MainWindow = mainWindow;
            

            //HauptViewmodel zuweisen
            _mainWindowDataContext = new ApplicationViewmodel();
            mainWindow.DataContext = _mainWindowDataContext;
            mainWindow.Show();
        }
    }
}
