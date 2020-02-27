
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using UIContactsApp;
using UIContactsApp.Helpers;
using UIContactsApp.Views.PrincipalPage;
using Xamarin.Forms;

namespace UIContactsAppp.ViewModels
{
    public class PresentContactPageViewModel:INotifyPropertyChanged
    {
        public Person Person { get; set; } = new Person();
        public ICommand EditPersonCommand { get; set; }
        public ICommand FavoritePersonCommand { get; set; }
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

        public PresentContactPageViewModel(Person person)
        {
            Person = person;
            FavoriteImage = person.IsFavorite ? "ic_action_star.png" : "ic_action_star_border.png";
            EditPersonCommand = new Command(async()=> {
                await App.Current.MainPage.Navigation.PushAsync(new RegisterContactPage(person));
            });
            FavoritePersonCommand = new Command(async() => {
                person.IsFavorite = !person.IsFavorite;
                FavoriteImage = person.IsFavorite ? "ic_action_star.png" : "ic_action_star_border.pngr";
                await App.PersonDB.SaveItemAsync(person);

            });

        }
    }
}
