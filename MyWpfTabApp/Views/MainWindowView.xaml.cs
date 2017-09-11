using System.Windows;

namespace MyWpfTabApp.Views
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            DataContext = new MyWpfTabApp.ViewModels.MainWindowViewModel();
        }
    }
}
