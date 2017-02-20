using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GymStaffDataBaseApp
{
    public partial class Output_Window : Window
    {
        SqlConnection sqlconnection;
        string table_name;
        string control_mode;
        bool administrator_mode;
        public Output_Window(SqlConnection sqlconnection, string table_name, string control_mode, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.table_name = table_name;
            this.control_mode = control_mode;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (control_mode == "Менеджер")
            {
                Output_Grid.Background = new SolidColorBrush(Color.FromRgb(18, 119, 178));
                Filter_Label.Foreground = new SolidColorBrush(Colors.White);
            }
            if (control_mode == "Супервайзер")
            {
                Output_Grid.Background = new SolidColorBrush(Color.FromRgb(211, 211, 22));
            }
            if (control_mode == "Администратор")
            {
                Output_Grid.Background = new SolidColorBrush(Color.FromRgb(203, 15, 15));
                Filter_Label.Foreground = new SolidColorBrush(Colors.White);
            }
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = table_name.Replace('_', ' ');
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(String.Format("SELECT * FROM dbo.{0}", table_name), sqlconnection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Data_Grid.ItemsSource = table.DefaultView;
            }
            catch
            {
                MessageBox.Show("Ошибка: Не удалось выполнить SELECT и вывести на экран.");
                return;
            }
            for (int i = 0; i < Data_Grid.Columns.Count; i++)
            {
                Data_Grid.Columns[i].Header = Data_Grid.Columns[i].Header.ToString().Replace('_', ' ');
            }
            string[] temp = new string[Data_Grid.Columns.Count];
            for (int i = 0; i < Data_Grid.Columns.Count; i++)
            {
                temp[i] = Data_Grid.Columns[i].Header.ToString();
            }
            Filter_ComboBox.ItemsSource = temp;
        }
        private void Output_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (control_mode == "Менеджер")
            {
                Manager_Window manager_window = new Manager_Window(sqlconnection, administrator_mode);
                manager_window.Show();
            }
            if (control_mode == "Супервайзер")
            {
                Supervisor_Window supervisor_window = new Supervisor_Window(sqlconnection, administrator_mode);
                supervisor_window.Show();
            }
            if (control_mode == "Администратор")
            {
                Administrator_Window administrator_window = new Administrator_Window(sqlconnection);
                administrator_window.Show();
            }
        }
        private void Text_Changed(object sender, TextChangedEventArgs e)
        {
            try
            {
                SqlDataAdapter adapter;
                string temp = Filter_ComboBox.SelectedItem.ToString().Replace(" ", "_");
                if (temp == "Дата_утверждения" || temp == "Дата_подписания" || temp == "Дата_начала" || temp == "Дата_окончания" || temp == "Дата" || temp == "Дата_собеседования")   
                    adapter = new SqlDataAdapter(String.Format("SELECT * FROM {0} WHERE Convert(VARCHAR(100),{0}.{1},109) Like '{2}%'", table_name, temp, Second_Name_Filter_TextBox.Text), sqlconnection);
                else
                    adapter = new SqlDataAdapter(String.Format("SELECT * FROM {0} WHERE {0}.{1} Like '{2}%'", table_name, temp, Second_Name_Filter_TextBox.Text), sqlconnection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Data_Grid.ItemsSource = table.DefaultView;
            }
            catch
            {
                MessageBox.Show("Ошибка: Не удалось выполнить SELECT и вывести на экран.");
                return;
            }
            for (int i = 0; i < Data_Grid.Columns.Count; i++)
            {
                Data_Grid.Columns[i].Header = Data_Grid.Columns[i].Header.ToString().Replace('_', ' ');
            }
        }
    }
}