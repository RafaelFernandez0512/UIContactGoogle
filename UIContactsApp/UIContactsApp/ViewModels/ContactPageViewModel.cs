using Prism.Commands;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UIContactsApp.AppServices;
using UIContactsApp.Helpers;
using UIContactsApp.Services;
using UIContactsApp.Views.PrincipalPage;
using Xamarin.Forms;

namespace UIContactsApp.ViewModels
{
    public class ContactPageViewModel: BaseViewModel,INotifyPropertyChanged
    {
        public DelegateCommand AddPersonCommad { get; set; }
        public DelegateCommand<Person> DeletePersonCommad { get; set; }
        public DelegateCommand<Person> EditPersonCommand { get; set; }
        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand<int> CallPersonCommand { get; set; }
        public DelegateCommand ScannerCommand { get; set; }
        List<GroupsContact> _Groups;
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


        public DelegateCommand<string> FilterCommand => new DelegateCommand<string>(FindPerson);
        bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
            }
        }
        public ContactPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IPersonDB personDB )  : base(navigationService,dialogService, personDB)
        {
            ReloadList();
            LoadFavoritePerson();
            AddPersonCommad = new DelegateCommand(async () =>
            {
               await navigationService.NavigateAsync(ConstPage.RegisterContactPage);
                ReloadList();
            });
            EditPersonCommand = new DelegateCommand<Person>(async(param)=> {
                await EditSelectPerson(param);
            });
            RefreshCommand = new DelegateCommand(() =>
            {
                IsRefreshing = true;
                ReloadList();
                LoadFavoritePerson();
                IsRefreshing = false;

            });
            DeletePersonCommad = new DelegateCommand<Person>(async (param) =>
            {
                var person = (Person)param;
                await personDB.DeleteItemAsync(person);
                ReloadList();
            });
            ScannerCommand = new DelegateCommand(async() =>
            {
                await navigationService.NavigateAsync(ConstPage.ScannerContactPage);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        async  void ReloadList()
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
           
            FavoritePersons = new ObservableCollection<Person>(await App.PersonDB.FavoritePersonAsync());
            
        }
        public  void FindPerson(string find)
        {
            CultureInfo ci = new CultureInfo("es-MX");
            find = ci.TextInfo.ToTitleCase(find);
            var listNoEmpty = (from groups in GroupsContacts where groups.ToList().Exists(e=>e.NamePerson.Contains(find))select groups).ToList();
            GroupsContacts =  new ObservableCollection<GroupsContact>(listNoEmpty); ;
        }
        public async Task EditSelectPerson(Person person)
        {
            var param = new Prism.Navigation.NavigationParameters
            {
                { Person.GetType().Name, person }
                
            };
            await navigationService.NavigateAsync(ConstPage.PresentContactPage,param);
        }

    }
}
