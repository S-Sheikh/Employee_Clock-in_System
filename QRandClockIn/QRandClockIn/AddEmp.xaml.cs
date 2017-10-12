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
            empArray = new List<Employees>();

            try
            {

                _infoBL = new NewInfoBL("DataBase");
                InitializeComponent();
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


                if (((string)Save.Content) == "Save")
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
                    rc = _infoBL.Update2(employeeDets);

                    if (rc == 0)
                    {
                        MessageBox.Show(employeeDets.EmpNumber + " updated successfully");
                    }
                    else
                    {
                        MessageBox.Show("Unable to save to database");
                    }

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

    }
}
