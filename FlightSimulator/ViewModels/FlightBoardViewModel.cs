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
        private IModel model;
        
        public FlightBoardViewModel(IModel m)
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
            // close current server and client (if exist)
            OnDisconnectClick();

            // open new server
            model.openServer();

            // create new connection from client to server
            model.connectClient();
        }


        private ICommand _disconnectCommand;
        public ICommand DisconnectCommand
        {
            get
            {
                return _disconnectCommand ?? (_disconnectCommand =
                new CommandHandler(() => OnDisconnectClick()));
            }
        }
        private void OnDisconnectClick()
        {
            // close server
            if (model.isServerOpen())
            {
                model.closeSever();
            }
            // disconnect client
            if (model.isClientConnected())
            {
                model.disconnectClient();
            }
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
            SettingWindow setting = new SettingWindow();
            setting.Show();
        }
    }
}
