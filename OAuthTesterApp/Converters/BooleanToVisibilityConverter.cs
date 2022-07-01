using System;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace OAuthTesterApp.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            Visibility? outcome = null;

            if (targetType == typeof(Visibility))
            {
                if (value is bool booleanValue)
                {
                    booleanValue = Inverted ? !booleanValue : booleanValue;

                    if (booleanValue)
                    {
                        outcome = Visibility.Visible;
                    }
                    else
                    {
                        outcome = Visibility.Collapsed;
                    }
                }
            }

            if (outcome.HasValue)
            {
                return outcome.Value;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }

        public bool Inverted { get; set; }
    }
}
