using FlightSimulator.Model;
using FlightSimulator.Model.EventArgs;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class JoystickViewModel : BaseNotify
    {
        float aileron;
        float elevator;
        IModel model;
        public JoystickViewModel()
        {
            model = MainWindow.model;
        }

        private void sendStringCommand(string command)
        {
            if (!model.isClientConnected())
            {
                string ip = ApplicationSettingsModel.Instance.FlightServerIP;
                int port = ApplicationSettingsModel.Instance.FlightCommandPort;
                model.connectClient(ip, port);
            }
            model.sendStringCommand(command);
        }
        public float Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                sendStringCommand("set /controls/flight/aileron " + aileron);
                NotifyPropertyChanged("Aileron");
            }
        }
        public float Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = value;
                sendStringCommand("set /controls/flight/elevator " + elevator);
                NotifyPropertyChanged("Elevator");

            }
        }


    }
}
