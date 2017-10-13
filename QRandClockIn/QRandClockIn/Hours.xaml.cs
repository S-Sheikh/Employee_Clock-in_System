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
using QRandClockIn.BL;
using System.IO;

namespace QRandClockIn
{
    /// <summary>
    /// Interaction logic for Hours.xaml
    /// </summary>
    public partial class Hours : UserControl
    {
         //Database business layer variables
        List<Employees> employees = null;
        DataBase dataBaseObj = null;
        private NewInfoBL _infoBL;
        //*

        string dateOnly = DateTime.Now.ToString("dd MMMM yyyy");
      
    
       
       
       
        
      //  double hoursWorked = 6; //get from database
        string currentEmployee;
        

        //benefits results
        string convertedIncome;
      
        string convertedMedicalDependents;
       
        
      
        //timespan variables
        DateTime dbIN, dbOUT;
        TimeSpan timespan;
        double convertedtxtTotalHours;
       
      

        public Hours()
        {
            InitializeComponent();
            var block = txtDate;
            block.Text = dateOnly.ToString();
         

           


            try
            {

                employees = new List<Employees>();


                dataBaseObj = new DataBase();

                employees = dataBaseObj.SelectAllEmployees();


                if (employees.Count > 0)
                {
                    foreach (Employees employee in employees)
                    {
                        lstView.Items.Add(employee.EmpNumber);


                    }
                }
                else
                {
                    MessageBox.Show("No Data");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

                DateTime x = DateTime.Now;
              
            }
            
        }

        static void SaveCompressedFile(string filename, string data)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.Write(data);
            writer.Close();

        }
        static string LoadCompressedFile(string filename)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fileStream);
            string data = reader.ReadToEnd();
            reader.Close();
            return data;
        }


        private void button2_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string filename = @"C:\\Datastores\PIO42\InfoSlips\" + txtEmployeeid.Text.ToString() + " InfoSlip.csv";

                // Console.WriteLine("Enter a string to send to csv file:");
                string sourceString = initialSurTxt.Text + ",\n" + streetTxt.Text + ",\n" + suburbTxt.Text + ",\n" + cityTxt.Text + ",\n" + postalCodeTxt.Text + ",\n" + provinceTxt.Text + ",\n\n\n\n"
                                     + "Employee No.,Employee Name,Tax Reference No.,Date,\n"
                                     + txtEmployeeid.Text.ToString() + "," + txtInitials.Text.ToString() + " " + txtSurname.Text.ToString() + "," + txtTaxNo.Text.ToString() + "," + txtDate.Text.ToString() + "," + "\n\n"
                                     + "Marital Status,Department,\n"
                                     + txtMaritalStatus.Text.ToString() + "," + txtDeptartment.Text.ToString() + "," + "\n\n"
                                     + "Identity or Passport Number,Medical Dependents,Total Hours Worked,\n"
                                     + txtIdPass.Text.ToString() + "," + txtMaritalStatus.Text.ToString() + "," + txtTotalHours.Text.ToString() + "," + "\n\n"
                                     + "Bank Name,Branch,Account Number,Account Type,\n"
                                     + txtBank.Text.ToString() + "," + txtBranch.Text.ToString() + "," + txtAccNo.Text.ToString() + "," + txtAccType.Text.ToString() + "," + "\n\n\n";
                                    



                StringBuilder sourceStringMultiplier = new StringBuilder(sourceString.Length * 1);

                for (int i = 0; i < 1; i++)
                {
                    sourceStringMultiplier.Append(sourceString);
                }
                sourceString = sourceStringMultiplier.ToString();

                SaveCompressedFile(filename, sourceString);

                FileInfo compressedString = new FileInfo(filename);

                string recoveredString = LoadCompressedFile(filename);
                recoveredString = recoveredString.Substring(0, recoveredString.Length / 100);


                if (MessageBox.Show(currentEmployee.ToString() + " InfoSlip successfully created.\nWould you like to open InfoSlip folder?", "InfoSlip Created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start(@"C:\\Datastores\PIO42\InfoSlips\");
                }
                else
                {
                  
                   
                }


            }//end try
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.Message.ToString());

                DateTime x = DateTime.Now;
             
            }//end catch

           
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }

        /////////////////////////////////////////////////////////////
        private void lstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = lstView.SelectedIndex;

            currentEmployee = employees[selected].EmpName;

            //timespan

            dbIN = employees[selected].TimeIn;
            dbOUT = employees[selected].TimeOut;

            timespan = dbOUT.Subtract(dbIN);

            //MessageBox.Show(timespan.Hours.ToString() + " hours and " + timespan.Minutes.ToString() + " mins");
            txtTotalHours.Text = timespan.Hours.ToString();

             convertedtxtTotalHours = Double.Parse(txtTotalHours.Text);



            //mail header

            initialSurTxt.Text = employees[selected].Title +" "+  employees[selected].EmpName ;
            streetTxt.Text = employees[selected].Street;
            suburbTxt.Text = employees[selected].Suburb;
            cityTxt.Text = employees[selected].City;
            postalCodeTxt.Text = employees[selected].PostalCode;
            provinceTxt.Text = employees[selected].Province;

            //fields below mail header
            txtEmployeeid.Text = employees[selected].EmpNumber;
            txtInitials.Text = employees[selected].Initials;
            txtSurname.Text = employees[selected].Surname;

            txtTaxNo.Text = employees[selected].Tax;
            txtMaritalStatus.Text = employees[selected].MaritalStatus;
            txtDeptartment.Text = employees[selected].Department;
            txtIdPass.Text = employees[selected].IdNumber;
            txtDepend.Text = employees[selected].MedicalDependents;
            txtBank.Text = employees[selected].Bank;
            txtBranch.Text = employees[selected].BankBranch;
            txtAccNo.Text = employees[selected].BankAcc;
            txtAccType.Text = employees[selected].BankAccType;
            //txtTotalHours.Text = employees[selected].TimeIn;

         
           convertedIncome = employees[selected].Salary;
           convertedMedicalDependents = employees[selected].MedicalDependents;

         
           try
           {

              
               
           }
           catch(Exception ex)
           {
               MessageBox.Show(ex.Message);
               MessageBox.Show(ex.Message.ToString());

               DateTime x = DateTime.Now;
             
           }

         //  txtGrossEarning.Text = (convertedIncomeWithHours + convertedBonus + convertedSDLResult).ToString();
           
        }

        public void Calculations()
        {
           
        }
        public void CalculateHoursSpentAtWork()
        {
            int selected = lstView.SelectedIndex;
            bool found = false;

            if (employees.Count > 0)
            {
                for (int i = 0; i < employees.Count; i++)
                {

                    if (employees[i].EmpNumber.Equals(selected))
                    {



                        MessageBox.Show("Clocked in: " + employees[i].EmpName.ToString() + "\nLogged out : " + employees[i].TimeIn.ToString());
                       
                        found = true;
                    }

                }
                if (!found)
                {
                    MessageBox.Show("No");
                }
            }
        }//hours spents
      
    }//end class
}//end namespace

