using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ReadArgumentsClientHandler : BaseNotify, IClientHandler
    {
        private volatile bool stop;
        private double latitude;
        private double longitude;
        public bool Stop
        {
            get
            {
                return stop;
            }
            set
            {
                stop = value;
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

        private void updateValues(string[] values)
        {
            Longitude = Convert.ToDouble(values[0]);
            Latitude = Convert.ToDouble(values[1]);
        }

        /**
         * the function read from parametrs from client and update properties values.
         */ 
        public void HandleClient(TcpClient client)
        {
            BinaryReader reader = new BinaryReader(client.GetStream());
            while (!stop)
            {
                string str = reader.ReadString();

                string[] vals = str.Split(
                            new[] { ',' },
                                StringSplitOptions.None);
                updateValues(vals);
                Thread.Sleep(200);
            }
        }
    }
}
