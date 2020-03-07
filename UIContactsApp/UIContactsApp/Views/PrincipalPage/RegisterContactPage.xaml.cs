
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIContactsApp.Helpers;
using UIContactsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIContactsApp.Views.PrincipalPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterContactPage : ContentPage
    {
        public RegisterContactPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<RegisterContactPageViewModel, string>(this, "Photo", (param, sender) =>
            {
                ImagePhoto.Source = sender;
                ImagePhoto.Aspect = Aspect.AspectFill;
            });
        }
    }
}