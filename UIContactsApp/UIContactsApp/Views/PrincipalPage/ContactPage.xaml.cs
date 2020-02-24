
using UIContactsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIContactsApp.Views.PrincipalPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
            BindingContext = new ContactPageViewModel();
        }
    }
}