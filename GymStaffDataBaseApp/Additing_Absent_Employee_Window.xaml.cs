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
    public partial class Additing_Absent_Employee_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;
        DataTable Table_Absent_Employees = new DataTable();
        public Additing_Absent_Employee_Window(SqlConnection sqlconnection, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Absent_Emoloyee_Grid.Background = new SolidColorBrush(Color.FromRgb(203, 15, 15));
            } 
            SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Get_Employee_To_Miss()", sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);
            adapter.Fill(Table_Absent_Employees);
            string[] temp = new string[Table_Absent_Employees.Rows.Count];
            for (int i = 0; i < Table_Absent_Employees.Rows.Count; i++)
            {
                temp[i] = Table_Absent_Employees.Rows[i][0].ToString() + ". " + Table_Absent_Employees.Rows[i][2].ToString() + ' ' + Table_Absent_Employees.Rows[i][1].ToString() + ' ' + Table_Absent_Employees.Rows[i][3].ToString() + " : " + Table_Absent_Employees.Rows[i][4].ToString();
            }
            Employee_ComboBox.ItemsSource = temp;
            StartDate_DatePicker.IsEnabled = false;
            FinishDate_DatePicker.IsEnabled = false;
            if (Employee_ComboBox.Items.Count == 0)
            {
                MessageBox.Show("Нет работников для выбора");
                Employee_ComboBox.IsEnabled = false;
            }
        }

        private void Employee_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StartDate_DatePicker.IsEnabled = true;
            StartDate_DatePicker.Text = "";
            FinishDate_DatePicker.Text = "";
            StartDate_DatePicker.DisplayDateStart = Convert.ToDateTime(Table_Absent_Employees.Rows[Employee_ComboBox.SelectedIndex][5]);
            StartDate_DatePicker.DisplayDateEnd = Convert.ToDateTime("2050-12-31");
        }

        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
                if (StartDate_DatePicker.Text != "")
                {
                    FinishDate_DatePicker.IsEnabled = true;
                    FinishDate_DatePicker.Text = "";
                    FinishDate_DatePicker.DisplayDateStart = Convert.ToDateTime(StartDate_DatePicker.Text);
                    FinishDate_DatePicker.DisplayDateEnd = Convert.ToDateTime("2050-12-31");
                }
                else
                {
                    FinishDate_DatePicker.IsEnabled = false;
                    StartDate_DatePicker.Text = "";
                }
        }

        private void Additing_Absent_Employee_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Manager_Window manager_window = new Manager_Window(sqlconnection, administrator_mode);
            manager_window.Show();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (StartDate_DatePicker.SelectedDate == null || Employee_ComboBox.SelectedIndex == -1 || Reason_TextBox.SelectedIndex == -1)
            {
                MessageBox.Show("Обязательные поля не заполнены\nНеобязательное поле: ДАТА ОКОНЧАНИЯ");
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
            sqlcommand.CommandText = "Insert_Employee_Is_Absent";
            sqlcommand.Parameters.AddWithValue("@Дата_начала", StartDate_DatePicker.SelectedDate);
            sqlcommand.Parameters.AddWithValue("@Дата_окончания", FinishDate_DatePicker.SelectedDate);
            sqlcommand.Parameters.AddWithValue("@Причина", Reason_TextBox.SelectedItem.ToString().Split(':')[1].TrimStart());
            sqlcommand.Parameters.AddWithValue("@id_Работник", Employee_ComboBox.SelectedItem.ToString().Split(' ')[0].Replace(".",""));
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
