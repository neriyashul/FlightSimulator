using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulator.Model.Interface
{
    interface IModel : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        // server
        void openServer(string ip, int port);
        void closeSever();
      
        // clients
        void connectClient(ITelnetClient c);
        void disconnectClient();
        void start();
    }
}
