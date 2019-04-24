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
    public class MyTcpServer : ITelnetServer
    {
        private int port;
        private string ip;
        private TcpListener listener;
        private IClientHandler ch;
        public MyTcpServer(IClientHandler ch)
        {
            this.port = ApplicationSettingsModel.Instance.FlightInfoPort;
            this.ip = ApplicationSettingsModel.Instance.FlightServerIP;
            this.ch = ch;
        }
        public void start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine("Waiting for connections...");
            listenToCilents();
        }

        private void listenToCilents()
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("Got new connection");
                        ch.HandleClient(client);
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
                Console.WriteLine("Server stopped");
            });
            thread.Start();
        }
        public void stop()
        {
            listener.Stop();
        }

    }
}
