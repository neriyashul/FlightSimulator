using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class MyTcpServer : ITelnetServer
    {
        public void start()
        {
            Console.WriteLine("start");
        }

        public void stop()
        {
            Console.WriteLine("stop"); ;
        }
    }
}
