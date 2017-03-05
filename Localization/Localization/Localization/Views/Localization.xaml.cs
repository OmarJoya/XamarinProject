namespace Localization
{
    using System;
    using Localization.ViewModels;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        private LocalizationViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            vm= new LocalizationViewModel(this);
            BindingContext = vm;
        }
    }
}
