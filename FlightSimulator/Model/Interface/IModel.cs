using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulator.Model.Interface
{
    public interface IModel : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        // server
        void openServer(string ip, int port);
        void closeSever();
      
        // clients
        void connectClient(string ip, int port);

        bool isClientConnected();
        void disconnectClient();
        void sendStringCommandsWithSleep(string command, int sleepTime);
        void sendStringCommand(string command);
    }
}
