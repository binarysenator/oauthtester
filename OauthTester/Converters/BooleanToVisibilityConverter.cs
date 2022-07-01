using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace OAuthTester.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
                        outcome = Visibility.Hidden;
                    }
                }
            }

            if (outcome.HasValue)
            {
                return outcome.Value;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public bool Inverted { get; set; }
    }
}
