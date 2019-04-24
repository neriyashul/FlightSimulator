using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private IModel model;

        FlightBoardViewModel(IModel m)
        {
            model = m;
            model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged(e.PropertyName);
                };

        }
        public double Longitude
        {
            get
            {
                return model.Longitude;
            }
            set
            {
                model.Longitude = value;
                NotifyPropertyChanged("Longitude");
            }              
        }

        public double Latitude
        {
            get
            {
                return model.Latitude;
            }
            set
            {
                model.Latitude = value;
                NotifyPropertyChanged("Latitude");
            }
        }
    }
}
