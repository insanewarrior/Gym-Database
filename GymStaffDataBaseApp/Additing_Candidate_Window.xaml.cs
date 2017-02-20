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
    public partial class Additing_Candidate_Window : Window
    {
        bool administrator_mode;  
        SqlConnection sqlconnection;
        public Additing_Candidate_Window(SqlConnection sqlconnection, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Candidate_Grid.Background = new SolidColorBrush(Color.FromRgb(203,15,15));
            } 
        }

        private void Additing_Candidate_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
            if (First_Name_TextBox.Text == "" || Second_Name_TextBox.Text == "" || Phone_TextBox.Text == "" || IDC_TextBox.Text == "" || Passport_TextBox.Text == "") 
            { 
                MessageBox.Show("Обязательные поля не заполнены\nНеобязательные поля: ОТЧЕСТВО, АДРЕС"); 
                return; 
            }

            if (Validation_Names(First_Name_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели ИМЯ в неправильном формате\nПравильный формат : кириллица(пробел и дефис разрешены)");
                return;
            }

            if (Validation_Names(Second_Name_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели ФАМИЛИЮ в неправильном формате\nПравильный формат : кириллица(пробел и дефис разрешены)");
                return;
            }

            if (Validation_Names(Middle_Name_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели ОТЧЕСТВО в неправильном формате\nПравильный формат : кириллица(пробел и дефис разрешены)");
                return;
            }

            if (Validation_Field(Adress_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели АДРЕС в неправильном формате\nПравильный формат : кириллица и цифры(пробел и дефис разрешены)");
                return;
            }

            if (Validation_Phone(Phone_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели НОМЕР ТЕЛЕФОНА в неправильном формате\nПравильный формат : 380*********");
                return;
            }

            if (Validation_IDN(IDC_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели ИДЕНТИФИКАЦИОННЫЙ КОД в неправильном формате\nПравильный формат : десять цифр");
                return;
            }

            if (Validation_Field(Passport_TextBox.Text) == false)
            {
                MessageBox.Show("Вы ввели НОМЕР ПАСПОРТА в неправильном формате\nПравильный формат : кириллица и цифры(пробел и дефис разрешены)");
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
            sqlcommand.CommandText = "Insert_Candidate";
            sqlcommand.Parameters.AddWithValue("@Имя", First_Name_TextBox.Text);
            sqlcommand.Parameters.AddWithValue("@Фамилия", Second_Name_TextBox.Text);
            if (Middle_Name_TextBox.Text == "")
            { 
                sqlcommand.Parameters.AddWithValue("@Отчество", null); 
            }
            else
            {
                sqlcommand.Parameters.AddWithValue("@Отчество", Middle_Name_TextBox.Text);
            }
            if (Adress_TextBox.Text =="")
            {
                sqlcommand.Parameters.AddWithValue("@Адрес", null);
            }
            else
            {
                sqlcommand.Parameters.AddWithValue("@Адрес", Adress_TextBox.Text);
            }
            sqlcommand.Parameters.AddWithValue("@Телефон", Phone_TextBox.Text);
            sqlcommand.Parameters.AddWithValue("@Идентификационный_код", IDC_TextBox.Text);
            sqlcommand.Parameters.AddWithValue("@Номер_паспорта", Passport_TextBox.Text);
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            this.Close();
        }

        private bool Validation_IDN(string To_Check)
        {
            Regex regex = new Regex("[0-9]{10,10}$");
            if (regex.IsMatch(To_Check))
                 return true;
            else
                 return false;
        }

        private bool Validation_Phone(string To_Check)
        {
            Regex regex = new Regex("380[0-9]{9,9}$");
            if (regex.IsMatch(To_Check))
                return true;
            else
                return false;
        }

        private bool Validation_Names(string To_Check)
        {
            Regex regex = new Regex("^[а-яА-Я\\-\\s]+$");
            if (regex.IsMatch(To_Check))
                return true;
            else
                return false;
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
