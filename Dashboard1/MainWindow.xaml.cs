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
using System.Configuration;
using Dapper;

namespace Dashboard1
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string birthPlace { get; set; }
        public string birthDate { get; set; }
        public string nik { get; set; }
        public string religion { get; set; }
        public string npwp { get; set; }
        public string graduate { get; set; }
        public string university { get; set; }
        public string email { get; set; }
        public string joinDate { get; set; }
        public string status { get; set; }
        public string departmentid { get; set; }
    }
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString);

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Insert(object sender, RoutedEventArgs e)
        {

            var check = sqlConnection.QueryAsync<UserLogin>("exec SP_Insert_Employee @id, @name, @phone, @address, @birthPlace," +
                "@birthDate, @nik, @religion, @npwp, @graduate, @university, @email, @joinDate, @status, @departmentId",
                new
                {
                    id = idEmployee.Text,
                    name = nameEmployee.Text,
                    phone = phone.Text,
                    address = address.Text,
                    birthPlace = bPlace.Text,
                    birthDate = bDate,
                    nik = nik.Text,
                    religion = religion.Text,
                    npwp = npwp.Text,
                    graduate = graduate.Text,
                    university = university.Text,
                    email = email.Text,
                    joinDate = joinDate.Text,
                    status = status.Text,
                    departmentId = departmentId.Text
                });
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            var check = sqlConnection.QueryAsync<UserLogin>("exec SP_Update_Employee @id, @name, @phone, @address, @birthPlace," +
                "@birthDate, @nik, @religion, @npwp, @graduate, @university, @email, @joinDate, @status, @departmentId",
                new
                {
                    id = idEmployee.Text,
                    name = nameEmployee.Text,
                    phone = phone.Text,
                    address = address.Text,
                    birthPlace = bPlace.Text,
                    birthDate = bDate,
                    nik = nik.Text,
                    religion = religion.Text,
                    npwp = npwp.Text,
                    graduate = graduate.Text,
                    university = university.Text,
                    email = email.Text,
                    joinDate = joinDate.Text,
                    status = status.Text,
                    departmentId = departmentId.Text
                });
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            var check = sqlConnection.QueryAsync<UserLogin>("exec SP_Delete_Employee @id",
                new { id = idEmployee.Text });
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
