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

namespace Client
{
    /// <summary>
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private bool authentified = false;

        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.toLogin(this.username.Text, this.password.Password);

            if (this.authentified == true)
            {
                MainWindow main = new MainWindow();
                App.Current.MainWindow = main;
                this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Your login/password is incorrect");
            }

        }

        private void toLogin(string username, string password)
        {
            //add connection to middleware through WCF
            MessageBox.Show(username + " " + password);
            this.authentified = true;
        }
    }
}