














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
using QRandClockIn.DAL;

namespace QRandClockIn
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : UserControl
    {
        private NewInfoBL _NewInfoBl;
        public List<Employers> Employers
        {
            get;
            set;
        }
        string username, password;

        public LogInPage()
        {
            InitializeComponent();

        }


        private void signIn_onClick(object sender, RoutedEventArgs e)
        {
            _NewInfoBl = new NewInfoBL("DataBase");
            Employers = _NewInfoBl.selectAllClerkInfo();
            var HomeScreen = new HomeScreen();
            username = ClerkLoginUserNametxt.Text;
            password = ClerkLoginPasswordtxt.Password;

            foreach (Employers employer in Employers)
            {
                if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))//checks whether textbox is null or empty
                {
                    if (username.Equals("ADMIN") && password.Equals("ADMIN"))//validates username and password
                    {
                        MessageBox.Show("Access Approved! Welcome", "Welcome", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        HomePageWindow hpw = new HomePageWindow();
                        hpw.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username/Password is Invalid!", "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter all fields!","Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               

            }
     
            //if (username.Equals("") || ClerkLoginUserNametxt.Equals(null)
            //           && ClerkLoginPasswordtxt.Equals("") || ClerkLoginPasswordtxt.Equals(null))
            //{
            //    MessageBox.Show("Fields can not be left empty", "Empty Fields", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else
            //{
            //    if (username.Equals(password))
            //    {
            //        MessageBox.Show("Access Approved! Welcome", "Welcome", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            //        HomePageWindow hpw = new HomePageWindow();
            //        hpw.Show();
                   


            //    }

            //}

        }
    }
}