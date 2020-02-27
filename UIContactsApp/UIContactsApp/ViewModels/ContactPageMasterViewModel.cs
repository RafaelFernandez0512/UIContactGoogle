using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UIContactsApp.Helpers;
using UIContactsApp.Views.MasterDetailPages;
using UIContactsApp.Views.PrincipalPage;
using Xamarin.Forms;

namespace UIContactsApp.ViewModels
{
    public class ContactPageMasterViewModel
    {
        public ObservableCollection<MenuMasterItem> MenuItems { get; set; }
        public ContactPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<MenuMasterItem>() {
            new MenuMasterItem(){
            Id =1,
            Title = "Contacts",
            TargetType = typeof(ContactPage)
            }
            };
        }
    }
}
