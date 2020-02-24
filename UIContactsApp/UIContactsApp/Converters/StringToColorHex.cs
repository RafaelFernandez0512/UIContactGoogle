using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace UIContactsApp.Converters
{
    public class StringToColorHex : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Color.Default;

            int  valueAsInt = (int)value;
            switch (valueAsInt)
            {
                case 1:
                    {
                        return Color.MistyRose;
                    }
                case 2:
                    {
                        return Color.Red;
                    }
                case 3:
                    {
                        return Color.Indigo;
                    }
                case 4:
                    {
                        return Color.CadetBlue;
                    }
                case 5:
                    {
                        return Color.ForestGreen;
                    }
                case 6:
                    {
                        return Color.Yellow;
                    }
                case 7:
                    {
                        return Color.CornflowerBlue;
                    }
                case 8:
                    {
                        return Color.Blue;
                    }
                case 9:
                    {
                        return Color.Accent;
                    }
                case 10:
                    {
                        return Color.Accent;
                    }
                default:
                    {
                        return Color.Indigo;
                    }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.Default;
        }
    }
}
