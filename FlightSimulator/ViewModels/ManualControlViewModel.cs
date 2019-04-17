using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    public class ManualControlViewModel
    {
        private IModel model;
        private float throttle;
        private float rudder;
        public ManualControlViewModel(IModel imodel)
        {
            model = imodel;
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
                model.sendFloatCommand("throttle", throttle);
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
                model.sendFloatCommand("rudder", rudder);
            }
        }

        public static implicit operator ManualControlViewModel(AutoControlViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
