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
    class MyTcpClient : ITelnetClient
    {
        private TcpClient client;
        private bool stop;

        public MyTcpClient() {}

        public void connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");
        }

        public void disconnect()
        {
            if (client != null)
            {
                client.Close();
            }
        }

        public void read()
        {
        }

        public void write(string command)
        {
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(command);
                // Get result from server
                int result = reader.ReadInt32();
                Console.WriteLine(result);
            }
        }
    }
}
