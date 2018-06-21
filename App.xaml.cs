using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RaiderzSkillTree
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            if((bool)RaiderzSkillTree.Properties.Settings.Default["FirstRun"] == true)
            {
                // Update Settings
                RaiderzSkillTree.Properties.Settings.Default["FirstRun"] = false;
                // Save Settings
                RaiderzSkillTree.Properties.Settings.Default.Save();


                string title = "Credits";
                string displayMessage = "All credit for the skill description goes to Avenaei(Andrew), abbadonxk, and oroness. This version is completely based on the Java version of Raiderz Skill Tree Calculator made by Avenaei. \nSpecial thanks to Nymendine for giving me suggestions regarding this version.\n(This message will show up only during first run)";
                MessageBox.Show(displayMessage, title, MessageBoxButton.OK, MessageBoxImage.Information);
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Current.Shutdown();
        }
    }
}
