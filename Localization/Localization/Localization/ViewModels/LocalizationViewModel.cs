namespace Localization.ViewModels
{
	using System.Diagnostics;
	using Plugin.Geolocator;
	using Xamarin.Forms;
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
            TxtButton= "Conectar";
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

        private string txtButton;

        public string TxtButton
        {
            get { return txtButton; }
            set
            {
                txtButton = value;
                OnPropertyChanged();
            }
        }

        private double latitude;
        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                OnPropertyChanged();
            }
        }

        private double longitude;
        public double Longitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                OnPropertyChanged();
            }
        }

        async void Connect()
        {
            Connected = !Connected;
            TxtButton = (Connected)? "Desconectar":"Conectar";

            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

                Latitude = position.Latitude;
                Longitude = position.Longitude;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);

            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
