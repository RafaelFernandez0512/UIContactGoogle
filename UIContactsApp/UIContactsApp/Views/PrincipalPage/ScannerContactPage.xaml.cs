using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIContactsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIContactsApp.Views.PrincipalPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannerContactPage : ContentPage
    {
        public ScannerContactPage()
        {
            InitializeComponent();
            BindingContext = new ScannerContactPageViewModel();
        }
    }
}