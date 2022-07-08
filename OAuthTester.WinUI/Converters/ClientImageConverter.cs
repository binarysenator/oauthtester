using System;
using Microsoft.UI.Xaml.Data;

namespace OAuthTester.WinUI.Converters;

public class ClientImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string culture)
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

        //var resource = Application.Current.FindResource(resourceKey);
        //return resource as ImageSource;
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string culture)
    {
        throw new NotImplementedException();
    }
}