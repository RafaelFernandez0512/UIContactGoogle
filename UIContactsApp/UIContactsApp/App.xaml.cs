using ContactUIAndroid.App.Services;
using Prism.Unity;
using System;
using System.IO;
using UIContactsApp.AppServices;
using UIContactsApp.Views.MasterDetailPages;
using UIContactsApp.Views.PrincipalPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Ioc;
using Prism;
using Prism.Navigation;
using UIContactsApp.ViewModels;
using UIContactsApp.Helpers;
using UIContactsAppp.ViewModels;

namespace UIContactsApp
{
    public partial class App : PrismApplication
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
        public App(IPlatformInitializer initializer =null):base(initializer)
        {

        }
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new Uri($"{ConstPage.ContactMasterDetailPage}{ConstPage.NavigationPage}{ConstPage.ContactPage}",UriKind.Absolute));
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ContactMasterDetailPage,ContactPageMasterViewModel>();
            containerRegistry.RegisterForNavigation<ContactPage, ContactPageViewModel>();
            containerRegistry.RegisterForNavigation<PresentContactPage,PresentContactPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterContactPage, RegisterContactPageViewModel>();
            containerRegistry.RegisterForNavigation<ScannerContactPage,ScannerContactPageViewModel>();
            containerRegistry.RegisterInstance<IPersonDB>(PersonDB);
        }

    }
}
