using iTextSharp.text;
using iTextSharp.text.pdf;
using Kid.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
namespace Kid
{
    /// <summary>
    /// Логика взаимодействия для DataOutputWindow.xaml
    /// </summary>

    public partial class DataOutputWindow : Window
    {
        AppContext appContext = new AppContext();

        public static bool CheckDoubleClickOnSchoolchild { get; set; }

        public static bool CheckDoubleClickOnEvents { get; set; }

        public static Employee SelectedEmployee { get; set; }

        public static EventsTable SelectedEventsTable { get; set; }

        public static Schoolchild SelectedSchoolchild { get; set; }

        public DataOutputWindow()
        {
            InitializeComponent();
            ToolBar.Children.Add(new ToolBarWindows() { Window = this, SasTitle = "Main Window" });

            comboBox_changeDataGrid.ItemsSource = new List<string>() { "Сотрудники", "Мероприятия", "Школьники" };

            button_Add.Visibility = Visibility.Hidden;
            button_IsCompleted.Visibility = Visibility.Hidden;
            button_ReportGeneration.Visibility = Visibility.Hidden;
        }

        private void OpenWindowCharters(object sender, MouseEventArgs e)
        {
            if (SelectedEmployee != null)
            {
                DataOutputChartersWindow dataOutputChartersWindow = new DataOutputChartersWindow();
                dataOutputChartersWindow.ShowDialog();
                SelectedEmployee = null;
            }
            if (SelectedSchoolchild != null)
            {
                CheckDoubleClickOnSchoolchild = true;
                AddSchoolChild addSchoolChild = new AddSchoolChild();
                addSchoolChild.ShowDialog();
                SelectedSchoolchild = null;
                CheckDoubleClickOnSchoolchild = false;
                ChangeDataGridSchoolchild();
            }
            if (SelectedEventsTable != null)
            {
                CheckDoubleClickOnEvents = true;
                AddEventWindow addEventWindow = new AddEventWindow();
                addEventWindow.ShowDialog();
                SelectedEventsTable = null;
                CheckDoubleClickOnEvents = false;
                ChangeDataGridForEvents();
            }
        }

