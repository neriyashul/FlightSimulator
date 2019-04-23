using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    public class ManualControlViewModel : BaseNotify
    {
        private IModel model;
        private float throttle;
        private float rudder;
        private string ip = ApplicationSettingsModel.Instance.FlightServerIP;
        private int port = ApplicationSettingsModel.Instance.FlightCommandPort;

        public ManualControlViewModel(IModel imodel)
        {
            model = imodel;
        }

        private void sendStringCommand(string command)
        {
            if (!model.isClientConnected())
            {
                model.connectClient(ip, port);
            }
            model.sendStringCommand(command);
        }
        public float Throttle
        {
            get
            {
                return throttle;
            }

            set
            {
                throttle = value;
                sendStringCommand("set /controls/engines/engine/throttle " + throttle);
                NotifyPropertyChanged("Throttle");
            }
        }
        public float Rudder
        {
            get
            {
                return rudder;
            }

            set
            {
                rudder = value;
                sendStringCommand("set /controls/flight/rudder "+ rudder);
                NotifyPropertyChanged("Rudder");

            }
        }
    }
}
