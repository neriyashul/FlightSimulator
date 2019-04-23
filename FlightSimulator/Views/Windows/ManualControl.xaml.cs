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
    /// Interaction logic for manual.xaml
    /// </summary>
    public partial class ManualControl : UserControl
    {
        private ManualControlViewModel vm;
        public ManualControl()
        {
            InitializeComponent();

            ITelnetServer a = new MyTcpServer();
            ITelnetClient c = new MyTcpClient();
            vm = new ManualControlViewModel(new MyModel(a, c));
            DataContext = vm;
        }

    }
}
