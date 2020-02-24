using ContactUIAndroid.App.Services;
using System;
using System.IO;
using UIContactsApp.AppServices;
using UIContactsApp.Views.MasterDetailPages;
using UIContactsApp.Views.PrincipalPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIContactsApp
{
    public partial class App : Application
    {
        private static PersonDB personDB;
        public static PersonDB PersonDB
        {
            get => personDB == null ? new PersonDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Person.db3")) : personDB;

            set => personDB = value;
        }
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[]
{
                "SwipeView_Experimental",
                "CarouselView_Experimental",
                "IndicatorView_Experimental"
            });
            MainPage = new NavigationPage(new ContactMasterDetailPage());
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
