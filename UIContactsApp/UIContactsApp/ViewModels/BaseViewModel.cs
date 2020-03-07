using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using UIContactsApp.AppServices;

namespace UIContactsApp.ViewModels
{
    public abstract class BaseViewModel
    {
        protected INavigationService navigationService;
        protected IPageDialogService dialogService;
        protected IPersonDB personDB;
        public BaseViewModel(INavigationService navigationService, IPageDialogService dialogService, IPersonDB personDB)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
        }
    }
}
