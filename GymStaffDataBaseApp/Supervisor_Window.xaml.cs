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
    public partial class Supervisor_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;
        public Supervisor_Window(SqlConnection sqlconnection, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Supervisor_Grid.Background = new LinearGradientBrush(Colors.Black, Colors.Red, 90);
                Exit_Button.Visibility = Visibility.Hidden;
                Back_Button.Visibility = Visibility.Visible;
            }
        }
        private void Supervisor_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
            Output_Window output_window = new Output_Window(sqlconnection, Output_ComboBox.SelectedItem.ToString().Split(':')[1].TrimStart().Replace(' ', '_'), "Супервайзер", administrator_mode);
            output_window.Show();
            this.Close();
        }
        private void Add_Post_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Post_Window additing_post_window = new Additing_Post_Window(sqlconnection, administrator_mode);
            additing_post_window.Show();
            this.Close();
        }
        private void Add_Work_Place_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Work_Place_Window additing_work_place_window = new Additing_Work_Place_Window(sqlconnection, administrator_mode);
            additing_work_place_window.Show();
            this.Close();
        }
        private void Add_Shedule_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Shedule_Window additing_shedule_window = new Additing_Shedule_Window(sqlconnection, administrator_mode);
            additing_shedule_window.Show();
            this.Close();
        }
        private void Fire_Employee_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Firing_Employee_Window additing_firing_employee_window = new Additing_Firing_Employee_Window(sqlconnection, administrator_mode);
            additing_firing_employee_window.Show();
            this.Close();
        }
        private void Change_Post_Button_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Change_Post_Window additing_change_post_window = new Additing_Change_Post_Window(sqlconnection, administrator_mode);
            additing_change_post_window.Show();
            this.Close();
        }
        private void Report_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Supervisor_Report_Window additing_report_window = new Additing_Supervisor_Report_Window(sqlconnection, administrator_mode);
            additing_report_window.Show();
            this.Close();
        }
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Administrator_Window administrator_window = new Administrator_Window(sqlconnection);
            administrator_window.Show();
            this.Close();
        }
    }
}
