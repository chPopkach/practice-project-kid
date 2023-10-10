using Kid.Models;
using System.Linq;
using System.Windows;

namespace Kid
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddCharterWindow : Window
    {
        AppContext appContext = new AppContext();

        public AddCharterWindow()
        {
            InitializeComponent();
            ToolBar.Children.Add(new ToolBarWindows() { Window = this, SasTitle = "Add Charter" });
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (textbox_NameCharter.Text != "" && textbox_Description.Text != "")
            {
                Charter charter = new Charter();

                if (appContext.Charters.Count() == 0)
                {
                    charter.Id = 1;
                }
                else
                {
                    charter.Id = appContext.Charters.Max(x => x.Id) + 1;
                }
                charter.NameCharter = textbox_NameCharter.Text;
                charter.DescriptionC = textbox_Description.Text;

                appContext.Charters.Add(charter);
                appContext.SaveChanges();

                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните данные!");
            }
        }
    }
}
