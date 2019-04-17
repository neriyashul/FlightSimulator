using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
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
        private AutoControlViewModel vm;

        public AutoControl()
        {
            InitializeComponent();
            textBox.Background = TextBoxColor;

            ITelnetServer a = new MyTcpServer();
            ITelnetClient c = new MyTcpClient();
            vm = new AutoControlViewModel(new MyModel(a, c));
            DataContext = vm;

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
            vm.sendCommands();
            textBox.Background = TextBoxColor;
            textBox.Text = String.Empty;
        }
    }
}

