using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

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

        public void ReloadSettings()
        {
            model.ReloadSettings();
        }

        public Action CloseAction { get; set; }

        #region Commands
        #region ClickCommand
        private System.Windows.Input.ICommand _clickCommand;
        public ICommand ClickOkCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            model.SaveSettings();
            CloseAction?.Invoke();
        }
        #endregion

        #region CancelCommand
        private System.Windows.Input.ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => OnCancel()));
            }
        }
        private void OnCancel()
        {
            model.ReloadSettings();
            CloseAction?.Invoke();
        }
        #endregion
        #endregion
    }
}

