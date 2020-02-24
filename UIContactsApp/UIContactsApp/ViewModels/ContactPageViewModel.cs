using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using UIContactsApp.Models;
using UIContactsApp.Services;
using UIContactsApp.Views.PrincipalPage;
using Xamarin.Forms;

namespace UIContactsApp.ViewModels
{
    public class ContactPageViewModel:INotifyPropertyChanged
    {
        public ICommand AddPersonCommad { get; set; }
        public ICommand DeletePersonCommad { get; set; }
        public ICommand EditPersonCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand CallPersonCommand { get; set; }
        public ICommand ScannerCommand { get; set; }
        public ObservableCollection<Person> FavoritePersons { get; set; }
        public ObservableCollection<GroupsContact> GroupsContacts { get; set; }

        private Person selectPerson;

        public Person SelectPerson
        {
            get { return selectPerson; }
            set {
                if (selectPerson!=value)
                {
                    selectPerson = value;
                    EditSelectPerson(SelectPerson);
                }

            }
        }

        public Person Person { get; set; } = new Person();

        public ICommand FilterCommand => new Command<string>(FindPerson);
        bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
            }
        }
        public ContactPageViewModel()
        {

            ReloadList();
            LoadFavoritePerson();
            IsRefreshing = false;
            AddPersonCommad = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new RegisterContactPage(null));
            });
            EditPersonCommand = new Command<Person>(EditSelectPerson);
            RefreshCommand = new Command((param) =>
            {
                ReloadList();
                LoadFavoritePerson();
            });
            DeletePersonCommad = new Command(async (param) =>
            {
                var person = (Person)param;
                await App.PersonDB.DeleteItemAsync(person);
                ReloadList();
            });
            CallPersonCommand = new Command((param) =>
            {
                if (!string.IsNullOrEmpty(param.ToString())) {
                    CallPhone.PlacePhoneCall(param.ToString());
                }
            });
            ScannerCommand = new Command(async() =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new ScannerContactPage());
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ReloadList()
        {
            IsRefreshing = true;
            GroupsContacts = new ObservableCollection<GroupsContact>()
            {
                new GroupsContact("A",new List<Person>(await App.PersonDB.GetGroupsItems("A"))),
                new GroupsContact("B",new List<Person>(await App.PersonDB.GetGroupsItems("B"))),
                new GroupsContact("C",new List<Person>(await App.PersonDB.GetGroupsItems("C"))),
                new GroupsContact("D",new List<Person>(await App.PersonDB.GetGroupsItems("D"))),
                new GroupsContact("F",new List<Person>(await App.PersonDB.GetGroupsItems("F"))),
                new GroupsContact("G",new List<Person>(await App.PersonDB.GetGroupsItems("G"))),
                new GroupsContact("H",new List<Person>(await App.PersonDB.GetGroupsItems("H"))),
                new GroupsContact("I",new List<Person>(await App.PersonDB.GetGroupsItems("I"))),
                new GroupsContact("J",new List<Person>(await App.PersonDB.GetGroupsItems("J"))),
                new GroupsContact("K",new List<Person>(await App.PersonDB.GetGroupsItems("K"))),
                new GroupsContact("M",new List<Person>(await App.PersonDB.GetGroupsItems("M"))),
                new GroupsContact("N",new List<Person>(await App.PersonDB.GetGroupsItems("N"))),
                new GroupsContact("Ñ",new List<Person>(await App.PersonDB.GetGroupsItems("Ñ"))),
                new GroupsContact("O",new List<Person>(await App.PersonDB.GetGroupsItems("O"))),
                new GroupsContact("P",new List<Person>(await App.PersonDB.GetGroupsItems("P"))),
                new GroupsContact("Q",new List<Person>(await App.PersonDB.GetGroupsItems("Q"))),
                new GroupsContact("R",new List<Person>(await App.PersonDB.GetGroupsItems("R"))),
                new GroupsContact("S",new List<Person>(await App.PersonDB.GetGroupsItems("S"))),
                new GroupsContact("T",new List<Person>(await App.PersonDB.GetGroupsItems("T"))),
                new GroupsContact("U",new List<Person>(await App.PersonDB.GetGroupsItems("U"))),
                new GroupsContact("V",new List<Person>(await App.PersonDB.GetGroupsItems("V"))),
                new GroupsContact("W",new List<Person>(await App.PersonDB.GetGroupsItems("W"))),
                new GroupsContact("X",new List<Person>(await App.PersonDB.GetGroupsItems("X"))),
                new GroupsContact("Y",new List<Person>(await App.PersonDB.GetGroupsItems("Y"))),
                new GroupsContact("A",new List<Person>(await App.PersonDB.GetGroupsItems("Z")))
            };
            IsRefreshing = false;
        }
        public async void LoadFavoritePerson()
        {
            IsRefreshing = true;
            FavoritePersons = new ObservableCollection<Person>(await App.PersonDB.FavoritePersonAsync());
            IsRefreshing = false;
        }
        public async void FindPerson(string find)
        {
            GroupsContacts = new ObservableCollection<GroupsContact>() {
            new GroupsContact(find[0].ToString(),new List<Person>(await App.PersonDB.FindItemsAsync(find)))
            };
        }
        public async void EditSelectPerson(Person person)
        {
            await App.Current.MainPage.Navigation.PushAsync(new PresentContactPage(person));
        }
        public async void PresentPersonDate(Person person)
        {
            await App.Current.MainPage.Navigation.PushAsync(new PresentContactPage(person));
        }

    }
}
