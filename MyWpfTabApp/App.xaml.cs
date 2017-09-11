using System.Windows;

namespace MyWpfTabApp
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Views.MainWindowView mainWindowView = new Views.MainWindowView();
            mainWindowView.Show();
        }
    }
}
