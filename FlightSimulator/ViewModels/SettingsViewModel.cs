using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class SettingsViewModel : ViewModel
    {
        private ISettingsModel model;

        public SettingsViewModel()
        {
            this.model = ApplicationSettingsModel.Instance;
        }

        public SettingsViewModel(ISettingsModel model)
        {
            this.model = model;
        }
        public string FlightServerIP
        {
            get { return model.FlightServerIP; }
            set
            {
                model.FlightServerIP = value;
                NotifyPropertyChanged("FlightServerIP");
            }
        }
        public int FlightCommandPort
        {
            get { return model.FlightCommandPort; }
            set
            {
                model.FlightCommandPort = value;
                NotifyPropertyChanged("FlightCommandPort");
            }
        }

        public int FlightInfoPort
        {
            get { return model.FlightInfoPort; }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("FlightInfoPort");
            }
        }
        public void SaveSettings()
        {
            model.SaveSettings();
        }
    }
}
