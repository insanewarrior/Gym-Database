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
    public partial class Additing_Interview_Window : Window
    {
        SqlConnection sqlconnection;
        bool administrator_mode;

        DataTable Table_Free_Candidates = new DataTable();
        public Additing_Interview_Window(SqlConnection sqlconnection, bool administrator_mode)
        {
            this.sqlconnection = sqlconnection;
            this.administrator_mode = administrator_mode;
            InitializeComponent();
            if (administrator_mode == true)
            {
                Interview_Grid.Background = new SolidColorBrush(Color.FromRgb(203, 15, 15));
            } 
            SqlCommand sqlcommmand = new SqlCommand("SELECT * FROM Get_Free_Candidates()", sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommmand);
            adapter.Fill(Table_Free_Candidates);
            string[] temp = new string[Table_Free_Candidates.Rows.Count];
            for (int i = 0; i < Table_Free_Candidates.Rows.Count; i++)
            {
                temp[i] = Table_Free_Candidates.Rows[i][3].ToString() + ". " + Table_Free_Candidates.Rows[i][1].ToString() + ' ' + Table_Free_Candidates.Rows[i][0].ToString() + ' ' + Table_Free_Candidates.Rows[i][2].ToString();
            }
            Candidate_ComboBox.ItemsSource = temp;
            DataTable Table_Free_Posts = new DataTable();
            sqlcommmand = new SqlCommand("SELECT * FROM Get_Free_Posts()", sqlconnection);
            adapter = new SqlDataAdapter(sqlcommmand);
            adapter.Fill(Table_Free_Posts);
            temp = new string[Table_Free_Posts.Rows.Count];
            for (int i = 0; i < Table_Free_Posts.Rows.Count; i++)
            {
                temp[i] = Table_Free_Posts.Rows[i][0].ToString() + ". " + Table_Free_Posts.Rows[i][1].ToString();
            }
            Post_ComboBox.ItemsSource = temp;
            Date_DatePicker.IsEnabled = false;

            if (Candidate_ComboBox.Items.Count == 0)
            {
                MessageBox.Show("Нет кандидатов для выбора");
                Candidate_ComboBox.IsEnabled = false;
            }
            if (Post_ComboBox.Items.Count == 0)
            {
                MessageBox.Show("Нет должностей для выбора");
                Post_ComboBox.IsEnabled = false;
            }
            Document_ComboBox.IsEnabled = false;
        }

        private void Candidate_TextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Date_DatePicker.IsEnabled = true;
            Date_DatePicker.Text = "";
            string t = Table_Free_Candidates.Rows[Candidate_ComboBox.SelectedIndex][4].ToString();
            if (Table_Free_Candidates.Rows[Candidate_ComboBox.SelectedIndex][4].ToString() == "")
            {
                Date_DatePicker.DisplayDateStart = new DateTime(2016, 01, 01);
            }
            else
            {
                Date_DatePicker.DisplayDateStart = Convert.ToDateTime(Table_Free_Candidates.Rows[Candidate_ComboBox.SelectedIndex][4]);
            }
            Date_DatePicker.SelectedDate = null;
        }

        private void Date_DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Date_DatePicker.SelectedDate == null)
            {
                Document_ComboBox.IsEnabled = false;
                return;
            }
            DataTable Table_Free_Dates = new DataTable();
            int[] date = new int[3];
            string[] t1 = Date_DatePicker.SelectedDate.ToString().Split(' ');
            for (int i = 0; i < 3; i++)
            {
                date[i] = Convert.ToInt32(t1[0].Split('.')[i]);
            }
            DateTime slctDate = new DateTime(date[2], date[1], date[0]);
            SqlCommand sqlcommand = new SqlCommand(String.Format("SELECT * FROM Get_Free_Documents('{2}{1}{0}')", slctDate.Date.ToShortDateString().Split('.')), sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);
            adapter.Fill(Table_Free_Dates);
            string[] temp = new string[Table_Free_Dates.Rows.Count];
            for (int i = 0; i < Table_Free_Dates.Rows.Count; i++)
            {
                temp[i] = Table_Free_Dates.Rows[i][0].ToString() + ". " + Table_Free_Dates.Rows[i][1].ToString() + ' ' + Table_Free_Dates.Rows[i][2].ToString();
            }
            Document_ComboBox.ItemsSource = temp;
            if (Document_ComboBox.Items.Count == 0)
            {
                MessageBox.Show("Нет документов для выбора");
                Document_ComboBox.IsEnabled = false;
            }
            else
            {
                Document_ComboBox.IsEnabled = true;
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Candidate_ComboBox.SelectedIndex == -1 || Post_ComboBox.SelectedIndex == -1 || Date_DatePicker.SelectedDate == null || Result_ComboBox.SelectedIndex == -1 || Document_ComboBox.SelectedIndex == -1)
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
            sqlcommand.CommandText = "Insert_Interview";
            sqlcommand.Parameters.AddWithValue("@id_Документ", Document_ComboBox.SelectedItem.ToString().Split(' ')[0].Replace(".", ""));
            sqlcommand.Parameters.AddWithValue("@Дата_собеседования", Date_DatePicker.SelectedDate);
            sqlcommand.Parameters.AddWithValue("@id_Кандидат", Candidate_ComboBox.SelectedItem.ToString().Split(' ')[0].Replace(".", ""));
            sqlcommand.Parameters.AddWithValue("@id_Должность", Post_ComboBox.SelectedItem.ToString().Split(' ')[0].Replace(".", ""));
            sqlcommand.Parameters.AddWithValue("@Результат", Result_ComboBox.SelectedItem.ToString().Split(':')[1].Trim());
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Additing_Interview_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {  
                 Manager_Window manager_window = new Manager_Window(sqlconnection,administrator_mode);
                 manager_window.Show();
        }
    }
}
