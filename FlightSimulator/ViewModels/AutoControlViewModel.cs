using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.ViewModels
{
    class AutoControlViewModel : BaseNotify
    {
        private IModel model;
        string arr;
        AutoControlViewModel(IModel imodel)
        {
            model = imodel;
        }
        public string commands
        {
            set;
            get;
        }


    }
}
