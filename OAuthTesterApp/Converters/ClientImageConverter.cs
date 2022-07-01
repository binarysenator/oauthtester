using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace OAuthTesterApp.Converters;

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

        var resource = Application.Current.Resources.FirstOrDefault(res => (string) res.Key == resourceKey);
        return (ImageSource) resource.Value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string culture)
    {
        throw new NotImplementedException();
    }
}