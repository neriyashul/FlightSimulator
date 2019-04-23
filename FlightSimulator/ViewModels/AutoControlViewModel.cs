using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using FlightSimulator.Model;
using FlightSimulator.Model.Interface;


namespace FlightSimulator.ViewModels
{
    public class AutoControlViewModel : BaseNotify
    {
        
        private IModel model;
        private string strCommands = "";
        private ICommand _OKCommand;
        private ICommand _ClearCommand;
        private string ip = ApplicationSettingsModel.Instance.FlightServerIP;
        private int port = ApplicationSettingsModel.Instance.FlightCommandPort;
        

        private const string defaultColor = "White";
        private const string writingColor = "LightCoral";
        private string backgroundColor = defaultColor;
        public AutoControlViewModel(ref IModel imodel) {
            model = imodel;
        }
        public string Commands{
            set {
                if ((object)this.backgroundColor == (object)defaultColor && value != string.Empty) {
                    BackgroundColor = writingColor;
                }
                strCommands = value;
                NotifyPropertyChanged("Commands");
            }
            get {
                return strCommands;
            }
        }

        public void SendCommands() {
            if (!model.isClientConnected())
            {
                model.connectClient(ip, port);
            }
            model.sendStrCommand(strCommands);
        }

        public string BackgroundColor {
            get {
                return backgroundColor;
            }
            set {
                backgroundColor = value;
                NotifyPropertyChanged("BackgroundColor");
            }
        }


        public ICommand OkCommand {
            get {
                return _OKCommand ?? (_OKCommand =
                new CommandHandler(() => OkClick()));
            }
        }
        private void OkClick() {
            SendCommands();
            Commands = String.Empty;
            BackgroundColor = defaultColor;
        }

        public ICommand ClearCommand {
            get {
                return _ClearCommand ?? (_ClearCommand =
                new CommandHandler(() => ClearClick()));
            }
        }

        private void ClearClick() {
            Commands = String.Empty;
            BackgroundColor = defaultColor;
        }

    }
}
