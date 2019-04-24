using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{

    public class MyModel : BaseNotify, IModel
    {
        private volatile bool stop;
        private ITelnetServer server;
        private ITelnetClient client;
        private double aileron;
        private double elevator;
        private double throttle;
        private double rudder;
        private double latitude;
        private double longitude;
     



        public MyModel(ITelnetServer s, ITelnetClient c)
        {
            server = s;
            client = c;
            stop = false;
        }

        public void closeSever()
        {
            stop = true;
            if (server.IsOpen())
            {
                server.Stop();
            }
        }



        public void connectClient()
        {
            string ip = ApplicationSettingsModel.Instance.FlightServerIP;
            int port = ApplicationSettingsModel.Instance.FlightCommandPort;
            client.connect(ip, port);
        }

        public void disconnectClient()
        {
            if (isClientConnected())
            {
                client.disconnect();
            }
        }

        public bool isClientConnected()
        {
            return client != null && client.isConnected();
        }

        public bool isServerOpen()
        {
            return server != null && server.IsOpen();
        }

        public void openServer()
        {
            string ip = ApplicationSettingsModel.Instance.FlightServerIP;
            int port = ApplicationSettingsModel.Instance.FlightInfoPort;
            server.Start(ip, port);
        }

        public void sendStringCommand(string command)
        {
            client.write(command);
        }


        public void sendStringCommandsWithSleep(string commands, int sleepTime)
        {
            Task t = new Task(() =>
            {
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


        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                NotifyPropertyChanged("Aileron");
            }
        }
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = value;
                NotifyPropertyChanged("Elevator");
            }
        }

        public double Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }

        public double Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;
                NotifyPropertyChanged("Rudder");
            }
        }
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
                NotifyPropertyChanged("Latitude");
            }
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
                NotifyPropertyChanged("Longitude");
            }
        }
         
    }
}
