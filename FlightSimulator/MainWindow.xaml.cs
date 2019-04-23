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
        private ManualControlViewModel vm;
        public static IModel model;
        public MainWindow()
        {
            ITelnetServer s = new MyTcpServer();
            ITelnetClient c = new MyTcpClient();
            model = new MyModel(s, c);
            vm = new ManualControlViewModel(model);
            InitializeComponent();
            DataContext = vm;
        }
    }
}
