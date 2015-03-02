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
using Microsoft.TeamFoundation.WorkItemTracking.ControlsCore;
using System.Reflection;



namespace Aetherium_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

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

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        //settings rotate animation

    }
}
