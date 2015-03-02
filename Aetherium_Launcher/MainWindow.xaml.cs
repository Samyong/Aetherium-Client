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

        private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            ellipses.Stroke = new SolidColorBrush(Color.FromRgb(90, 90, 90));
            ellipses.Fill = new SolidColorBrush(Color.FromRgb(90, 90, 90));
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            ellipses.Stroke = new SolidColorBrush(Color.FromRgb(110, 110, 110));
            ellipses.Fill = new SolidColorBrush(Color.FromRgb(110, 110, 110));
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
