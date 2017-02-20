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
    public partial class Additing_Change_Post_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;
        DataTable Table_Employee;
        DataTable Table_Post;
        DataTable Table_Document;
        public Additing_Change_Post_Window(SqlConnection sqlconnection, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Change_Post_Grid.Background = new SolidColorBrush(Color.FromRgb(203, 15, 15));
                Emploee_Label.Foreground = new SolidColorBrush(Colors.White);
                New_Post_Label.Foreground = new SolidColorBrush(Colors.White);
                Document_Label.Foreground = new SolidColorBrush(Colors.White);
            } 
            SqlCommand sqlcommand = new SqlCommand("SELECT * FROM Get_Working_Employees()", sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);
            Table_Employee = new DataTable();
            adapter.Fill(Table_Employee);
            string[] temp = new string[Table_Employee.Rows.Count];
            for (int i = 0; i < Table_Employee.Rows.Count; i++)
            {
                temp[i] = Table_Employee.Rows[i][0].ToString() + ". " + Table_Employee.Rows[i][2].ToString() + ' ' + Table_Employee.Rows[i][1].ToString() + ' ' + Table_Employee.Rows[i][3].ToString() + " : " + Table_Employee.Rows[i][4].ToString();
            }
            Employee_ComboBox.ItemsSource = temp;

            sqlcommand = new SqlCommand("SELECT * FROM Get_Free_Posts()", sqlconnection);
            adapter = new SqlDataAdapter(sqlcommand);
            Table_Post = new DataTable();
            adapter.Fill(Table_Post);
            temp = new string[Table_Post.Rows.Count];
            for (int i = 0; i < Table_Post.Rows.Count; i++)
            {
                temp[i] = Table_Post.Rows[i][0].ToString() + ". " + Table_Post.Rows[i][1].ToString();
            }
            New_Post_ComboBox.ItemsSource = temp;

            sqlcommand = new SqlCommand(String.Format("SELECT * FROM Get_Free_Documents('{2}{1}{0}')", DateTime.Today.Date.ToShortDateString().Split('.')), sqlconnection);
            adapter = new SqlDataAdapter(sqlcommand);
            Table_Document = new DataTable();
            adapter.Fill(Table_Document);
            temp = new string[Table_Document.Rows.Count];
            for (int i = 0; i < Table_Document.Rows.Count; i++)
            {
                temp[i] = Table_Document.Rows[i][0].ToString() + ". " + Table_Document.Rows[i][1].ToString() + " : " + Table_Document.Rows[i][2].ToString().Split(' ')[0];
            }
            Document_ComboBox.ItemsSource = temp;
            if (Employee_ComboBox.Items.Count == 0)
            {
                MessageBox.Show("Нет работников для выбора");
                Employee_ComboBox.IsEnabled = false;
            }
            if (New_Post_ComboBox.Items.Count == 0)
            {
                MessageBox.Show("Нет должностей для выбора");
                New_Post_ComboBox.IsEnabled = false;
            }
            if (Document_ComboBox.Items.Count == 0)
            {
                MessageBox.Show("Нет документов для выбора");
                Document_ComboBox.IsEnabled = false;
            }
        }

        private void Additing_Change_Post_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Supervisor_Window supervisor_window = new Supervisor_Window(sqlconnection, administrator_mode);
            supervisor_window.Show();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (New_Post_ComboBox.SelectedIndex == -1 || Employee_ComboBox.SelectedIndex == -1 || Document_ComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Обязательные поля не заполнены");
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
            sqlcommand.CommandText = "Firing_Employee";
            sqlcommand.Parameters.AddWithValue("@Дата_окончания", DateTime.Today);
            sqlcommand.Parameters.AddWithValue("@id_Собеседование", Table_Employee.Rows[Employee_ComboBox.SelectedIndex][6].ToString().Split(' ')[0].Replace(".",""));
            sqlcommand.ExecuteNonQuery();
            sqlcommand = sqlconnection.CreateCommand();
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.CommandText = "Insert_Interview";
            sqlcommand.Parameters.AddWithValue("@id_Документ", Document_ComboBox.SelectedItem.ToString().Split(' ')[0].Replace(".", ""));
            sqlcommand.Parameters.AddWithValue("@Дата_собеседования", DateTime.Today.Date);
            sqlcommand.Parameters.AddWithValue("@id_Кандидат", Table_Employee.Rows[Employee_ComboBox.SelectedIndex][7].ToString().Split(' ')[0].Replace(".", ""));
            sqlcommand.Parameters.AddWithValue("@id_Должность", New_Post_ComboBox.SelectedItem.ToString().Split(' ')[0].Replace(".", ""));
            sqlcommand.Parameters.AddWithValue("@Результат", "Нанят");
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
