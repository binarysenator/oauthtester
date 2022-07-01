using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Mime;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OAuthTester.Converters;

public class ClientImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var resourceKey = string.Empty;

        if (value is string stringValue)
        {
            
            switch (stringValue)
            {
                case "a":
                    resourceKey = "android";
                    break;
                case "b":
                    resourceKey = "iphone";
                    break;
                case "c":
                    resourceKey = "website";
                    break;
                default:
                    return null;
            }
        }

        if (string.IsNullOrEmpty(resourceKey))
        {
            return null;
        }

        var resource = Application.Current.FindResource(resourceKey);
        return resource as ImageSource;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}