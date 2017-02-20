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
    /// Логика для Additing_Document_Window.xaml
    public partial class Additing_Document_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;
        public Additing_Document_Window(SqlConnection sqlconnection,bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Document_Grid.Background = new SolidColorBrush(Color.FromRgb(203, 15, 15));
            } 
        }

        private void Additing_Document_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
                Manager_Window manager_window = new Manager_Window(sqlconnection, administrator_mode);
                manager_window.Show();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Description_TextBox.Text == "" || Approval_DatePicker.SelectedDate == null)
            {
                MessageBox.Show("Обязательные поля не заполнены");
                return;
            }
            if (Validation_Field(Description_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели ОПИСАНИЕ в неправильном формате\nПравильный формат : кириллица и цифры(пробел и дефис разрешены)");
                return;
            }
            SqlCommand command = sqlconnection.CreateCommand();
            try
            {
                sqlconnection.Open();
            }
            catch
            {
                MessageBox.Show("Не удалось корректно\nподключиться к базе данных");
                return;
            }
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Insert_Document";
            command.Parameters.AddWithValue("@Дата_подписания", Approval_DatePicker.SelectedDate);
            command.Parameters.AddWithValue("@Описание", Description_TextBox.Text);
            command.ExecuteNonQuery();
            sqlconnection.Close();
            this.Close();
        }

        private bool Validation_Field(string To_Check)
        {
            Regex regex = new Regex("^[а-яА-Я0-9\\-\\s]*$");
            if (regex.IsMatch(To_Check))
                return true;
            else
                return false;
        }

    }
}