        private void comboBox_changeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (comboBox_changeDataGrid.SelectedItem.ToString())
            {
                case "Сотрудники":
                    ChangeDataGridForEmployees();
                    SelectedEmployee = null;
                    SelectedEventsTable = null;
                    SelectedSchoolchild = null;
                    button_Add.Visibility = Visibility.Hidden;
                    button_IsCompleted.Visibility = Visibility.Hidden;
                    button_ReportGeneration.Visibility = Visibility.Hidden;
                    break;
                case "Мероприятия":
                    ChangeDataGridForEvents();
                    SelectedEmployee = null;
                    SelectedEventsTable = null;
                    SelectedSchoolchild = null;
                    button_Add.Visibility = Visibility.Visible;
                    button_IsCompleted.Visibility = Visibility.Visible;
                    button_ReportGeneration.Visibility = Visibility.Visible;
                    break;
                case "Школьницы":
                    ChangeDataGridSchoolchild();
                    SelectedEmployee = null;
                    SelectedEventsTable = null;
                    SelectedSchoolchild = null;
                    button_Add.Visibility = Visibility.Visible;
                    button_IsCompleted.Visibility = Visibility.Hidden;
                    button_ReportGeneration.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void ChangeDataGridForEmployees()
        {
            datagrid.Columns.Clear();
            string header = "Фамилия";
            Binding b = new Binding("Surname");
            DataGridTextColumn dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            header = "Имя";
            b = new Binding("NameE");
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            header = "Отчество";
            b = new Binding("Patronymic");
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            header = "Год рождения";
            b = new Binding("YearBirth");
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            header = "Стаж работы";
            b = new Binding("WorkExperience");
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            header = "Пол";
            b = new Binding("Gender");
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            datagrid.ItemsSource = appContext.Employees.ToList();
        }

        private void ChangeDataGridForEvents()
        {
            datagrid.Columns.Clear();
            string header = "Наименование";
            Binding b = new Binding("NameEvent");
            DataGridTextColumn dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            header = "Дата";
            b = new Binding("DateEvent");
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Binding.StringFormat = String.Format("yyyy.MM.dd");
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            header = "Проведено";
            b = new Binding("IsCompleted");
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            header = "Ответственный";
            b = new Binding("Employee.Surname");
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            datagrid.ItemsSource = appContext.EventsTables.ToList();
        }

        private void ChangeDataGridSchoolchild()
        {
            datagrid.Columns.Clear();
            string header = "Фамилия";
            Binding b = new Binding("Surname");
            DataGridTextColumn dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            header = "Имя";
            b = new Binding("NameE");
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Binding.StringFormat = String.Format("dd MMM yyyy");
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            header = "Фамилия";
            b = new Binding("Patronymic");
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            header = "Год рождения";
            b = new Binding("YearBirth");
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            header = "Пол";
            b = new Binding("Gender");
            dataGridTextColumn = new DataGridTextColumn();
            dataGridTextColumn.Binding = b;
            dataGridTextColumn.Header = header;
            dataGridTextColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            datagrid.Columns.Add(dataGridTextColumn);

            datagrid.ItemsSource = appContext.Schoolchilds.ToList();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (comboBox_changeDataGrid.SelectedItem != null)
            {
                switch (comboBox_changeDataGrid.SelectedItem.ToString())
                {
                    case "Мероприятия":
                        CheckDoubleClickOnEvents = false;
                        AddEventWindow addEventWindow = new AddEventWindow();
                        addEventWindow.ShowDialog();
                        ChangeDataGridForEvents();
                        break;
                    case "Школьники":
                        CheckDoubleClickOnSchoolchild = false;
                        AddSchoolChild addSchoolChild = new AddSchoolChild();
                        addSchoolChild.ShowDialog();
                        ChangeDataGridSchoolchild();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Выберите значение комбокса!");
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox_changeDataGrid.SelectedItem.ToString() != null)
            {
                switch (comboBox_changeDataGrid.SelectedItem.ToString())
                {
                    case "Сотрудники":
                        SelectedEmployee = (Employee)datagrid.SelectedItem;
                        break;
                    case "Мероприятия":
                        SelectedEventsTable = (EventsTable)datagrid.SelectedItem;
                        break;
                    case "Школьники":
                        SelectedSchoolchild = (Schoolchild)datagrid.SelectedItem;
                        break;
                }
            }
        }

        private void IsCompleted(object sender, RoutedEventArgs e)
        {
            if (SelectedEventsTable != null)
            {
                if (SelectedEventsTable.IsCompleted == "Нет")
                {
                    SelectedEventsTable.IsCompleted = "Да";
                }
                else
                {
                    SelectedEventsTable.IsCompleted = "Нет";
                }
                appContext.EventsTables.Update(SelectedEventsTable);
                appContext.SaveChanges();
                ChangeDataGridForEvents();
            }
            else
            {
                MessageBox.Show("Выберите мероприятие!");
            }
        }

        private void textbox_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (comboBox_changeDataGrid.SelectedItem != null)
            {
                switch (comboBox_changeDataGrid.SelectedItem.ToString())
                {
                    case "Сотрудники":
                        datagrid.ItemsSource = appContext.Employees.Where(x => x.Surname.StartsWith(textbox_Search.Text)).ToList();
                        break;
                    case "Мероприятия":
                        datagrid.ItemsSource = appContext.EventsTables.Where(x => x.NameEvent.StartsWith(textbox_Search.Text)).ToList();
                        break;
                    case "Школьники":
                        datagrid.ItemsSource = appContext.Schoolchilds.Where(x => x.Surname.StartsWith(textbox_Search.Text)).ToList();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Выберите заполнение таблицы!");
            }
        }

        private void ReportGeneration(object sender, RoutedEventArgs e)
        {
            PdfPTable table = new PdfPTable(datagrid.Columns.Count);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

            string ttf = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream(@"\Users\gr604_buami\Desktop\Report.pdf", System.IO.FileMode.Create));
            doc.Open();
            for (int j = 0; j < datagrid.Columns.Count; j++)
            {
                table.AddCell(new Phrase(datagrid.Columns[j].Header.ToString(), font));
            }
            table.HeaderRows = 1;
            IEnumerable itemsSource = datagrid.ItemsSource as IEnumerable;
            if (itemsSource != null)
            {
                foreach (var item in itemsSource)
                {
                    DataGridRow row = datagrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                        DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
                        for (int i = 0; i < datagrid.Columns.Count; ++i)
                        {
                            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                            TextBlock txt = cell.Content as TextBlock;
                            if (txt != null)
                            {
                                table.AddCell(new Phrase(txt.Text, font));
                            }
                        }
                    }
                }

                doc.Add(table);
                doc.Close();
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
       where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }
            return null;
        }
    }
}
