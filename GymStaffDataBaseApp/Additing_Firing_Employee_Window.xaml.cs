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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GymStaffDataBaseApp
{
    public partial class Additing_Firing_Employee_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;
        DataTable table = new DataTable();
        public Additing_Firing_Employee_Window(SqlConnection sqlconnection, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Firing_Grid.Background = new SolidColorBrush(Color.FromRgb(203, 15, 15));
                Employee_Label.Foreground = new SolidColorBrush(Colors.White);
                Date_Label.Foreground = new SolidColorBrush(Colors.White);
            } 
            SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Get_Working_Employees()", sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);
            adapter.Fill(table);
            string[] temp = new string[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                temp[i] = table.Rows[i][0].ToString() + ". " + table.Rows[i][2].ToString() + ' ' + table.Rows[i][1].ToString() + ' ' + table.Rows[i][3].ToString() + " : " + table.Rows[i][4].ToString();
            }
            Employee_ComboBox.ItemsSource = temp;
            if (Employee_ComboBox.Items.Count == 0)
            {
                MessageBox.Show("Нет работников для выбора");
                Employee_ComboBox.IsEnabled = false;
            }
        }

        private void Employee_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Date_Label.Content = "Дата начала работы    " + Convert.ToDateTime(table.Rows[Employee_ComboBox.SelectedIndex][5]).Date.ToString().Split(' ')[0];
        }

        private void Additing_Firing_Employee_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Supervisor_Window supervisor_window = new Supervisor_Window(sqlconnection, administrator_mode);
            supervisor_window.Show();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Employee_ComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Обязательные поля не заполнены");
                return;
            }
            SqlCommand sqlcommand = sqlconnection.CreateCommand();
            try
            {
                sqlconnection.Open();
            }
            catch
            {
                MessageBox.Show("Не удалось корректно\nподключиться к базе данных");
                return;
            }
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.CommandText = "Firing_Employee";
            sqlcommand.Parameters.AddWithValue("@Дата_окончания", DateTime.Today);
            sqlcommand.Parameters.AddWithValue("@id_Собеседование", table.Rows[Employee_ComboBox.SelectedIndex][6].ToString().Split(' ')[0].Replace(".", ""));
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            this.Close();
        }
    }
}
