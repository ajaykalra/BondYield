using System.Windows;

namespace BondYieldCalculator.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            // This starts MEF composition
            var bs = new Bootstrapper(e.Args);
        }
    }
}
