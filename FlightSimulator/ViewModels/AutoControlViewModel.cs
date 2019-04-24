using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private System.Windows.Input.ICommand _OKCommand;
        private System.Windows.Input.ICommand _ClearCommand;


        private const string defaultColor = "White";
        private const string writingColor = "LightCoral";
        private string backgroundColor = defaultColor;
        public AutoControlViewModel(IModel imodel) {
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
            model.sendStrCommand(Commands);
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
            Commands = String.Empty;
            BackgroundColor = defaultColor;
            //SendCommands();
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
