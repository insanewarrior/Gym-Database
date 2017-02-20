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
using System.Data.SqlClient;

namespace GymStaffDataBaseApp
{
    public partial class Additing_Supervisor_Report_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;
        public Additing_Supervisor_Report_Window(SqlConnection sqlconnection, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Supervisor_Report_Grid.Background = new SolidColorBrush(Color.FromRgb(203, 15, 15));
            } 
        }

        private void Additing_Supervisor_Report_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Supervisor_Window supervisor_window = new Supervisor_Window(sqlconnection,administrator_mode);
            supervisor_window.Show();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Working_Employees_FastReport_Button_Click(object sender, RoutedEventArgs e)
        {
            FastReport.Report Working_Employees_Report = new FastReport.Report();
            Working_Employees_Report.Load(@"C:\Users\НАДЕЖДА\Documents\Visual Studio 2013\Projects\GymStaffDataBaseApp\GymStaffDataBaseApp\Reports\Working_Employees_Report.frx");
            Working_Employees_Report.Show();
        }

        private void Absent_Employees_Button_Click(object sender, RoutedEventArgs e)
        {
            FastReport.Report Absent_Employees_Report = new FastReport.Report();
            Absent_Employees_Report.Load(@"C:\Users\НАДЕЖДА\Documents\Visual Studio 2013\Projects\GymStaffDataBaseApp\GymStaffDataBaseApp\Reports\Absent_Employees_Report.frx");
            Absent_Employees_Report.Show();
        }

        private void Free_Posts_Button_Click(object sender, RoutedEventArgs e)
        {
            FastReport.Report Free_Posts_Report = new FastReport.Report();
            Free_Posts_Report.Load(@"C:\Users\НАДЕЖДА\Documents\Visual Studio 2013\Projects\GymStaffDataBaseApp\GymStaffDataBaseApp\Reports\Free_Posts_Report.frx");
            Free_Posts_Report.Show();
        }
    }
}
