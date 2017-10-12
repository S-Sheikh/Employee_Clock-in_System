using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using QRandClockIn.BL;

namespace QRandClockIn
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : UserControl
    {

        string username, password;

        public LogInPage()
        {
            InitializeComponent();

        }


        private void signIn_onClick(object sender, RoutedEventArgs e)
        {
            var HomeScreen = new HomeScreen();

            username = ClerkLoginUserNametxt.Text;
            password = ClerkLoginPasswordtxt.Password;


            if (username.Equals("") || ClerkLoginUserNametxt.Equals(null)
                       && ClerkLoginPasswordtxt.Equals("") || ClerkLoginPasswordtxt.Equals(null))
            {
                MessageBox.Show("Fields can not be left empty", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (username.Equals(password))
                {
                    MessageBox.Show("Access Approved! Welcome", "Welcome", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    HomePageWindow hpw = new HomePageWindow();
                    hpw.Show();
                   


                }

            }


        }
    }
}
