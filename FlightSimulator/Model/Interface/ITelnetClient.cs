using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    public interface ITelnetClient
    {
        void connect(string ip, int port);
        void write(string command);
        void read();
        void disconnect();

        bool isConnected();
    }
}
