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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace GymStaffDataBaseApp
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            //string test = "6/4/2016 00:00:00.000";
            //string[] mas = new string[4];
            //if (test.Split('/', ' ')[0].ToString().Length == 2 && test.Split('/', ' ')[1].ToString().Length == 2)
            //    MessageBox.Show(test.Split('/', ' ')[2] + '-' + test.Split('/', ' ')[0] + '-' + test.Split('/', ' ')[1]+" 00:00:00.000");

            //if (test.Split('/', ' ')[0].ToString().Length == 1 && test.Split('/', ' ')[1].ToString().Length == 2)
            //    MessageBox.Show(test.Split('/', ' ')[2] + "-0" + test.Split('/', ' ')[0] + '-' + test.Split('/', ' ')[1] + " 00:00:00.000");

            //if (test.Split('/', ' ')[0].ToString().Length == 2 && test.Split('/', ' ')[1].ToString().Length == 1)
            //    MessageBox.Show(test.Split('/', ' ')[2] + '-' + test.Split('/', ' ')[0] + "-0" + test.Split('/', ' ')[1] + " 00:00:00.000");

            //if (test.Split('/', ' ')[0].ToString().Length == 1 && test.Split('/', ' ')[1].ToString().Length == 1)
            //    MessageBox.Show(test.Split('/', ' ')[2] + "-0" + test.Split('/', ' ')[0] + "-0" + test.Split('/', ' ')[1] + " 00:00:00.000");
        }

        private void Login_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            return;
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Login_TextBox.Text == "")
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (Password_TextBox.Password == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            string connection = String.Format("Persist Security Info=False;Data Source=.\\SQLEXPRESS;Initial Catalog=\"Gym Staff DataBase\";User ID={0};Password={1}", Login_TextBox.Text, Password_TextBox.Password);
            //string connection = String.Format("Data Source=.\\SQLEXPRESS;Initial Catalog=\"Gym Staff DataBase\";Integrated Security=True;User ID={0};Password={1}", Login_TextBox.Text, Password_TextBox.Password);
            SqlConnection sqlconnection = new SqlConnection(connection);
            try
            {
                sqlconnection.Open();
            }
            catch 
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

            DataTable Table_Role_Check = new DataTable();

            SqlCommand sqlcommmand = new SqlCommand(String.Format("SELECT * FROM Role_Check('{0}','{1}')", "Manager", Login_TextBox.Text), sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommmand);
            adapter.Fill(Table_Role_Check);
            if (Convert.ToInt32(Table_Role_Check.Rows[0][0].ToString()) == 1)
            {
                Manager_Window manager_window = new Manager_Window(sqlconnection, false);
                manager_window.Show();
            }
            Table_Role_Check.Clear();
            sqlcommmand = new SqlCommand(String.Format("SELECT * FROM Role_Check('{0}','{1}')", "Supervisor", Login_TextBox.Text), sqlconnection);
            adapter = new SqlDataAdapter(sqlcommmand);
            adapter.Fill(Table_Role_Check);
            if (Convert.ToInt32(Table_Role_Check.Rows[0][0].ToString()) == 1)
            {
                Supervisor_Window supervisor_window = new Supervisor_Window(sqlconnection, false);
                supervisor_window.Show();
            }
            Table_Role_Check.Clear();
            sqlcommmand = new SqlCommand(String.Format("SELECT * FROM Role_Check('{0}','{1}')", "Administrator", Login_TextBox.Text), sqlconnection);
            adapter = new SqlDataAdapter(sqlcommmand);
            adapter.Fill(Table_Role_Check);
            if (Convert.ToInt32(Table_Role_Check.Rows[0][0].ToString()) == 1)
            {
                Administrator_Window administrator_window = new Administrator_Window(sqlconnection);
                administrator_window.Show();
            }
            Table_Role_Check.Clear();
            this.Close();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
