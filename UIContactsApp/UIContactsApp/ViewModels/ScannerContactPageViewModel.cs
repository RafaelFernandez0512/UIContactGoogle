using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using UIContactsApp.AppServices;
using UIContactsApp.Helpers;
using UIContactsApp.Views.PrincipalPage;
using Xamarin.Forms;
using ZXing;

namespace UIContactsApp.ViewModels
{
    public class ScannerContactPageViewModel:BaseViewModel,INotifyPropertyChanged
    {
        public Result Result { get; set; }
        public DelegateCommand ScannerCommand { get; set; }
        public bool IsScanning { get; set; }
        public Person Person { get; set; } = new Person();
        public ScannerContactPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IPersonDB personDB,IDeviceService deviceService) : base(navigationService, dialogService, personDB)
        {
            IsScanning = true;
            ScannerCommand = new DelegateCommand( () =>
            {
                var param = new NavigationParameters
                {
                    { Person.GetType().Name, Person }
                };
                deviceService.BeginInvokeOnMainThread(async () =>
                {
                    Person.NamePerson = Result.Text.IsSeparatorString()[0];
                    Person.Lastname = Result.Text.IsSeparatorString()[1];
                    Person.Phone = Result.Text.IsSeparatorString()[2];
                    IsScanning = false;
                    await navigationService.NavigateAsync(ConstPage.RegisterContactPage, param);

                });
    
               
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
