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

namespace FlightSimulator.Views.Windows
{
    /// <summary>
    /// Interaction logic for AutoControl.xaml
    /// </summary>
    public partial class AutoControl : UserControl
    {
        private SolidColorBrush TextBoxColor = Brushes.White;
        //private ViewModels vm;

        public AutoControl()
        {
            InitializeComponent();
            textBox.Background = TextBoxColor;
            // vm = new ViewModel(new MyModel(new TCP));
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            textBox.Background = Brushes.LightCoral;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textBox.Background = TextBoxColor;
            textBox.Text = String.Empty;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            //vm.write(textBox.Text);
            textBox.Background = TextBoxColor;
            //textBox.Text = String.Empty;
        }
    }
}

