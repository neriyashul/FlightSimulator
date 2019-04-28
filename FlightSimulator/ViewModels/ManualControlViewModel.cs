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
        

        public ManualControlViewModel(IModel imodel)
        {
            model = imodel;
        }

        private void sendStringCommand(string command)
        {
            if (model.isClientConnected())
            {
                model.sendStringCommand(command);
            }
        }
        public double Throttle
        {
            get
            {
                return model.Throttle;
            }

            set
            {
                model.Throttle = value;
                sendStringCommand("set controls/engines/engine/throttle " + model.Throttle);
                NotifyPropertyChanged("Throttle");
            }
        }
        public double Rudder
        {
            get
            {
                return model.Rudder;
            }

            set
            {
                model.Rudder = value;
                sendStringCommand("set controls/flight/rudder "+ model.Rudder);
                NotifyPropertyChanged("Rudder");
            }
        }
    }
}
