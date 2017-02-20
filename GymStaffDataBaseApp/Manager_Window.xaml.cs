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
    public partial class Manager_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;
        public Manager_Window(SqlConnection sqlconnection, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if(administrator_mode == true)
            {
                Manager_Grid.Background = new LinearGradientBrush(Colors.Black, Colors.Red, 90);
                Exit_Button.Visibility = Visibility.Hidden;
                Back_Button.Visibility = Visibility.Visible;
            }
        }
        private void Manager_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sqlconnection.Close();
            return;
        }
        private void Output_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Output_ComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите название таблицы");
                return;
            }
            Output_Window output_window = new Output_Window(sqlconnection, Output_ComboBox.SelectedItem.ToString().Split(':')[1].TrimStart().Replace(' ', '_'), "Менеджер", administrator_mode);
            output_window.Show();
            this.Close();
        }
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            sqlconnection.Close();
            LoginWindow login_window = new LoginWindow();
            login_window.Show();
            this.Close();
        }
        private void Add_Candidate_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Candidate_Window additing_candidate_window = new Additing_Candidate_Window(sqlconnection, administrator_mode);
            additing_candidate_window.Show();
            this.Close();
       }
        private void Add_Document_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Document_Window additing_document_window = new Additing_Document_Window(sqlconnection, administrator_mode);
            additing_document_window.Show();
            this.Close();
        }
        private void Add_Interview_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Interview_Window additing_interview_window = new Additing_Interview_Window(sqlconnection, administrator_mode);
            additing_interview_window.Show();
            this.Close();
        }
        private void Add_Premium_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Premium_Window additing_premium_window = new Additing_Premium_Window(sqlconnection, administrator_mode);
            additing_premium_window.Show();
            this.Close();
        }
        private void Add_Absent_Employee_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Absent_Employee_Window additing_absent_employee_window = new Additing_Absent_Employee_Window(sqlconnection, administrator_mode);
            additing_absent_employee_window.Show();
            this.Close();
        }
        private void Add_Present_Employee_Button_Click(object sender, RoutedEventArgs e)
        {
            Additing_Return_Employee_Window additing_return_employee_window = new Additing_Return_Employee_Window(sqlconnection, administrator_mode);
            additing_return_employee_window.Show();
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
