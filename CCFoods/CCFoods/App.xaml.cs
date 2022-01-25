using Modulo1.Paginas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CCFoods
{
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTcxMzQ0QDMxMzkyZTM0MmUzMGtHQzRrYzhSck1DOXJ5eE9SaVJtK1Y1bGRxV3kyb2dOZEJpd2hPWFB3ZjA9");

            InitializeComponent();

            MainPage = new NavigationPage(new MenuPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
