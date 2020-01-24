using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Configuration;
using Dapper;

namespace Dashboard1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>

    public class UserLogin
    {
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }

    public partial class Login : Window
    {
        
        public Login()
        {
            InitializeComponent();

        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString);

            var check = sqlConnection.QueryAsync<UserLogin>("exec SP_Login @Username, @Password",
                new { Username = userLogin.Text, Password = passwordLogin.Password }).Result.SingleOrDefault();

            if (check != null)
            {
                //if (check.role == "admin")
                //{
                    MessageBox.Show("Login as Admin");
                //Show();
                //}
                //else
                //{
                //    MessageBox.Show("Login as User");
                //}

            }
            else
            {
                MessageBox.Show("Login is Failed");
            }
        }
    }
}
