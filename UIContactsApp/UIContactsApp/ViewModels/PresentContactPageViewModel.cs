
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using UIContactsApp;
using UIContactsApp.AppServices;
using UIContactsApp.Helpers;
using UIContactsApp.ViewModels;
using UIContactsApp.Views.PrincipalPage;
using Xamarin.Forms;

namespace UIContactsAppp.ViewModels
{
    public class PresentContactPageViewModel:BaseViewModel,INotifyPropertyChanged,IInitialize
    {
        public Person Person { get; set; } = new Person();
        public DelegateCommand EditPersonCommand { get; set; }
        public DelegateCommand FavoritePersonCommand { get; set; }
        public string FavoriteImage { get; set; }

        private string fullName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FullName
        {
            get {
                if (Person.NickName.IsEmptyString())
                    return fullName;
                else
                    return $"{Person.NamePerson} {Person.Lastname}";
            }
            set { fullName = value; }
        }

        public PresentContactPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IPersonDB personDB) : base(navigationService, dialogService, personDB)
        {
            FavoriteImage = Person.IsFavorite ? "ic_action_star.png" : "ic_action_star_border.png";
            EditPersonCommand = new DelegateCommand(async()=> {
                var param = new NavigationParameters
                {
                    { Person.GetType().Name, Person }
                };
                await navigationService.NavigateAsync(ConstPage.RegisterContactPage,param);
            });
            FavoritePersonCommand = new DelegateCommand(async() => {
                Person.IsFavorite = !Person.IsFavorite;
                FavoriteImage = Person.IsFavorite ? "ic_action_star.png" : "ic_action_star_border.pngr";
                await personDB.SaveItemAsync(Person);

            });

        }

        public void Initialize(INavigationParameters parameters)
        {
            Person =(Person)parameters[Person.GetType().Name];
        }
    }
}
