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

namespace GymStaffDataBaseApp
{
    
    public partial class Additing_Shedule_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;
        public Additing_Shedule_Window(SqlConnection sqlconnection, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Shedule_Grid.Background = new SolidColorBrush(Color.FromRgb(203, 15, 15));
                Post_Label.Foreground = new SolidColorBrush(Colors.White);
                Start_Time_Label.Foreground = new SolidColorBrush(Colors.White);
                Finish_Time_Label.Foreground = new SolidColorBrush(Colors.White);
                Vacations_Quentity_Label.Foreground = new SolidColorBrush(Colors.White);
                Days_To_Work_Quentity_Label.Foreground = new SolidColorBrush(Colors.White);
                Days_To_Work_Before_Vacation_Quentity_Label.Foreground = new SolidColorBrush(Colors.White);
                Confirm_Date_Label.Foreground = new SolidColorBrush(Colors.White);
            } 
            DataTable table = new DataTable();
            Confirm_Date_DatePicker.DisplayDateStart = DateTime.Today;
            SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Get_Posts()", sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);
            adapter.Fill(table);
            string[] temp = new string[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                temp[i] = table.Rows[i][0].ToString() + ". " + table.Rows[i][1].ToString();
            }
            Post_ComboBox.ItemsSource = temp;
            if (Post_ComboBox.Items.Count == 0)
            {
                MessageBox.Show("Нет должностей для выбора");
                Post_ComboBox.IsEnabled = false;
            }
        }

        private void Additing_Shedule_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
            if (Confirm_Date_DatePicker.SelectedDate == null || Days_To_Work_Before_Vacation_Quentity_TextBox.Text == "" || Days_To_Work_Quentity_TextBox.Text == "" || Start_Time_TextBox.Text == "" || Finish_Time_TextBox.Text == "" || Post_ComboBox.SelectedIndex == -1 || Vacations_Quentity_TextBox.Text == "")
            {
                MessageBox.Show("Обязательные поля не заполнены");
                return;
            }

            if (Validation_Time(Start_Time_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели ВРЕМЯ НАЧАЛА в неправильном формате\nПравильный формат : 00:00");
                return;
            }

            if (Validation_Time(Finish_Time_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели ВРЕМЯ ОКОНЧАНИЯ в неправильном формате\nПравильный формат : 00:00");
                return;
            }

            if (Validation_Vacations_Quentity(Vacations_Quentity_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели КОЛ-ВО ДНЕЙ ОТПУСКА в неправильном диапазоне\nПравильный диапозон : 10 - 90 дней");
                return;
            }

            if (Validation_Days_To_Work_Quentity(Days_To_Work_Quentity_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели КОЛ-ВО РАБОЧИХ ДНЕЙ в неправильном диапазоне\nПравильный диапозон : 240 - 300 дней");

                return;
            }

            if (Validation_Days_To_Work_Before_Vacation_Quentity(Days_To_Work_Before_Vacation_Quentity_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели КОЛ-ВО РАБОЧИХ ДНЕЙ ДО ОТПУСКА в неправильном диапазоне\nПравильный диапозон : 90 - 270 дней");
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
            sqlcommand.CommandText = "Insert_Schedule";
            sqlcommand.Parameters.AddWithValue("@id_Должность", Post_ComboBox.SelectedItem.ToString().Split(' ')[0].Replace(".", ""));
            sqlcommand.Parameters.AddWithValue("@Время_начала", Start_Time_TextBox.Text);
            sqlcommand.Parameters.AddWithValue("@Время_окончания", Finish_Time_TextBox.Text);
            sqlcommand.Parameters.AddWithValue("@Количество_дней_отпуска", Vacations_Quentity_TextBox.Text);
            sqlcommand.Parameters.AddWithValue("@Количество_рабочих_дней", Days_To_Work_Quentity_TextBox.Text);
            sqlcommand.Parameters.AddWithValue("@Количество_рабочих_дней_до_отпуска", Days_To_Work_Before_Vacation_Quentity_TextBox.Text);
            sqlcommand.Parameters.AddWithValue("@Дата_утверждения", Confirm_Date_DatePicker.SelectedDate);
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            this.Close();
        }

        private bool Validation_Time(string To_Check)
        {
            Regex regex = new Regex("(^[0-2][0-3]:[0-5][0-9]$)|(^[0-1][0-9]:[0-5][0-9]$)");
            if (regex.IsMatch(To_Check))
                return true;
            else
                return false;
        }

        private bool Validation_Vacations_Quentity(string To_Check)
        {
            Regex regex = new Regex("^([1-8][0-9]$)|(90)");
            if (regex.IsMatch(To_Check))
                return true;
            else
                return false;
        }

        private bool Validation_Days_To_Work_Quentity(string To_Check)
        {
            Regex regex = new Regex("(^2[4-9][0-9]$)|(300)");
            if (regex.IsMatch(To_Check))
                return true;
            else
                return false;
        }

        private bool Validation_Days_To_Work_Before_Vacation_Quentity(string To_Check)
        {
            Regex regex = new Regex("(^9[0-9]$)|(^1[0-9]{2}$)|(^2[0-6][0-9]$)|(270)");
            if (regex.IsMatch(To_Check))
                return true;
            else
                return false;
        }
    }
}
