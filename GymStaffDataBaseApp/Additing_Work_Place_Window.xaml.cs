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
    public partial class Additing_Work_Place_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;
        public Additing_Work_Place_Window(SqlConnection sqlconnection, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Work_Place_Grid.Background = new SolidColorBrush(Color.FromRgb(203, 15, 15));
                Description_Label.Foreground = new SolidColorBrush(Colors.White);
                Location_Label.Foreground = new SolidColorBrush(Colors.White);
            } 
        }

        private void Additing_Work_Place_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Supervisor_Window supervisor_window = new Supervisor_Window(sqlconnection, administrator_mode);
            supervisor_window.Show();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Description_TextBox.Text == "" || Location_TextBox.Text == "")
            {
                MessageBox.Show("Обязательные поля не заполнены");
                return;
            }
            if (Validation_Field(Description_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели ОПИСАНИЕ в неправильном формате\nПравильный формат : кириллица(пробел и дефис разрешены)");
                return;
            }
            if (Validation_Field(Location_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели РАСПОЛОЖЕНИЕ в неправильном формате\nПравильный формат : кириллица(пробел и дефис разрешены)");
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
            sqlcommand.CommandText = "Insert_Work_Place";
            sqlcommand.Parameters.AddWithValue("@Расположение", Location_TextBox.Text);
            sqlcommand.Parameters.AddWithValue("@Описание", Description_TextBox.Text);
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            this.Close();
        }

        private bool Validation_Field(string To_Check)
        {
            Regex regex = new Regex("^[а-яА-Я\\-\\s]+$");
            if (regex.IsMatch(To_Check))
                return true;
            else
                return false;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
