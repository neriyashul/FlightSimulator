using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainWindow : Window {
        private AutoControlViewModel vm;
        public MainWindow()
        {
            InitializeComponent();

            ITelnetServer a = new MyTcpServer();
            ITelnetClient c = new MyTcpClient();
            vm = new AutoControlViewModel(new MyModel(a, c));
            DataContext = vm;
        }
    }
}
