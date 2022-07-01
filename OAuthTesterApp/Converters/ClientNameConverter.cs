using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace OAuthTesterApp.Converters
{
    public class ClientNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            if (value is string stringValue)
            {
                switch (stringValue)
                {
                    case "a":
                        return "Web Client";
                    case "b":
                        return "iOS Client";
                    case "c":
                        return "Android";
                    default:
                        return "Unknown client";
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
