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
using System.Text.RegularExpressions;
using System.Configuration;

namespace GymStaffDataBaseApp
{
    public partial class Additing_Post_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;
        public Additing_Post_Window(SqlConnection sqlconnection, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Post_Grid.Background = new SolidColorBrush(Color.FromRgb(203, 15, 15));
                Duty_Label.Foreground = new SolidColorBrush(Colors.White);
                Salary_Label.Foreground = new SolidColorBrush(Colors.White);
                Work_Place_Label.Foreground = new SolidColorBrush(Colors.White);
            } 
            SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Get_Work_Places()", sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);
            DataTable table = new DataTable();
            adapter.Fill(table);
            string[] temp = new string[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                temp[i] = table.Rows[i][0].ToString() + ". " + table.Rows[i][1].ToString();
            }
            Work_Place_ComboBox.ItemsSource = temp;
            if (Work_Place_ComboBox.Items.Count == 0)
            {
                MessageBox.Show("Нет рабочих мест для выбора");
                Work_Place_ComboBox.IsEnabled = false;
            }
        }

        private void Additing_Post_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
            if (Duty_TextBox.Text == "" || Salary_TextBox.Text == "" || Work_Place_ComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Обязательные поля не заполнены");
                return;
            }
            if (Validation_Duty(Duty_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели ОБЯЗАННОСТЬ в неправильном формате\nПравильный формат : кириллица(пробел и дефис разрешены)");
                return;
            }
            if (Validation_Salary(Salary_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели РАЗМЕР ЗАРПЛАТЫ в неправильном формате\nПравильный формат : 4-5ти значное число");
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
            sqlcommand.CommandText = "Insert_Post";
            sqlcommand.Parameters.AddWithValue("@Обязанность", Duty_TextBox.Text);
            sqlcommand.Parameters.AddWithValue("@Зарплата", Salary_TextBox.Text);
            sqlcommand.Parameters.AddWithValue("@id_Рабочее_место", Work_Place_ComboBox.SelectedItem.ToString().Split(' ')[0].Replace(".", ""));
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            this.Close();
        }

        private bool Validation_Duty(string To_Check)
        {
            Regex regex = new Regex("^[а-яА-Я\\-\\s]+$");
            if (regex.IsMatch(To_Check))
                return true;
            else
                return false;
        }

        private bool Validation_Salary(string To_Check)
        {
            Regex regex = new Regex("^[1-9][0-9]{3,4}$");
            if (regex.IsMatch(To_Check))
                return true;
            else
                return false;
        }
    }
}
