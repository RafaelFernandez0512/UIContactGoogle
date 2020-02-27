
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using UIContactsApp.Helpers;
using Xamarin.Forms;

namespace UIContactsApp.ViewModels
{
    public class RegisterContactPageViewModel : INotifyPropertyChanged
    {
        public ICommand MoreFieldsCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand TakePhotoCommand { get; set; }
        public bool IsVisible { get; set; }
        public bool IsVisibleCommand { get; set; }
        public Person Person { get; set; } 
        const string selectPicture = "Select picture";
        const string takepicture = "Take a picture";
        public RegisterContactPageViewModel(Person person)
        {
            
            Person = person ?? new Person();
            var rnd = new Random();
            IsVisibleCommand = true;
            IsVisible = false;
            Person.ImagePerson = Person.ImagePerson == null ? "Captureusuario" : Person.ImagePerson;
            MoreFieldsCommand = new Command(() =>
            {
                IsVisible = !IsVisible;
                IsVisibleCommand = !IsVisibleCommand;
            });
            CultureInfo ci = new CultureInfo("es-MX");
            SaveCommand = new Command(async () =>
            {
                
                Person.FrameColor = rnd.Next(1, 10);

                if (!string.IsNullOrEmpty(Person.NamePerson)|| !string.IsNullOrEmpty(Person.NickName))
                {
                    Person.NamePerson = ci.TextInfo.ToTitleCase(Person.NamePerson);
                    var name = Person.NickName == null ? Person.NamePerson.FirtsLetter():Person.NickName.FirtsLetter();
                    Person.ImagePerson = Person.ImagePerson == "Captureusuario" ? name : Person.ImagePerson;
                    await App.PersonDB.SaveItemAsync(Person);
                    await App.Current.MainPage.Navigation.PopToRootAsync();
                }

            });
            TakePhotoCommand = new Command(async() => {
                var select = await App.Current.MainPage.DisplayActionSheet("chosess image", "Cancel",null, selectPicture, takepicture);
                switch (select)
                {
                    case "Select picture":
                        {
                            LoadImage();
                            break;
                        }
                    case "Take a picture":
                        {
                            TakeImage();
                             break;
                        }
                    default:
                        break;
                }

            });
        }
        public async void TakeImage()
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await App.Current.MainPage.DisplayAlert("Permission error", "Camara cant open", "ok");
                    return;
                }
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    CompressionQuality = 75,
                    CustomPhotoSize = 50,
                });

                if (file == null)
                {
                    return;
                }
                Person.ImagePerson = file.Path;
                MessagingCenter.Send(this, "Photo", Person.ImagePerson);
            }
            catch (Exception err)
            {
                await App.Current.MainPage.DisplayAlert("Permission error", $"{err.Message}", "ok");
            }

        }
        public async void LoadImage()
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await App.Current.MainPage.DisplayAlert("Permission error", "Camara cant open", "ok");
                    return;
                }
                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                });

                if (file == null)
                {
                    return;
                }
                Person.ImagePerson = file.Path;
                MessagingCenter.Send(this, "Photo", Person.ImagePerson);
            }
            catch (Exception err)
            {
                await App.Current.MainPage.DisplayAlert("Permission error", $"{err.Message}", "ok");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
