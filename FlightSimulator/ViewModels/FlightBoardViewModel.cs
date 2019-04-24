using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Views.Windows;
using System.Windows;

namespace FlightSimulator.ViewModels
{

    public class FlightBoardViewModel : BaseNotify
    {

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




        //property connect
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand =
                new CommandHandler(() => OnConnectClick()));
            }
        }
        private void OnConnectClick()
        {
            MessageBox.Show("Hello, world!", "My App");
            //m_flightManager.Connect();
            //IsDisconnected = false; // Setting that the server is
            //connected
        }




        //property setting
        private ICommand _settingCommand;
        public ICommand SettingCommand
        {
            get
            {
                return _settingCommand ?? (_settingCommand =
                new CommandHandler(() => OnSettingClick()));
            }
        }
        private void OnSettingClick()
        {
            setting.Show();
            //m_flightManager.Connect();
            //IsDisconnected = false; // Setting that the server is
            //connected
        }
    }
}
