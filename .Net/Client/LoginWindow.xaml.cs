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
using Client.ServiceReference1;

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
                MessageBox.Show("Votre pseudo/mot de passe est incorrect !");
            }

        }

        private void toLogin(string username, string password)
        {

            //Ci-dessous le code pour envoyer login mdp au middleware, à utiliser quand ce sera implémenté là bas
            /*
            STG response = Sender.Instance.sendLoginInformation(new object[] { username, password, AppToken.token });

            if (response.ToString() == "OK")
            {
                this.authentified = true;
            } else
            {
                this.authentified = false;
            }
            */

            //En attendant :
            this.authentified = true;
        }
    }
}