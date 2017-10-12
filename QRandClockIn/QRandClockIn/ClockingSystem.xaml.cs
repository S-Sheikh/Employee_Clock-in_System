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
using ZXing.QrCode;
using ZXing;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace QRandClockIn
{
    /// <summary>
    /// Interaction logic for ClockingSystem.xaml
    /// </summary>
    public partial class ClockingSystem : UserControl
    {
       
        DateTime thisDayIn;
        DateTime thisDayOut;
        //  int hours;
        string serialcode;
        string scheduals;



        //////database variables///////////


        List<Employees> employees = null;
        DataBase dataBaseObj = null;
        private NewInfoBL _infoBL;
        List<Employees> employees2 = null;
        DataBase dataBaseObj2 = null;


        /////////scanner varibale//////////////

        VideoSourceController _VidController;
        VideoDeviceSelector Cameras = new VideoDeviceSelector();

        static object _textLockObject = new object();
        static object _ImageLockObject = new object();
        static string _lastAccessUrl = string.Empty;

        static string qrCodePath = @"C:\Datastores\PIO42\QRCodes\";

        DateTime dbIN, dbOUT;
        TimeSpan timespan;




        /////////scanner varibale//////////////


        public ClockingSystem()
        {

            InitializeComponent();



            try
            {

                employees = new List<Employees>();


                dataBaseObj = new DataBase();


                employees = dataBaseObj.SelectAllEmployees();



                if (employees.Count > 0)
                {
                    foreach (Employees student in employees)
                    {
                        // listBox1.Items.Add(student.EmpNumber);


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

            }



            ///////////scanner functions/////////
            try
            {
                foreach (var item in Cameras.VideoDevices)
                {
                    comboBox1.Items.Add(item.Name);
                }//end foreach

            }//end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message.ToString());

            }//end catch

            Directory.CreateDirectory(qrCodePath);





        }


        ////////////////////////////////////////////////////



        ////////////////////////scanner functionality//////////////


        private void OnStartCamera(object sender, RoutedEventArgs e)
        {
            /*
            if (comboBox1.SelectedIndex == -1)
            {
              //  MessageBox.Show(comboBox1.SelectedIndex.ToString());
                MessageBox.Show("Please select a camera before trying to start it");
                return;
            }//end if
            */


            comboBox1.SelectedIndex = 0;
            //  MessageBox.Show(comboBox1.SelectedIndex.ToString());
            string moniker = Cameras.VideoDevices.Find(o => o.Name == comboBox1.SelectedItem.ToString()).MonikerString;

            _VidController = new VideoSourceController(moniker);
            InitEvents();
            _VidController.StartVideo();


        }//end method
        private void OnGenerateCode(object sender, RoutedEventArgs e)
        {

            //string s = empName.Text;
            if (empNumInput.Text.Length == 0)
            {
                MessageBox.Show("Please enter Employee Name");
            }
            else
            {
                QRCodeWriter QRCodeWriter = new ZXing.QrCode.QRCodeWriter();
                MemoryStream ms = new MemoryStream();
                var bw = new BarcodeWriter();
                string data = String.Format(empNumInput.Text);
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

                result.Save(qrCodePath + "" + empNumInput.Text + ".jpeg", ImageFormat.Jpeg);

                result.Save(ms, ImageFormat.Jpeg);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                ms.Seek(0, SeekOrigin.Begin);
                bi.StreamSource = ms;
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.EndInit();
                frameHolder.Source = bi;


            }

        }//end method
        /*private void OnStopCamera(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("Video stream not currently running");
            else
                _VidController.CloseVideo();
        }//end method
        */
        private void InitEvents()
        {
            _VidController.FrameProcessHandler += new Action<Bitmap>(vidController_FrameProcessHandler);
            _VidController.QRCodeReaderHandler += new Action<string>(vidController_QRCodeReaderHandler);

        }//end method
        void vidController_QRCodeReaderHandler(string qrCodeText)
        {
            try
            {
                Action<string> stringAction = (param) =>
                {
                    DisplayResult(param);
                };

                textBlock1.Dispatcher.Invoke(stringAction, qrCodeText);
            }//end try
            catch (Exception)
            {
                DisplayResult(qrCodeText);
            }//end catch

        }//end method
        void vidController_FrameProcessHandler(Bitmap img)
        {
            lock (_ImageLockObject)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, ImageFormat.Bmp);
                    ms.Seek(0, SeekOrigin.Begin);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = ms;
                    bi.EndInit();
                    bi.Freeze();
                    Dispatcher.BeginInvoke(new ThreadStart(delegate
                    {
                        frameHolder.Source = bi;
                    }));
                }//end try
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                    MessageBox.Show(ex.Message.ToString());

                }//end catch
            }//end lock

        }//end method
        void DisplayResult(string results)
        {
            DataContext = results;
            empNumInput.Text = results;
            txtClockOut.Text = results;
            string code = empNumInput.Text;


            string empNum = empNumInput.Text;

            // int x = 0;
            bool found = false;

            if (employees.Count > 0)
            {

                for (int i = 0; i < employees.Count; i++)
                {

                    if (employees[i].EmpNumber.Equals(results))
                    {
                        // MessageBox.Show("found");
                        // MessageBox.Show("Welcome : " + students[i].StudentNumber.ToString());

                        thisDayIn = DateTime.Now;

                        MessageBox.Show("Welcome " + employees[i].EmpName.ToString() + "\nPlease click Clock In button", "User confirmation");
                        //  txtresult.Text = "Welcome " + employees[i].EmpName.ToString() + "\nLogged in : " + thisDayIn;

                        found = true;
                    }


                }
                if (!found)
                {
                    txtresult.Text = "Employee Not Found!!!\nPlease make sure Employee number entered \nis correct and try again";
                }
            }

        }//end method
        private Boolean IsValidUri(string uri)
        {
            try
            {
                new Uri(uri);
                return true;
            }//end try
            catch
            {
                return false;
            }//end catch
        }//end method
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                // this.Close();
            }
            else
            {
                _VidController.CloseVideo();
                //this.Close();
            }

        }



        ////////////////////////////////end scanner funtionality////////////////////

        private void ClockedIn_onClick(object sender, RoutedEventArgs e)
        {
            string code = empNumInput.Text;

            string empNum = empNumInput.Text;
            bool found = false;

            int rc;

            thisDayIn = DateTime.Now;

            Employees empDets = new Employees(thisDayIn);
            empDets.EmpNumber = code;

            try
            {

                if (((string)OKNum.Content) == "Clock In")
                {

                    rc = dataBaseObj.Update2(empDets);

                    if (rc == 0)
                    {
                        if (employees.Count > 0)
                        {

                            for (int i = 0; i < employees.Count; i++)
                            {

                                if (employees[i].EmpNumber.Equals(code))
                                {



                                    txtresult.Text = "Welcome " + employees[i].EmpName.ToString() + "\nLogged in : " + thisDayIn;
                                    empNumInput.Clear();



                                    found = true;
                                }

                            }
                            if (!found)
                            {
                                txtresult.Text = "Unkown Employee!!\nPlease make sure Employee number entered is correct or scan Employee Card";
                            }

                        }//

                    }//end db if
                    else
                    {
                        MessageBox.Show("User does not exist.\nMake sure the Employee number entered is correct.", "User Not Found", MessageBoxButton.OK, MessageBoxImage.Stop);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " in clockingng system");
                MessageBox.Show(ex.Message.ToString());

                DateTime x = DateTime.Now;
            
            }


            ///**




        }

        private void ClockedOut_onClick(object sender, RoutedEventArgs e)
        {
            string code = txtClockOut.Text;

            serialcode = code;

            string empNum = txtClockOut.Text;
            bool found = false;

            int rc;

            int zero = 0;
            thisDayOut = DateTime.Now;

            Employees empDets = new Employees(thisDayOut, zero);
            empDets.EmpNumber = code;


            try
            {

                if (((string)Logout.Content) == "Clock Out")
                {

                    rc = dataBaseObj.Update3(empDets);

                    if (rc == 0)
                    {
                        if (employees.Count > 0)
                        {

                            for (int i = 0; i < employees.Count; i++)
                            {

                                if (employees[i].EmpNumber.Equals(code))
                                {



                                    txtresult.Text = "Goodbye " + employees[i].EmpName.ToString() + "\nLogged in : " + thisDayOut;
                                    txtClockOut.Clear();

                                    found = true;

                                }

                            }
                            if (!found)
                            {
                                txtresult.Text = "Unkown Employee!!\nPlease make sure Employee number entered is correct or scan Employee Card";
                            }

                        }//

                    }//end db if
                    else
                    {
                        MessageBox.Show("User does not exist.\nMake sure the Employee number entered is correct.", "User Not Found", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " in clockingng system");
            }

            button2_Click();
        }//

        //////////////////////////file writer///////////////


        private void button2_Click()
        {
            // string dateOnly = DateTime.Now.ToString("dd.MM.yyy");
            DateTime now = DateTime.Now;
            //string filename = @"C:\\DataStores\ITCombat\EmployeeScheduales\" + dateOnly + "\\";
            string path = @"c:\Datastores\ITCombat\Employee Scheduales\" + now.Year.ToString() + "\\" + now.ToString("MMMM");
            string pathWithTxt = path + "\\" + now.ToLongDateString() + ".txt";
            bool found = false;



            try
            {
                employees2 = new List<Employees>();

                dataBaseObj2 = new DataBase();

                employees2 = dataBaseObj.SelectAllEmployees();



                if (Directory.Exists(path))
                {


                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathWithTxt, true))
                    {


                        DateTime dt = DateTime.Now;



                        if (employees.Count > 0)
                        {

                            for (int i = 0; i < employees.Count; i++)
                            {
                                if (employees[i].EmpNumber.Equals(serialcode))
                                {

                                    scheduals = employees2[i].EmpName.ToString() + "\t[" + employees2[i].EmpNumber.ToString() + "] \t\tTime In : " + employees2[i].TimeIn.ToShortTimeString() + "\t\tTime Out : " + employees2[i].TimeOut.ToShortTimeString();
                                    //scheduals = "hello";
                                    found = true;
                                }
                            }
                            if (!found)
                            {
                                MessageBox.Show("ok");
                            }

                        }
                        MessageBox.Show("k");

                        file.Write(scheduals);

                        file.WriteLine();

                    }
                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(path);

            }//end try
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString() + " In txt file write");
            }






            if (!System.IO.File.Exists(pathWithTxt))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathWithTxt))
                {
                    for (byte i = 0; i < 1; i++)
                    {
                        MessageBox.Show("Activating system... please scan again...");

                    }
                }
            }
            else
            {
                return;
            }
        }//end




    }
}
