using Xamarin.Forms;

namespace Localization.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;


    public class LocalizationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public readonly ContentPage View;
        public Command BtnConnect { get; set; }
        public LocalizationViewModel(ContentPage view)
        {
            this.View = view;
            Connected = false;
            BtnConnect = new Command(Connect);
        }
        private bool connected;
        public bool Connected
        {
            get { return connected; }
            set
            {
                connected = value;
                OnPropertyChanged();
            }
        }

        void Connect()
        {
            Connected = !Connected;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
