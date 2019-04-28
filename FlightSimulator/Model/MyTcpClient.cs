using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class MyTcpClient : ITelnetClient
    {
        private TcpClient client;

        public MyTcpClient() {}

        public void connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new TcpClient();
            Thread thread = new Thread(() =>
            {
                bool stop = false;
                while (!stop)
                {
                    try
                    {
                        client.Connect(ep);
                        stop = true;
                    }
                    catch (Exception e) { }
                }
            });
            thread.Start();
            Console.WriteLine("You are connected");
        }

        public void disconnect()
        {
            if (client != null)
            {
                client.Close();
            }
        }

        public bool isConnected()
        {
            return client != null && client.Connected;
        }

        public void read()
        {
            throw new NotImplementedException();
        }

        public void write(string command)
        {
            // add '/r/n'
            command += Environment.NewLine;
            // Send data to server
            BinaryWriter b = new BinaryWriter(client.GetStream());
            b.Write(command);
            b.Flush();
        }
    }
}
