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
            get {
                if (personDB == null)
                {
                    personDB =new PersonDB();
                }
                return personDB;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ContactPage());
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
