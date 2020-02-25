using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
         List<GroupsContact> _Groups;
        public ObservableCollection<Person> FavoritePersons { get; set; }
        public ObservableCollection<GroupsContact> GroupsContacts { get; set; } = new ObservableCollection<GroupsContact>();

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
                IsRefreshing = true;
                ReloadList();
                LoadFavoritePerson();
                IsRefreshing = false;
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
            _Groups = new List<GroupsContact>();
            char[] letter = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
            foreach (var az in letter)
            {
                _Groups.Add(new GroupsContact(az.ToString(),new List<Person>(await App.PersonDB.GetGroupsItems(az.ToString()))));
            }
            ListNotEmpty();
        }
        public void ListNotEmpty()
        {

            var listNoEmpty =( from groups in _Groups where groups.Any() == true select groups).ToList();
            GroupsContacts = new ObservableCollection<GroupsContact>(listNoEmpty);
        }
        public async void LoadFavoritePerson()
        {
            IsRefreshing = true;
            FavoritePersons = new ObservableCollection<Person>(await App.PersonDB.FavoritePersonAsync());
            IsRefreshing = false;
        }
        public  void FindPerson(string find)
        {
            CultureInfo ci = new CultureInfo("es-MX");
            find = ci.TextInfo.ToTitleCase(find);
            var listNoEmpty = (from groups in GroupsContacts where groups.ToList().Exists(e=>e.NamePerson.Contains(find))select groups).ToList();
            GroupsContacts =  new ObservableCollection<GroupsContact>(listNoEmpty); ;
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
