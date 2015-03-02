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

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            if(sender == CloseButton)
            {
                CloseButton.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(237, 228, 50));
            }
            else if(sender == MinimizeButton)
            {
                MinimizeButton.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(237, 228, 50));
            }
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender == CloseButton)
            {
                CloseButton.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(193, 184, 0));
            }
            else if (sender == MinimizeButton)
            {
                MinimizeButton.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(193, 184, 0));
            }
        }

    }
}
