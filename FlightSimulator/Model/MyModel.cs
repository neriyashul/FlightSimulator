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
    public class MyModel : IModel
    {
        volatile Boolean stop;
        ITelnetServer server;
        ITelnetClient client;


        public MyModel(ITelnetServer s, ITelnetClient c)
        {
            server = s;
            client = c;
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



        public void sendStrCommand(string commands)
        {
            string[] commandsByline = commands.Split(
                            new[] { Environment.NewLine },
                                StringSplitOptions.None);

            new Thread(delegate () {
                foreach (string command in commandsByline)
                {
                    client.write(command);
                    Thread.Sleep(2000);
                }
            }).Start();
        }

        public void sendFloatCommand(string strCommand, float command)
        {
            throw new NotImplementedException();
        }
    }
}
