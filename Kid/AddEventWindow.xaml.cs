using Kid.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Kid
{
    /// <summary>
    /// Логика взаимодействия для AddEventWindow.xaml
    /// </summary>
    public partial class AddEventWindow : Window
    {
        AppContext appContext = new AppContext();

        public AddEventWindow()
        {
            InitializeComponent();
            ToolBar.Children.Add(new ToolBarWindows() { Window = this, SasTitle = "Add Event" });

            List<string> strings = new List<string>(appContext.Employees.Select(x => x.Surname));
            combobox_Employees.ItemsSource = strings;

            if (DataOutputWindow.CheckDoubleClickOnEvents == true)
            {
                textbox_Name.Text = DataOutputWindow.SelectedEventsTable.NameEvent;
                textbox_Description.Text = DataOutputWindow.SelectedEventsTable.DescriptionE;
                textbox_Date.Text = DataOutputWindow.SelectedEventsTable.DateEvent.Date.ToString("yyyy.MM.dd");
                combobox_Employees.SelectedItem = DataOutputWindow.SelectedEventsTable.Employee.Surname;
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (DataOutputWindow.CheckDoubleClickOnEvents == true)
            {
                if (textbox_Name.Text != "" && textbox_Description.Text != "" && combobox_Employees.SelectedItem.ToString() != "" 
                    && textbox_Date.Text != "")
                {
                    DateTime dateTime;
                    if (DateTime.TryParseExact(textbox_Date.Text, String.Format("yyyy.MM.dd"), DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out dateTime))
                    {
                        DataOutputWindow.SelectedEventsTable.NameEvent = textbox_Name.Text;
                        DataOutputWindow.SelectedEventsTable.DescriptionE = textbox_Description.Text;
                        DataOutputWindow.SelectedEventsTable.Employee = appContext.Employees.FirstOrDefault(x => x.Surname == combobox_Employees.SelectedItem.ToString());

                        var line = textbox_Date.Text;
                        var result = new Regex("[0-9]+").Matches(line);
                        List<int> numbers = new List<int>();
                        foreach (Match match in result)
                            numbers.Add(Convert.ToInt32(match.Value));
                        DataOutputWindow.SelectedEventsTable.DateEvent = new DateTime(numbers[0], numbers[1], numbers[2]);

                        appContext.EventsTables.Update(DataOutputWindow.SelectedEventsTable);
                        appContext.SaveChanges();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверно указан формат даты!");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните необходимые данные!");
                }
            }
            else
            {
                if (textbox_Name.Text != "" && textbox_Description.Text != "" && combobox_Employees.SelectedItem != null 
                    && textbox_Date.Text != "")
                {
                    DateTime dateTime;
                    if (DateTime.TryParseExact(textbox_Date.Text, String.Format("yyyy.MM.dd"), DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out dateTime))
                    {
                        EventsTable eventsTable = new EventsTable();

                        if (appContext.EventsTables.Count() == 0)
                        {
                            eventsTable.Id = 1;
                        }
                        else
                        {
                            eventsTable.Id = appContext.EventsTables.Max(x => x.Id) + 1;
                        }
                        eventsTable.NameEvent = textbox_Name.Text;

                        var line = textbox_Date.Text;
                        var result = new Regex("[0-9]+").Matches(line);
                        List<int> numbers = new List<int>();
                        foreach (Match match in result)
                            numbers.Add(Convert.ToInt32(match.Value));

                        eventsTable.DateEvent = new DateTime(numbers[0], numbers[1], numbers[2]);
                        eventsTable.EmployeeId = appContext.Employees.FirstOrDefault(x => x.Surname == combobox_Employees.SelectedItem.ToString()).Id;
                        eventsTable.DescriptionE = textbox_Description.Text;
                        eventsTable.IsCompleted = "Нет";

                        appContext.EventsTables.Add(eventsTable);
                        appContext.SaveChanges();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверно указан формат даты!");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните необходимые данные!");
                }
            }
        }
    }
}
