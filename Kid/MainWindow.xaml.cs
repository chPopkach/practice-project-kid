using Kid.Models;
using System.Linq;
using System.Windows;

namespace Kid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext appContext = new AppContext();

        public MainWindow()
        {
            InitializeComponent();
            ToolBar.Children.Add(new ToolBarWindows() { Window = this, SasTitle = "Children's camp" });
        }

        private void Authorization(object sender, RoutedEventArgs e)
        {
            if (passwordBoxKey.Password != "")
            {
                User user = appContext.Users.FirstOrDefault(x => x.IdentityKey == passwordBoxKey.Password);
                if (user == null)
                {
                    MessageBox.Show("Неверно указан ключ!");
                }
                else if (user != null)
                {
                    DataOutputWindow dataOutputWindow = new DataOutputWindow();
                    dataOutputWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Вы ввели пустое значение!");
            }
        }
    }
}
