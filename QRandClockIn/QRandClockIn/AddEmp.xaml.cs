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
using ZXing.QrCode;
using System.IO;
using ZXing;
using System.Drawing.Imaging;
using System.Drawing;

namespace QRandClockIn
{
    /// <summary>
    /// Interaction logic for AddEmp.xaml
    /// </summary>
    public partial class AddEmp : UserControl
    {      
        private NewInfoBL _infoBL;
        List<Employees> empArray;
        static string qrCodePath = @"C:\Datastores\PIO42\QRCodes\";     

        public AddEmp()
        {
            try
            {
                _infoBL = new NewInfoBL("DataBase");
                InitializeComponent();
                empArray = new List<Employees>();
                txtCell.MaxLength = 11;//sets the max length of numbers to 11
                txtID.MaxLength = 13; //sets the max lenght of ID numbers to be 13 digits
                txtEmpNo.MaxLength = 8;//sets the max length of employee number to 8 digits
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Employee", ex.Message);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            int rc;
            DateTime dt = DateTime.Today;
            Employees employeeDets = new Employees(txtInitialAndSur.Text, txtEmpNo.Text, txtSurname.Text, txtStreet.Text, txtSuburb.Text, txtCity.Text, txtCode.Text, txtProvince.Text, txtInitials.Text, txtTaxNo.Text, maritalStatusTxt.Text, txtDepartment.Text, txtID.Text, txtDependent.Text, txtBank.Text, txtBranch.Text, txtAccountNo.Text, txtAccountType.Text, txtTitle.Text, txtCell.Text, txtMedicalAid.Text, txtMedicalAidNo.Text, incometxt.Text, dt, dt);
            try
            {

                if (!string.IsNullOrEmpty(txtInitialAndSur.Text) && !string.IsNullOrEmpty(txtInitials.Text) && !string.IsNullOrEmpty(txtID.Text) &&
                        !string.IsNullOrEmpty(txtCell.Text) && !string.IsNullOrEmpty(txtEmpNo.Text) && !string.IsNullOrEmpty(txtMedicalAid.Text) &&
                        !string.IsNullOrEmpty(txtSurname.Text) && !string.IsNullOrEmpty(txtDepartment.Text) && !string.IsNullOrEmpty(txtMedicalAidNo.Text) &&
                        !string.IsNullOrEmpty(txtStreet.Text) && !string.IsNullOrEmpty(txtSuburb.Text) && !string.IsNullOrEmpty(txtCity.Text) && !string.IsNullOrEmpty(txtCode.Text) &&
                        !string.IsNullOrEmpty(txtProvince.Text) && !string.IsNullOrEmpty(txtBank.Text) && !string.IsNullOrEmpty(txtAccountType.Text) && !string.IsNullOrEmpty(txtAccountNo.Text) &&
                        !string.IsNullOrEmpty(txtBranch.Text) && !string.IsNullOrEmpty(txtTaxNo.Text) && !string.IsNullOrEmpty(incometxt.Text))
                {
                    rc = _infoBL.Insert2(employeeDets);

                    if (rc == 0)
                    {
                        MessageBox.Show(employeeDets.EmpName + " saved successfully");
                        OnGenerateCode();
                    }
                    else
                    {
                        MessageBox.Show("Unable to save to database ");
                    }

                }
                else
                {
                    MessageBox.Show("Error", "Please fill in all fields! ", MessageBoxButton.OK, MessageBoxImage.Error);//Displays when one or more fields have not been inputed data!!!!!
                }



            }//end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " here inside Add emp screen");
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void OnGenerateCode()
        {

            //string s = empName.Text;
            if (txtEmpNo.Text.Length == 0)
            {
                MessageBox.Show("Please enter Employee Name");
            }
            else
            {
                QRCodeWriter QRCodeWriter = new ZXing.QrCode.QRCodeWriter();
                MemoryStream ms = new MemoryStream();
                var bw = new BarcodeWriter();
                string data = String.Format(txtEmpNo.Text);
                var encOptions = new ZXing.Common.EncodingOptions()
                {
                    Width = 204,
                    Height = 204,
                    Margin = 0,
                };
                bw.Options = encOptions;
                bw.Format = BarcodeFormat.QR_CODE;

                var result = new Bitmap(bw.Write(QRCodeWriter.encode(data, bw.Format, encOptions.Width,
                        encOptions.Height)));

                result.Save(qrCodePath + "" + txtEmpNo.Text + ".jpeg", ImageFormat.Jpeg);

                result.Save(ms, ImageFormat.Jpeg);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                ms.Seek(0, SeekOrigin.Begin);
                bi.StreamSource = ms;
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.EndInit();
                // frameHolder.Source = bi;


            }

        }//end method

        private void txtAccountType_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}










