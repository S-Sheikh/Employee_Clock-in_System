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
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using WpfPageTransitions;
using MahApps.Metro.Controls;


namespace QRandClockIn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        Stack<UserControl> pages = new Stack<UserControl>();

        public MainWindow()
        {
            InitializeComponent();
           // new SplashScreen().ShowDialog();


            cmbTransitionTypes.ItemsSource = Enum.GetNames(typeof(PageTransitionType));
        }

        private void logInBtnPage_Click(object sender, RoutedEventArgs e)
        {
            LogInPage logInPage = new LogInPage();

            pageTransitionControl.ShowPage(logInPage);


        }

        private void cmbTransitionTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pageTransitionControl.TransitionType = (PageTransitionType)Enum.Parse(typeof(PageTransitionType), cmbTransitionTypes.SelectedItem.ToString(), true);
        }

        private void clockingBtnPage_Click(object sender, RoutedEventArgs e)
        {

           ClockingSystem clockingPage = new ClockingSystem();

           pageTransitionControl.ShowPage(clockingPage);




        }

        private void closeProgram_Click(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }



    }
}
