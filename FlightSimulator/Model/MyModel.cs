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

        public void connectClient(string ip, int port) {
            client.connect(ip, port);
        }

        public void disconnectClient()
        {
            this.client.disconnect();
        }

        public bool isClientConnected()
        {
            return client != null && client.isConnected();
        }

        public void openServer(string ip, int port)
        {
            this.server.start();
        }

        public void sendStringCommand(string command)
        {
            client.write(command);
        }


        public void sendStringCommandsWithSleep(string commands, int sleepTime)
        {
            Task t = new Task(() => {
                string[] commandsByline = commands.Split(
                            new[] { Environment.NewLine },
                                StringSplitOptions.None);

                foreach (string command in commandsByline)
                {
                    client.write(command);
                    Thread.Sleep(sleepTime);
                }   
           });
            t.Start();

            Console.Write("hj");
        }

    }
}
