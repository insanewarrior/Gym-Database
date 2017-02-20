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
    public partial class Additing_Premium_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;
        DataTable Table_Premium = new DataTable();
        public Additing_Premium_Window(SqlConnection sqlconnection,bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Premium_Grid.Background = new SolidColorBrush(Color.FromRgb(203, 15, 15));
            } 
            SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Get_Employee_For_Premium()", sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);
            adapter.Fill(Table_Premium);
            string[] temp = new string[Table_Premium.Rows.Count];
            for (int i = 0; i < Table_Premium.Rows.Count; i++)
            {
                temp[i] = Table_Premium.Rows[i][0].ToString() + ". " + Table_Premium.Rows[i][2].ToString() + ' ' + Table_Premium.Rows[i][1].ToString() + ' ' + Table_Premium.Rows[i][3].ToString() + " : " + Table_Premium.Rows[i][4].ToString();
            }
            Employee_ComboBox.ItemsSource = temp;
            Date_DatePicker.IsEnabled = false;
            if (Employee_ComboBox.Items.Count == 0)
            {
                MessageBox.Show("Нет работника для выбора");
                Employee_ComboBox.IsEnabled = false;
            }
        }

        private void Additing_Premium_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Manager_Window manager_window = new Manager_Window(sqlconnection, administrator_mode);
            manager_window.Show();
        }

        private void Employee_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Date_DatePicker.IsEnabled = true;
            Date_DatePicker.Text = "";
            Date_DatePicker.DisplayDateStart = Convert.ToDateTime(Table_Premium.Rows[Employee_ComboBox.SelectedIndex][5]);
            Date_DatePicker.DisplayDateEnd = Convert.ToDateTime("2050-12-31");
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Volume_TextBox.Text == "" || Date_DatePicker.SelectedDate == null || Reason_ComboBox.SelectedIndex == -1 || Employee_ComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Обязательные поля не заполнены");
                return;
            }
            if (Validation_Volume(Volume_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели РАЗМЕР ПРЕМИИ в неправильном формате\nПравильный формат : 3-4ти значное число");
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
            sqlcommand.CommandText = "Insert_Premium";
            sqlcommand.Parameters.AddWithValue("@Размер", Volume_TextBox.Text);
            sqlcommand.Parameters.AddWithValue("@Причина", Reason_ComboBox.SelectedItem.ToString().Split(':')[1].TrimStart());
            sqlcommand.Parameters.AddWithValue("@Дата", Date_DatePicker.SelectedDate);
            sqlcommand.Parameters.AddWithValue("@id_Работник", Employee_ComboBox.SelectedItem.ToString().Split(' ')[0].Replace(".", ""));
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            this.Close();
        }

        private bool Validation_Volume(string To_Check)
        {
            Regex regex = new Regex("^[1-9][0-9]{2,3}$");
            if (regex.IsMatch(To_Check))
                return true;
            else
                return false;
        }

    }
}
