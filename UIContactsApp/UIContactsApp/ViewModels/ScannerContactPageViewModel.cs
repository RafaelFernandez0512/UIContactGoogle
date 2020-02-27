using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using UIContactsApp.Helpers;
using UIContactsApp.Views.PrincipalPage;
using Xamarin.Forms;
using ZXing;

namespace UIContactsApp.ViewModels
{
    public class ScannerContactPageViewModel:INotifyPropertyChanged
    {
        public Result Result { get; set; }
        public ICommand ScannerCommand { get; set; }
        public bool IsScanning { get; set; }
        public Person Person { get; set; } = new Person();
        public ScannerContactPageViewModel()
        {
            IsScanning = true;
            ScannerCommand = new Command( () =>
            {

                Device.BeginInvokeOnMainThread(async () =>
                {
                    Person.NamePerson = Result.Text.IsSeparatorString()[0];
                    Person.Lastname = Result.Text.IsSeparatorString()[1];
                    Person.Phone = Result.Text.IsSeparatorString()[2];
                    IsScanning = false;
                    await App.Current.MainPage.Navigation.PushAsync(new RegisterContactPage(Person));

                });
    
               
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
