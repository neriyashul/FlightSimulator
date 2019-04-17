using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.ViewModels
{
    public class AutoControlViewModel : BaseNotify
    {
        private IModel model;
        private string strCommands;
        public AutoControlViewModel(IModel imodel)
        {
            model = imodel;
        }
        public string commands
        {
            set
            {
                strCommands = value;
                NotifyPropertyChanged("commands");
            }
            get
            {
                return strCommands;
            }
        }

        public void sendCommands()
        {
            model.sendStrCommand(commands);
        }

    }
}
