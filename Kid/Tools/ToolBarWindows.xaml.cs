using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kid
{
    /// <summary>
    /// Логика взаимодействия для ToolBarWindows.xaml
    /// </summary>
    public partial class ToolBarWindows : UserControl
    {
        public ToolBarWindows()
        {
            InitializeComponent();
        }

        private string _osasTitleLabel;

        public Window Window { set; private get; }

        public string SasTitle { set { _osasTitleLabel = value; SasTitleLabel.Content = _osasTitleLabel; } private get => _osasTitleLabel; }

        bool MainWindowState = false;

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window.DragMove();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Window.Close();
        }

        private void Button_MouseDown(object sender, RoutedEventArgs e)
        {
            Window.WindowState = WindowState.Minimized;
        }
    }
}
