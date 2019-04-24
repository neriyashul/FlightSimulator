using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
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
        private SettingWindow setting = new SettingWindow();
        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
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
