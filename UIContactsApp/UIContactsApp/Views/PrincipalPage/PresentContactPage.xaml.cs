
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIContactsApp.Models;
using UIContactsAppp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIContactsApp.Views.PrincipalPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PresentContactPage : ContentPage
    {
        public PresentContactPage(Person person)
        {
            InitializeComponent();
            BindingContext = new PresentContactPageViewModel(person);
        }
    }
}