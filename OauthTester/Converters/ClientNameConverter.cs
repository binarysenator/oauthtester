using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OAuthTester.Converters
{
    public class ClientNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
