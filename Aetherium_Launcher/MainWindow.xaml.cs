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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web;
using System.IO;
//using System.IO.Compression;
using Microsoft.TeamFoundation.WorkItemTracking.ControlsCore;
using System.Reflection;
using System.Net;
using System.ComponentModel;
using Ionic.Zip;
using System.Threading;
using System.Diagnostics;


namespace Aetherium_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker worker;
        Stopwatch sw = new Stopwatch();
        public MainWindow()
        {
            InitializeComponent();
            checkIfExist();
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_Progress);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_Complete);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

        }
        public void DisableErrors(WebBrowser wb, bool Hide)
        {
            dynamic activeX = wb.GetType().InvokeMember("ActiveXInstance",
                BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, wb, new object[] { });
            activeX.Silent = true;
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void browser_Navigated(object sender, NavigationEventArgs e)
        {
            DisableErrors(browser, true);
        }
        /*
        private void progControl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                double value = Math.Floor(progControl.Value), dlValue = dlProgressBar.Width, uzValue = unzipProgressBar.Width;
                if (value <= 100 && dlValue < 669)
                {
                    dlProgressBar.Width = Math.Floor(value * 669 / 100);
                    progress.Text = value.ToString() + "% - Downloading";
                }
                if (value > 100 && uzValue <= 341)
                {
                    unzipProgressBar.Width = Math.Floor((value - 100) * 341 / 100);
                    progress.Text = value.ToString() + "% - Extracting";
                }
            }
            catch
            {

            }

        }
         * */

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        public bool checkIfExist()
        {
            if(File.Exists("Aetherium.exe") == true)
            {
                return true;
            }
            else
            {
                downloadFile();
                return false;
            }
 
        }

        public void downloadFile()
        {
            WebClient client = new WebClient();


            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

            //starts the download
            sw.Start();
            try
            {
                client.DownloadFileAsync(new Uri("http://aetherium.us/files/Aetherium_Launcher.zip"), "Aetherium.zip");    
            }
            catch
            {

            }
     
        }
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            progress.Text = "Downloading " + Math.Floor(percentage) + "% " + string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
            dlProgressBar.Width = Math.Floor(percentage * 666 / 100);
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            worker.RunWorkerAsync();
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                worker.ReportProgress(i);
            }
                using (ZipFile zip = ZipFile.Read("Aetherium.zip"))
                {
                    foreach (ZipEntry file in zip)
                    {
                        file.Extract(@"\Aetherium", ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                worker.ReportProgress(100);
        }
        void worker_Progress(object sender, ProgressChangedEventArgs e)
        {
            progress.Text = "Extracting " + e.ProgressPercentage.ToString() + "%";
            unzipProgressBar.Width = e.ProgressPercentage * 341 / 100;
        }
        void worker_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            sw.Reset();
            progress.Text = "Extracting 100% - Completed";
        }

       



    }
}
