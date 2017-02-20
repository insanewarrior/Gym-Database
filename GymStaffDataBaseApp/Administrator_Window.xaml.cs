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
    public partial class Administrator_Window : Window
    {
        SqlConnection sqlconnection;
        public Administrator_Window(SqlConnection sqlconnection)
        {
            this.sqlconnection = sqlconnection;
            InitializeComponent();
        }

        private void Administrator_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sqlconnection.Close();
            return;
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            sqlconnection.Close();
            LoginWindow login_window = new LoginWindow();
            login_window.Show();
            this.Close();
        }

        private void Output_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Output_ComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите название таблицы");
                return;
            }
            Output_Window output_window = new Output_Window(sqlconnection, Output_ComboBox.SelectedItem.ToString().Split(':')[1].TrimStart().Replace(' ', '_'), "Администратор", true);
            output_window.Show();
            this.Close();
        }

        private void Manager_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager_Window manager_window = new Manager_Window(sqlconnection, true);
            manager_window.Show();
            this.Close();
        }

        private void Supervisor_Button_Click(object sender, RoutedEventArgs e)
        {
            Supervisor_Window supervisor_window = new Supervisor_Window(sqlconnection, true);
            supervisor_window.Show();
            this.Close();
        }

        private void Admin_Reports_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Administrator_Report_Window additing_administrator_report_window = new Additing_Administrator_Report_Window(sqlconnection);
            additing_administrator_report_window.Show();
            this.Close();
        }
    }
}
