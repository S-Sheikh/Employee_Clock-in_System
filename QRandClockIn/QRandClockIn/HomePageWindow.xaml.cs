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
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using MahApps.Metro.Controls;

namespace QRandClockIn
{
    /// <summary>
    /// Interaction logic for HomePageWindow.xaml
    /// </summary>
    public partial class HomePageWindow : MetroWindow
    {
        //string searchOneWord;
        public HomePageWindow()
        {          
            InitializeComponent();        
        }
    
       private void infoSlips_btn(object sender, RoutedEventArgs e)
       {
           Hours hours = new Hours();

           frame1.ShowPage(hours);
       }

       private void QR_btn(object sender, RoutedEventArgs e)
       {
           AddEmp addemp = new AddEmp();

           frame1.ShowPage(addemp);
       }   
    }
}
