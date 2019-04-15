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
using System.Windows.Shapes;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SolidColorBrush TextBoxColor = Brushes.White;
        public MainWindow()
        {
            InitializeComponent();
            textBox.Background = TextBoxColor;
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            textBox.Background = Brushes.LightCoral;
            if (e.Key == Key.Enter)
            {
                textBox.Text += Environment.NewLine;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textBox.Background = TextBoxColor;
            textBox.Text = "";
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
