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
    public partial class Additing_Return_Employee_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;
        DataTable Table_Employee_To_Return = new DataTable();
        public Additing_Return_Employee_Window(SqlConnection sqlconnection, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Return_Employee_Grid.Background = new SolidColorBrush(Color.FromRgb(203, 15, 15));
            } 
            this.administrator_mode = administrator_mode;
            SqlCommand sqlcommmand = new SqlCommand("SELECT * FROM Get_Employee_To_Return()", sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommmand);
            adapter.Fill(Table_Employee_To_Return);
            string[] temp = new string[Table_Employee_To_Return.Rows.Count];
            for (int i = 0; i < Table_Employee_To_Return.Rows.Count; i++)
            {
                temp[i] = Table_Employee_To_Return.Rows[i][0].ToString() + ". " + Table_Employee_To_Return.Rows[i][2].ToString() + ' ' + Table_Employee_To_Return.Rows[i][1].ToString() + ' ' + Table_Employee_To_Return.Rows[i][3].ToString() + " : " + Table_Employee_To_Return.Rows[i][4].ToString();
            }
            Employee_ComboBox.ItemsSource = temp;
            FinishDate_DatePicker.IsEnabled = false;
            if (Employee_ComboBox.Items.Count == 0)
            {
                MessageBox.Show("Нет работников для выбора");
                Employee_ComboBox.IsEnabled = false;
            }
        }

        private void Employee_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FinishDate_DatePicker.IsEnabled = true;
            FinishDate_DatePicker.Text = "";
            FinishDate_DatePicker.DisplayDateStart = Convert.ToDateTime(Table_Employee_To_Return.Rows[Employee_ComboBox.SelectedIndex][6]);
            FinishDate_DatePicker.DisplayDateEnd = Convert.ToDateTime("2050-12-31");
        }

        private void Additing_Return_Employee_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Manager_Window manager_window = new Manager_Window(sqlconnection, administrator_mode);
            manager_window.Show();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Employee_ComboBox.SelectedIndex == -1 || FinishDate_DatePicker.SelectedDate == null)
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
            sqlcommand.CommandText = "Set_Finish_Date_Absent_Employee";
            sqlcommand.Parameters.AddWithValue("@id_Отсутствующий_работник", Convert.ToInt32(Table_Employee_To_Return.Rows[Employee_ComboBox.SelectedIndex][5]));
            sqlcommand.Parameters.AddWithValue("@Дата_окончания", FinishDate_DatePicker.SelectedDate);
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
