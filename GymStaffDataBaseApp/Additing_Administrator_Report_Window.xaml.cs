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
    public partial class Additing_Administrator_Report_Window : Window
    {
        SqlConnection sqlconnection;
        public Additing_Administrator_Report_Window(SqlConnection sqlconnection)
        {
            this.sqlconnection = sqlconnection;
            InitializeComponent();
        }

        private void Additing_Administrator_Report_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Administrator_Window administrator_window = new Administrator_Window(sqlconnection);
            administrator_window.Show();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Premiums_Button_Click(object sender, RoutedEventArgs e)
        {
            FastReport.Report Premiums_Report = new FastReport.Report();
            Premiums_Report.Load(@"C:\Users\НАДЕЖДА\Documents\Visual Studio 2013\Projects\GymStaffDataBaseApp\GymStaffDataBaseApp\Reports\Premiums_Report.frx");
            Premiums_Report.Show();
        }

        private void Spendings_FastReport_Button_Click(object sender, RoutedEventArgs e)
        {
            FastReport.Report Premiums_Report = new FastReport.Report();
            Premiums_Report.Load(@"C:\Users\НАДЕЖДА\Documents\Visual Studio 2013\Projects\GymStaffDataBaseApp\GymStaffDataBaseApp\Reports\Spendings_Report.frx");
            Premiums_Report.Show();
        }
    }
}
