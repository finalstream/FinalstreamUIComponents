using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace FinalstreamUIComponents.Converters
{
    public class EnumToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null || !(value is Enum))
                return Visibility.Collapsed;

            var parameters = parameter.ToString();
            var isMatch = false;

            foreach (var param in parameters.Split(','))
            {
                isMatch = (value.ToString() == param.Trim());

                if (isMatch)
                    break;
            }

            return isMatch ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
