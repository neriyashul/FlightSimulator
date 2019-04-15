using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class MyModel : IModel
    {
        volatile Boolean stop;
        private ITelnetServer server;
        private ITelnetClient client;


        public MyModel(ITelnetServer server, ITelnetClient client)
        {
            this.server = server;
            stop = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void closeSever()
        {
            stop = true;
            client.disconnect();
        }

        public void connectClient(ITelnetClient c)
        {
            int port = ApplicationSettingsModel.Instance.FlightCommandPort;
            client.connect("127.0.0.1", port);
        }

        public void disconnectClient()
        {
            this.client.disconnect();
        }

        public void openServer(string ip, int port)
        {
            this.server.start();
        }



        public void start()
        {   

        }
    }
}
