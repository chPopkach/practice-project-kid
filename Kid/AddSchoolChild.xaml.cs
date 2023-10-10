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
    /// Логика взаимодействия для AddSchoolChild.xaml
    /// </summary>
    public partial class AddSchoolChild : Window
    {
        AppContext appContext = new AppContext();

        public AddSchoolChild()
        {
            InitializeComponent();
            ToolBar.Children.Add(new ToolBarWindows() { Window = this, SasTitle = "Add SchoolChild" });

            combobox_Gender.ItemsSource = new List<char>() { 'М', 'Ж'};       

            if (DataOutputWindow.CheckDoubleClickOnSchoolchild == true)
            {
                combobox_Events.ItemsSource = new List<string>(appContext.EventsTables.Select(x => x.NameEvent));

                string header = "Название мероприятия";
                Binding b = new Binding("Event.NameEvent");
                DataGridTextColumn dataGridTextColumn = new DataGridTextColumn();
                dataGridTextColumn.Binding = b;
                dataGridTextColumn.Header = header;
                dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                datagrid.Columns.Add(dataGridTextColumn);

                datagrid.ItemsSource = appContext.EventsTableSchoolchilds.Where(x => x.SchoolchildId == DataOutputWindow.SelectedSchoolchild.Id).ToList();

                textbox_Surname.Text = DataOutputWindow.SelectedSchoolchild.Surname;
                textbox_Name.Text = DataOutputWindow.SelectedSchoolchild.NameE;
                textbox_Patronymic.Text = DataOutputWindow.SelectedSchoolchild.Patronymic;
                textbox_YearBirth.Text = DataOutputWindow.SelectedSchoolchild.YearBirth.ToString();
            }
            if (DataOutputWindow.CheckDoubleClickOnSchoolchild == false)
            {
                datagrid.Visibility = Visibility.Hidden;
                combobox_Events.Visibility = Visibility.Hidden;
                button_AddChild.Visibility = Visibility.Hidden;
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (DataOutputWindow.CheckDoubleClickOnSchoolchild == true)
            {
                if (textbox_Surname.Text != "" && textbox_Name.Text != "" && textbox_Patronymic.Text != ""
                    && textbox_YearBirth.Text != "" && combobox_Gender.SelectedItem != null)
                {
                    DataOutputWindow.SelectedSchoolchild.Surname = textbox_Surname.Text;
                    DataOutputWindow.SelectedSchoolchild.NameE = textbox_Name.Text;
                    DataOutputWindow.SelectedSchoolchild.Patronymic = textbox_Patronymic.Text;
                    DataOutputWindow.SelectedSchoolchild.YearBirth = Convert.ToInt32(textbox_YearBirth.Text);
                    DataOutputWindow.SelectedSchoolchild.Gender = combobox_Gender.SelectedItem.ToString();

                    appContext.Schoolchilds.Update(DataOutputWindow.SelectedSchoolchild);
                    appContext.SaveChanges();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Заполните все необходимые данные!");
                }
            }
            else
            {
                if (textbox_Surname.Text != "" && textbox_Name.Text != "" && textbox_Patronymic.Text != "" 
                    && textbox_YearBirth.Text != "" && combobox_Gender.SelectedItem.ToString() != null)
                {
                    Schoolchild schoolchild = new Schoolchild();

                    if (appContext.Schoolchilds.Count() == 0)
                    {
                        schoolchild.Id = 1;
                    }
                    else
                    {
                        schoolchild.Id = appContext.Schoolchilds.Max(x => x.Id) + 1;
                    }
                    schoolchild.Surname = textbox_Surname.Text;
                    schoolchild.NameE = textbox_Name.Text;
                    schoolchild.Patronymic = textbox_Patronymic.Text;
                    schoolchild.YearBirth = Convert.ToInt32(textbox_YearBirth.Text);
                    schoolchild.Gender = combobox_Gender.SelectedItem.ToString();

                    appContext.Schoolchilds.Add(schoolchild);
                    appContext.SaveChanges();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Заполните все необходимые данные!");
                }
            }
        }

        private void AddChild(object sender, RoutedEventArgs e)
        {
            if (combobox_Events.SelectedItem != null)
            {
                EventsTableSchoolchild eventsTableSchoolchild = new EventsTableSchoolchild();

                if (appContext.EmployeesCharters.Count() == 0)
                {
                    eventsTableSchoolchild.Id = 1;
                }
                else
                {
                    eventsTableSchoolchild.Id = appContext.EmployeesCharters.Max(x => x.Id) + 1;
                }
                eventsTableSchoolchild.SchoolchildId = DataOutputWindow.SelectedSchoolchild.Id;
                eventsTableSchoolchild.Event = appContext.EventsTables.FirstOrDefault(x => x.NameEvent == combobox_Events.SelectedItem.ToString());

                appContext.EventsTableSchoolchilds.Add(eventsTableSchoolchild);
                appContext.SaveChanges();
                datagrid.Columns.Clear();
                string header = "Название мероприятия";
                Binding b = new Binding("Event.NameEvent");
                DataGridTextColumn dataGridTextColumn = new DataGridTextColumn();
                dataGridTextColumn.Binding = b;
                dataGridTextColumn.Header = header;
                dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                datagrid.Columns.Add(dataGridTextColumn);

                datagrid.ItemsSource = appContext.EventsTableSchoolchilds.Where(x => x.SchoolchildId == DataOutputWindow.SelectedSchoolchild.Id).ToList();
            }
            else
            {
                MessageBox.Show("Заполните данные!");
            }
        }
    }
}
