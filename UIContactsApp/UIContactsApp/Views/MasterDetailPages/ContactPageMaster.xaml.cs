﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UIContactsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIContactsApp.Views.MasterDetailPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public ContactMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new ContactPageMasterViewModel();
            ListView = MenuItemsListView;
        }
    }
}