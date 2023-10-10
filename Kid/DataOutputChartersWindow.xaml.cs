using Kid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Kid
{
    /// <summary>
    /// Логика взаимодействия для DataOutputChartersWindow.xaml
    /// </summary>
    public partial class DataOutputChartersWindow : Window
    {
        AppContext appContext = new AppContext();

        public Charter Charter { get; set; }

        public DataOutputChartersWindow()
        {
            InitializeComponent();
            ToolBar.Children.Add(new ToolBarWindows() { Window = this, SasTitle = "Charters Employee" });
            DataDataGrid();
            List<string> strings = new List<string>(appContext.Charters.Select(x => x.NameCharter));
            combobox_Charters.ItemsSource = strings;

            int count = appContext.EmployeesCharters.Where(x => x.EmployeeId == DataOutputWindow.SelectedEmployee.Id).Count();
            textblock_Count.Text = count.ToString();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddCharterWindow addCharterWindow = new AddCharterWindow();
            addCharterWindow.ShowDialog();
            List<string> strings = new List<string>(appContext.Charters.Select(x => x.NameCharter));
            combobox_Charters.ItemsSource = strings;
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            if (DataOutputWindow.SelectedEmployee != null && combobox_Charters.SelectedItem != null)
            {
                EmployeesCharter employeesCharter = new EmployeesCharter();

                if (appContext.EmployeesCharters.Count() == 0)
                {
                    employeesCharter.Id = 0;
                }
                else
                {
                    employeesCharter.Id = appContext.EmployeesCharters.Max(x => x.Id) + 1;
                }
                employeesCharter.EmployeeId = DataOutputWindow.SelectedEmployee.Id;
                employeesCharter.Charter = appContext.Charters.FirstOrDefault(x => x.NameCharter == combobox_Charters.SelectedItem.ToString());

                appContext.EmployeesCharters.Add(employeesCharter);
                appContext.SaveChanges();
                textblock_Count.Text = (Convert.ToInt32(textblock_Count.Text) + 1).ToString();
                DataDataGrid();
            }
            else
            {
                MessageBox.Show("Заполните данные!");
            }
        }

        private void DataDataGrid()
        {
            datagrid.Columns.Clear();

            string header = "Наименование";
            Binding b = new Binding("NameCharter");
            DataGridTextColumn dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            var charters = (from p in appContext.EmployeesCharters
                            where p.EmployeeId == DataOutputWindow.SelectedEmployee.Id
                            select new { Id = p.Charter.Id, NameCharter = p.Charter.NameCharter, DescriptionC = p.Charter.DescriptionC }).ToList();
            datagrid.ItemsSource = charters;
        }
    }
}
