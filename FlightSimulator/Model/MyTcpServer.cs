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
        private TcpListener listener;
        private IClientHandler ch;
        private bool isOpen = false;
        private volatile bool stop = false;
        public MyTcpServer(IClientHandler ch)
        {
            this.ch = ch;
        }
        public void Start(string ip, int port)
        {

            stop = false;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            listener = new TcpListener(ep);
            listener.Start();
            isOpen = true;
            Console.WriteLine("Waiting for connections...");
            ListenToCilents();
        }

        private void ListenToCilents()
        {
            Thread thread = new Thread(() =>
            {
                while (!stop)
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
        public void Stop()
        {
            if (listener != null)
            {
                isOpen = false;
                stop = true;
                listener.Stop();
            }
        }

        public bool IsOpen()
        {
            return listener != null && isOpen == true;
        }
    }
}
