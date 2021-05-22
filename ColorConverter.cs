using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    class ColorConverter : IValueConverter
    {
        public static IValueConverter Instance { get; } = new ColorConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(string.IsNullOrEmpty(value as string))
            {
                return null;
            }
            else
            {
                return Color.FromHex(value.ToString());
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
