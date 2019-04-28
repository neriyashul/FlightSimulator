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
        private IModel model;
        public JoystickViewModel()
        {
            model = MyModel.Instance;
        }

        private void sendStringCommand(string command)
        {
            if (model.isClientConnected())
            {
                model.sendStringCommand(command);
            }
        }
        public double Aileron
        {
            get
            {
                return model.Aileron;
            }
            set
            {
                model.Aileron = value;
                sendStringCommand("set controls/flight/aileron " + model.Aileron);
                NotifyPropertyChanged("Aileron");
            }
        }
        public double Elevator
        {
            get
            {
                return model.Elevator;
            }
            set
            {
                model.Elevator = value;
                sendStringCommand("set controls/flight/elevator " + model.Elevator);
                NotifyPropertyChanged("Elevator");
            }
        }
    }
}
