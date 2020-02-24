using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIContactsApp.Views.ControlsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryContactView : ContentView
    {
        public static readonly BindableProperty TextEntryProperty = BindableProperty.Create(nameof(TextEntry),
                                                                                                   typeof(string),
                                                                                                   typeof(EntryContactView),
                                                                                                   string.Empty,
                                                                                                   BindingMode.TwoWay,
                                                                                                   propertyChanged: TextChanged);
        public static readonly BindableProperty PlaceHolderEntryProperty = BindableProperty.Create(nameof(PlaceHolderEntry),
                                                                                                    typeof(string),
                                                                                                    typeof(EntryContactView),    
                                                                                                    string.Empty);
        public static readonly BindableProperty ImageEntryProperty = BindableProperty.Create(nameof(ImageEntry),
                                                                                            typeof(ImageSource),
                                                                                            typeof(EntryContactView),
                                                                                            default(ImageSource));
        public static readonly BindableProperty IsVisibleCommandProperty = BindableProperty.Create(nameof(IsVisibleCommand),
                                                                                    typeof(bool),
                                                                                    typeof(EntryContactView),
                                                                                    false);
        public static readonly BindableProperty SecondTextEntryProperty = BindableProperty.Create(nameof(SecondTextEntry),
                                                                                           typeof(string),
                                                                                           typeof(EntryContactView),
                                                                                           string.Empty,
                                                                                           BindingMode.TwoWay,
                                                                                           propertyChanged: SecondTextChanged);
        public static readonly BindableProperty PrefixTextEntryProperty = BindableProperty.Create(nameof(PrefixTextEntry),
                                                                                           typeof(string),
                                                                                           typeof(EntryContactView),
                                                                                           string.Empty,
                                                                                           BindingMode.TwoWay,
                                                                                           propertyChanged: PrefixTextChanged);
        public static readonly BindableProperty KeyboardEntryProperty = BindableProperty.Create(nameof(KeyboardEntry),
                                                                                   typeof(Keyboard),
                                                                                   typeof(EntryContactView),
                                                                                   default(Keyboard));

        public string TextEntry
        {
            get => (string)GetValue(TextEntryProperty);
            set => SetValue(TextEntryProperty, value);
        }
        private static void TextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is EntryContactView control)) return;
            var items = (string)newValue;
            control.NameEntry.Text = items;
        }
        public ICommand NameFieldsCommand 
        {
            get=> new Command(()=> {
                IsVisibleEntrys.IsVisible = !IsVisibleEntrys.IsVisible;
                DowntoUpButton.ImageSource = IsVisibleEntrys.IsVisible ? "ic_keyboard_arrow_up.png" : "ic_keyboard_arrow_down.png";
            });
          set { 
            
            } }
        public string PlaceHolderEntry { 
            get => (string)GetValue(PlaceHolderEntryProperty); 
            set => SetValue(PlaceHolderEntryProperty,value); 
        }
        public ImageSource ImageEntry
        {
            get => (ImageSource)GetValue(ImageEntryProperty);
            set => SetValue(ImageEntryProperty, value);
        }
        public Keyboard KeyboardEntry
        {
            get => (Keyboard)GetValue(KeyboardEntryProperty);
            set => SetValue(KeyboardEntryProperty, value);
        }
        public bool IsVisibleCommand
        {
            get => (bool)GetValue(IsVisibleCommandProperty);
            set => SetValue(IsVisibleCommandProperty, value);
        }
        public string SecondTextEntry
        {
            get => (string)GetValue(SecondTextEntryProperty);
            set => SetValue(SecondTextEntryProperty, value);
        }
        private static void SecondTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is EntryContactView control)) return;
            var items = (string)newValue;
            control.XSegundoN.Text = items;
        }
        public string PrefixTextEntry
        {
            get => (string)GetValue(PrefixTextEntryProperty);
            set => SetValue(PrefixTextEntryProperty, value);
        }
        private static void PrefixTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is EntryContactView control)) return;
            var items = (string)newValue;
            control.PrefixEntry.Text = items;
        }
        public EntryContactView()
        {
            InitializeComponent();
        }
    }
}